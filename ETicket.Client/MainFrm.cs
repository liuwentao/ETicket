using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ETicket.Client.Bll;
using ETicket.Client.Domain;

namespace ETicket.Client
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }
        Dictionary<string, string> _projects;
        /// <summary>
        /// 加载时候的处理逻辑
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            //testData();
            Init();


        }
        /// <summary>
        /// 造测试数据用
        /// </summary>
        private void testData()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("carno", "");
            dict.Add("tdate", DateTime.Now.ToString("yyyy-MM-dd"));
            dict.Add("proj", "1");
            dict.Add("amount", "");
            dict.Add("note", "");
            Random rand = new Random();
            HiBiz biz = new HiBiz();
            for (int i = 0; i < 1000; i++)
            {
                dict["carno"] = "测A" + rand.Next(10000, 99999);
                dict["proj"] = i % 2 == 0 ? "1" : "2";
                dict["amount"] = rand.Next(1, 100).ToString();

                biz.AddTicket(dict);
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            HiBiz biz = new HiBiz();
            var Projects = biz.GetProject();
            BoxItem item = null;
            foreach (var pro in Projects)
            {
                item = new BoxItem();
                item.Code = pro.Key;
                item.Text = pro.Value;
                //cmbProject.Items.Add(item);
            }
            initGrid(1);

            DataSet ds = biz.GetTicketOfCar("-1");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "data";
            forbiddenSort(dataGridView1);
        }

        /// <summary>
        /// 禁止排序
        /// </summary>
        /// <param name="view"></param>
        private void forbiddenSort(DataGridView view)
        {
            for (int i = 0; i < view.Columns.Count; i++)
            {
                view.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        /// <summary>
        /// 添加车辆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            HiBiz biz = new HiBiz();
            if (string.IsNullOrEmpty(txtCarNo.Text.Trim()))
            {
                MessageBox.Show("请输入车牌号码");
                return;
            }

            try
            {
                if (biz.AddCar(txtCarNo.Text, txtCarNote.Text))
                {
                    MessageBox.Show("添加成功");
                    txtCarNo.Text = string.Empty;
                    txtCarNote.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// 增加一条单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTicket_Click(object sender, EventArgs e)
        {
            ////if (string.IsNullOrEmpty(txtCarNo2.Text.Trim()))
            ////{
            ////    MessageBox.Show("请输入车牌号码");
            ////    return;
            ////}
            //////检查金额
            ////if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
            ////{
            ////    MessageBox.Show("请输入金额");
            ////    return;
            ////}
            ////if (cmbProject.SelectedIndex < 0)
            ////{
            ////    MessageBox.Show("请选择项目");
            ////    return;
            ////}
            //Dictionary<string, string> dict = new Dictionary<string, string>();
            //dict.Add("carno", txtCarNo2.Text.Trim());
            //dict.Add("tdate", dtpDate.Value.ToString("yyyy-MM-dd"));
            //BoxItem item = cmbProject.SelectedItem as BoxItem;
            //if (item != null)
            //{
            //    dict.Add("proj", item.Code);
            //}
            //dict.Add("amount", txtAmount.Text.Trim());

            //dict.Add("note", txtNote2.Text.Trim());
            //try
            //{
            //    HiBiz biz = new HiBiz();
            //    if (biz.AddTicket(dict))
            //    {
            //        //if (!rbDay.Checked)
            //        //{
            //        //    rbDay.Checked = true;
            //        //}
            //        //else
            //        //{
            //        //    initGrid(1);
            //        //}
            //        MessageBox.Show("成功!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


        }

        /// <summary>
        /// 初始化表格
        /// </summary>
        /// <param name="type"></param>
        private void initGrid(int type)
        {
            HiBiz biz = new HiBiz();
            DataSet ds = biz.GetTodayTickets();
            dtGrid.DataSource = ds;
            dtGrid.DataMember = ds.Tables[0].TableName;
            forbiddenSort(dtGrid);
            DataSet dsStatic = biz.GetTodayProejctStatic();
            StringBuilder builder = new StringBuilder();
            int i = 0;
            builder.Append("今日汇总:\r\n\r\n");
            foreach (DataRow item in dsStatic.Tables["data"].Rows)
            {
                i++;
                builder.Append(string.Format("{0}:{1}笔 总金额:{2}", item["name"], item["count"], string.IsNullOrEmpty(item["amount"].ToString()) ? "0" : item["amount"].ToString()));
                if (i % 4 == 0)
                {
                    builder.AppendLine();
                    builder.AppendLine();
                }
                else
                {
                    builder.Append("  ");
                }

            }
            lblStatic.Text = builder.ToString();
        }

        /// <summary>
        /// 备份操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmBackup_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "备份(*.bak)|*.bak";
                dialog.FileName = DateTime.Now.ToString("yyyy-MM-dd") + ".bak";
                if (DialogResult.OK.Equals(dialog.ShowDialog(this)))
                {
                    File.Copy("Cardb.db", dialog.FileName, true);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 添加新的车辆
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        private bool ucTicket2_AddCar(Dictionary<string, string> dict)
        {
            try
            {
                HiBiz biz = new HiBiz();
                if (biz.AddTicket(dict))
                {

                    initGrid(1);
                    MessageBox.Show("成功!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 查询车辆信息和交易记录
        /// </summary>
        /// <param name="carNo"></param>
        private void ucTicket2_SearchCar(string carNo)
        {
            HiBiz biz = new HiBiz();
            Dictionary<string, string> dict = biz.GetCarInfo(carNo);


            if (dict.Count > 0)
            {
                txtCarNo.Text = dict["carno"];
                txtCarNote.Text = dict["note"];
            }
            else
            {
                MessageBox.Show("无数据");
                return;
            }
            DataSet ds = biz.GetTicketOfCar(carNo);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "data";
        }


        /// <summary>
        /// 绑定项目数据
        /// </summary>
        /// <param name="box"></param>
        private void ucTicket2_BindDropBox(ComboBox box)
        {
            if (_projects == null)
            {

                HiBiz biz = new HiBiz();
                _projects = biz.GetProject();
            }
            BoxItem item = null;
            foreach (var pro in _projects)
            {
                item = new BoxItem();
                item.Code = pro.Key;
                item.Text = pro.Value;
                box.Items.Add(item);
            }
        }

        /// <summary>
        /// 查看历史数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmHistory_Click(object sender, EventArgs e)
        {
            DetailFrm frm = new DetailFrm();
            frm.ShowDialog();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmExport_Click(object sender, EventArgs e)
        {
            DataSet ds = dtGrid.DataSource as DataSet;
            if (ds != null && ds.Tables.Contains("data") && ds.Tables["data"].Rows.Count > 0)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "备份(*.csv)|*.csv";
                dialog.FileName = DateTime.Now.ToString("yyyy-MM-dd") + ".csv";
                if (DialogResult.OK.Equals(dialog.ShowDialog()))
                {
                    StringBuilder builder = new StringBuilder();
                    using (StreamWriter writer = new StreamWriter(dialog.FileName, false, Encoding.Default))
                    {
                        foreach (DataRow row in ds.Tables["data"].Rows)
                        {
                            builder = new StringBuilder();
                            bool isFirst = true;
                            foreach (DataColumn col in ds.Tables["data"].Columns)
                            {
                                if (isFirst)
                                {
                                    builder.Append(row[col]);
                                    isFirst = false;
                                }
                                else { builder.Append("," + row[col]); }
                            }
                            writer.WriteLine(builder);
                        }

                    }
                }
            }
        }

    }
}
