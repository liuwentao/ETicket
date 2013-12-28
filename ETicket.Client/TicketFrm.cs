using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ETicket.Client.Bll;
using ETicket.Client.Domain;
using Microsoft.Reporting.WinForms;
using ETicket.Client.Dal;
using System.IO;

namespace ETicket.Client
{
    public partial class TicketFrm : BaseFrm
    {
        public TicketFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载时候的处理逻辑
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            var biz = new TicketBiz();
            var areas = biz.GetAreas();

            BoxItem item = null;
            foreach (var area in areas)
            {
                item = new BoxItem();
                item.Code = area.Key;
                item.Text = area.Value;
                cmbArea.Items.Add(item);
            }
            if (cmbArea.Items.Count > 0)
            {
                cmbArea.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 小区改变时候的处理逻辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            var biz = new TicketBiz();
            BoxItem item = cmbArea.SelectedItem as BoxItem;
            if (item == null)
            {
                return;
            }
            var builds = biz.GetBuild(item.Code);
            cmbBuild.Items.Clear();
            foreach (var build in builds)
            {
                item = new BoxItem();
                item.Code = build.Key;
                item.Text = build.Value;
                cmbBuild.Items.Add(item);
            }
            cmbBuild.SelectedIndex = 0;
            cmbBuild_SelectedIndexChanged(cmbArea, null);
        }

        /// <summary>
        /// 楼栋改变时候的处理逻辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBuild_SelectedIndexChanged(object sender, EventArgs e)
        {
            var biz = new TicketBiz();
            BoxItem areaItem = cmbArea.SelectedItem as BoxItem;
            if (areaItem == null)
            {
                return;
            }
            var buildItem = cmbBuild.SelectedItem as BoxItem;
            if (buildItem == null)
            {
                return;
            }
            //get empty ticket for modify
            DataSet ds = biz.GetEmptyTicket(areaItem.Code, buildItem.Code);
            if (!ds.Tables.Contains("data"))
            {
                //todo fix this message
                MessageBox.Show("no data");
                return;
            }
            dtGrid.AutoGenerateColumns = false;
            dtGrid.DataSource = ds;
            dtGrid.DataMember = "data";
        }
        /// <summary>
        /// 进入编辑时候的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            double decCurrent = Convert2Dec(dtGrid["current", e.RowIndex].Value);
            if (decCurrent == 0)
            {
                dtGrid["diff", e.RowIndex].Value = 0;
                dtGrid["amount", e.RowIndex].Value = 0;
                return;
            }
            double lastMonth = Convert2Dec(dtGrid["lastMonth", e.RowIndex].Value);
            double publicFee = Convert2Dec(dtGrid["pub", e.RowIndex].Value);
            double limitFee = Convert2Dec(dtGrid["limitFee", e.RowIndex].Value);
            double limitDegree = Convert2Dec(dtGrid["limitDegree", e.RowIndex].Value);
            double epriect = Convert2Dec(dtGrid["price", e.RowIndex].Value);
            if ((decCurrent - lastMonth) < 0)
            {
                MessageBox.Show("当月表数少于上月,请检查!");
                return;
            }
            double degree = lastMonth - decCurrent;

            double price = calcEprice(decCurrent - lastMonth, limitDegree, epriect, limitFee);
            dtGrid["diff", e.RowIndex].Value = decCurrent - lastMonth;
            dtGrid["amount", e.RowIndex].Value = (price + publicFee).ToString();
        }

        /// <summary>
        /// 计算电价
        /// </summary>
        /// <param name="pdiff"></param>
        /// <param name="level1"></param>
        /// <param name="price1"></param>
        /// <param name="price2"></param>
        /// <returns></returns>
        private double calcEprice(double pdiff, double level1, double price1, double price2)
        {
            if (pdiff < level1)
            {
                return pdiff * price1;
            }
            return level1 * price1 + (pdiff - level1) * price2;
        }

        /// <summary>
        /// 转成数子
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private double Convert2Dec(object obj)
        {
            if (obj != null)
            {
                double dec = -1;
                if (double.TryParse(obj.ToString(), out dec))
                {
                    return dec;
                }
            }

            return -1;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes.Equals(MessageBox.Show("确认已经全部录入完毕?", "提醒", MessageBoxButtons.YesNo)))
            {
                BoxItem areaItem = cmbArea.SelectedItem as BoxItem;
                if (areaItem == null)
                {
                    return;
                }
                var buildItem = cmbBuild.SelectedItem as BoxItem;
                if (buildItem == null)
                {
                    return;
                }
                var ds = dtGrid.DataSource as DataSet;
                var biz = new TicketBiz();

                if (biz.SaveTicket(ds, buildItem.Code, areaItem.Code))
                {
                    MessageBox.Show("保存成功!");
                }
                else
                {
                    MessageBox.Show("失败!");
                }
            }

        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = dtGrid.DataSource as DataSet;

                if (ds != null)
                {
                    var ticket = new Ticket();
                    foreach (DataRow row in ds.Tables["data"].Rows)
                    {
                        if (row["current"] != null && Convert2Dec(row["current"]) > 0)
                        {
                            var printRow = ticket.Tables["ticket"].NewRow();
                            printRow["cell"] = row["cell"];
                            printRow["price"] = row["price"];
                            printRow["lastMonth"] = row["last"];
                            printRow["current"] = row["current"];
                            printRow["diff"] = row["diff"];
                            printRow["amount"] = row["amount"];
                            printRow["pub"] = row["public"];
                            printRow["owner"] = row["owner"];
                            printRow["cell"] = row["cell"];
                            printRow["area"] = row["area_name"];
                            printRow["build"] = row["build_name"];
                            printRow["chnAmount"] = (new Money(Convert2Dec(row["amount"]))).Convert();
                            ticket.Tables["ticket"].Rows.Add(printRow);
                        }
                    }
                    if (ticket.Tables["ticket"].Rows.Count > 0)
                    {
                        Print(ticket);
                    }

                }



            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(@"c:\log.log"))
                {
                    writer.Write(ex.StackTrace);
                }
                MessageBox.Show(ex.StackTrace);
            }

        }

        private void Print(Ticket ticket)
        {

            LocalReport report = new LocalReport();

            report.DisplayName = "Report2";
            //设置需要打印的报表的文件名称。
            report.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Report2.rdlc";
            //创建要打印的数据源
            var param = new ReportParameter("title", DateTime.Now.ToString("yyyy年MM月电费收据"));
            report.SetParameters(param);

            ReportDataSource source = new ReportDataSource("TS", ticket.Tables["ticket"].Rows);
            report.DataSources.Add(source);
            //刷新报表中的需要呈现的数据
            report.Refresh();
            RDLCPrinter.Run(report);
        }
    }
}
