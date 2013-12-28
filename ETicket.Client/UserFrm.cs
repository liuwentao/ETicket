using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ETicket.Client.Bll;
using ETicket.Client.Domain;

namespace ETicket.Client
{
    public partial class UserFrm : BaseFrm
    {
        public UserFrm()
        {
            InitializeComponent();
        }

        public int UserId { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            var biz = new TicketBiz();
            var areas = biz.GetAreas();
            foreach (var area in areas)
            {
                BoxItem item = new BoxItem();
                item.Code = area.Key;
                item.Text = area.Value;
                cmbArea.Items.Add(item);
                cmbArea2.Items.Add(item);
            }
            cmbType.SelectedIndex = 0;
            cmbArea2.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            TicketBiz biz = new TicketBiz();
            var dict = new Dictionary<string, string>();
            dict.Add("owner", "%" + txtSOwner.Text.Trim() + "%");
            BoxItem item = cmbArea2.SelectedItem as BoxItem;
            if (item == null)
            {
                return;
            }
            dict.Add("areaid", item.Code);

            item = cmbBuild2.SelectedItem as BoxItem;
            if (item == null)
            {
                return;
            }
            dict.Add("buildid", item.Code);
            DataSet ds = biz.GetUser(dict);
            dtGrid.DataSource = ds;
            dtGrid.DataMember = "data";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();

                if (string.IsNullOrEmpty(txtOwner.Text.Trim()))
                {
                    MessageBox.Show("请输入业主名称");
                    return;
                }
                dict.Add("owner", txtOwner.Text.Trim());
                dict.Add("phone", txtPhone.Text.Trim());
                dict.Add("address", txtAddress.Text.Trim());
                if (string.IsNullOrEmpty(txtCell.Text.Trim()))
                {
                    MessageBox.Show("请输入房间");
                    txtCell.Focus();
                    return;
                }
                dict.Add("cell", txtCell.Text.Trim());
                if (cmbType.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择用户类型");
                    return;
                }
                dict.Add("user_type", "居民".Equals(cmbType.Text) ? "1" : "2");
                string id = getAreaId(cmbArea, "小区", "areainfo");
                if (string.IsNullOrEmpty(id))
                {
                    return;
                }
                dict.Add("areaid", id);

                id = getBuildId(cmbBuild, id);
                if (string.IsNullOrEmpty(id))
                {
                    return;
                }
                dict.Add("buildid", id);
                TicketBiz biz = new TicketBiz();
                if (UserId > 0)
                {
                    dict.Add("userid", UserId.ToString());
                    if (biz.ModifyUser(dict))
                    {
                        MessageBox.Show("成功!");
                        txtOwner.Clear();
                        txtCell.Clear();
                        UserId = 0;
                    }
                }
                else
                {
                    if (biz.AddUser(dict))
                    {
                        MessageBox.Show("成功!");
                        txtOwner.Clear();
                        txtCell.Clear();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string getBuildId(ComboBox cmbBox, string areaid)
        {
            BoxItem item = cmbBox.SelectedItem as BoxItem;

            if (item != null)
            {
                return item.Code;
            }
            if (string.IsNullOrEmpty(cmbBox.Text))
            {
                MessageBox.Show("请选择或者输入一个单元楼名称");
                return string.Empty;
            }
            TicketBiz biz = new TicketBiz();
            string id = biz.AddBuild(cmbBox.Text, areaid);

            return id;
        }

        private string getAreaId(ComboBox cmbBox, string msg, string table)
        {
            BoxItem item = cmbBox.SelectedItem as BoxItem;

            if (item != null)
            {
                return item.Code;
            }
            if (string.IsNullOrEmpty(cmbBox.Text))
            {
                MessageBox.Show("请选择或者输入一个小区名称");
                return string.Empty;
            }
            TicketBiz biz = new TicketBiz();
            string id = biz.AddArea(cmbBox.Text);

            return id;
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            TicketBiz biz = new TicketBiz();
            BoxItem item = cmbArea.SelectedItem as BoxItem;
            if (item == null)
            {
                return;
            }
            var dict = biz.GetBuild(item.Code);
            cmbBuild.Items.Clear();
            foreach (var build in dict)
            {
                item = new BoxItem();
                item.Code = build.Key;
                item.Text = build.Value;
                cmbBuild.Items.Add(item);

            }
        }

        private void dtGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            txtOwner.Text = dtGrid["户主", e.RowIndex].Value.ToString();
            txtCell.Text = dtGrid["单元", e.RowIndex].Value.ToString();
            txtPhone.Text = dtGrid["电话", e.RowIndex].Value.ToString();
            cmbArea.Text = dtGrid["小区", e.RowIndex].Value.ToString();
            cmbBuild.Text = dtGrid["楼号", e.RowIndex].Value.ToString();
            UserId = int.Parse(dtGrid["编号", e.RowIndex].Value.ToString());
        }

        private void cmbArea2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TicketBiz biz = new TicketBiz();
            BoxItem item = cmbArea2.SelectedItem as BoxItem;
            if (item == null)
            {
                return;
            }
            var dict = biz.GetBuild(item.Code);
            cmbBuild2.Items.Clear();
            foreach (var build in dict)
            {
                item = new BoxItem();
                item.Code = build.Key;
                item.Text = build.Value;
                cmbBuild2.Items.Add(item);
            }
            cmbBuild2.SelectedIndex = 0;
        }
    }
}
