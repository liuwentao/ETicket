using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ETicket.Client.Bll;

namespace ETicket.Client
{
    public partial class ConfigFrm : BaseFrm
    {
        public ConfigFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载的时候,读取配置信息
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                var biz = new TicketBiz();
                var ds = biz.GetSysConfig();
                if (ds.Tables.Contains("data"))
                {
                    foreach (DataRow row in ds.Tables["data"].Rows)
                    {
                        if ("1".Equals(row["typeid"].ToString()))
                        {
                            txtPeoplePrice.Text = row["price"].ToString();
                            txtLimitCount.Text = row["limitdegree"].ToString();
                            txtLimitPrice.Text = row["limitprice"].ToString();
                            txtPub.Text = row["publicfee"].ToString();
                        }
                        else
                        {
                            txtBizPrice.Text = row["price"].ToString();
                            txtBizLimit.Text = row["limitdegree"].ToString();
                            txtBizLimitPrize.Text = row["limitprice"].ToString();
                            txtBizPublic.Text = row["publicfee"].ToString();
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            //need new table in database ."system_config"

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var dic = new Dictionary<string, string>();
                dic.Add("price", txtPeoplePrice.Text.Trim());
                dic.Add("limitPrice", txtLimitPrice.Text.Trim());
                dic.Add("limitDegree", txtLimitCount.Text.Trim());
                dic.Add("publicfee", txtPub.Text.Trim());
                dic.Add("typeid", "1");
                var biz = new TicketBiz();
                biz.ModifySysConfig(dic);
                dic = new Dictionary<string, string>();
                dic.Add("price", txtBizPrice.Text.Trim());
                dic.Add("limitPrice", txtBizLimitPrize.Text.Trim());
                dic.Add("limitDegree", txtBizLimit.Text.Trim());
                dic.Add("publicfee", txtBizPublic.Text.Trim());
                dic.Add("typeid", "2");
                biz.ModifySysConfig(dic);
                MessageBox.Show("保存成功");
            }
            catch (Exception ex)
            {

                MessageBox.Show("保存失败");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
