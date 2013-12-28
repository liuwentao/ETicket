using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ETicket.Client.Bll;
using ETicket.Client.Domain;
using System.IO;

namespace ETicket.Client
{
    public partial class DetailFrm : Form
    {
        public DetailFrm()
        {
            InitializeComponent();
            CarNo = string.Empty;
        }

        public bool IsDialog { get; set; }
        public string CarNo { get; set; }

        /// <summary>
        /// 加载时候的处理逻辑
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            init();

        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            HiBiz biz = new HiBiz();

            dtpStart.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01"));
            dtpEnd.Value = DateTime.Now;
            Dictionary<string, string> dict = biz.GetProject();
            BoxItem boxItem = null;
            cmbProject.Items.Add(new BoxItem());
            foreach (var item in dict)
            {
                boxItem = new BoxItem();
                boxItem.Code = item.Key;
                boxItem.Text = item.Value;
                cmbProject.Items.Add(boxItem);
            }
            cmbProject.SelectedIndex = 0;
            initGrid();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            initGrid();
        }

        /// <summary>
        /// 初始化表格数据
        /// </summary>
        private void initGrid()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(txtCarNo.Text.Trim()))
            {
                dict.Add("carno", "%");
            }
            else
            {
                dict.Add("carno", txtCarNo.Text.Trim());
            }

            dict.Add("dateBegin", dtpStart.Value.ToString("yyyy-MM-dd"));
            dict.Add("dateEnd", dtpEnd.Value.ToString("yyyy-MM-dd"));


            BoxItem proItem = cmbProject.SelectedItem as BoxItem;
            if (proItem == null || string.IsNullOrEmpty(proItem.Code))
            {
                dict.Add("proj", "%");
            }
            else
            {
                dict.Add("proj", proItem.Code);
            }
            HiBiz biz = new HiBiz();
            DataSet ds = biz.GetTickets(dict);
            dtGrid.DataSource = ds;
            dtGrid.DataMember = "data";
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
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
