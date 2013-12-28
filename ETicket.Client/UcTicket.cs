using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ETicket.Client.Domain;
using System.Text.RegularExpressions;

namespace ETicket.Client
{
    public partial class UcTicket : UserControl
    {
        public event BindDropBoxHandler BindDropBox;
        public event SearchCarHandler SearchCar;
        public event AddCarHandler AddCar;
        public UcTicket()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            if (BindDropBox != null)
            {
                BindDropBox(cmbProject);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (SearchCar != null)
            {
                if (string.IsNullOrEmpty(txtCarNo2.Text.Trim()))
                {
                    MessageBox.Show("请输入车牌号码");
                    return;
                }
                SearchCar(txtCarNo2.Text.Trim());
            }
        }
        private void btnAddTicket_Click(object sender, EventArgs e)
        {
            if (AddCar == null)
            {
                throw new Exception("为初始化!");
            }
            if (string.IsNullOrEmpty(txtCarNo2.Text.Trim()))
            {
                MessageBox.Show("请输入车牌号码");
                return;
            }
            //检查金额
            if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
            {
                MessageBox.Show("请输入金额");
                return;
            }
            if (cmbProject.SelectedIndex < 0)
            {
                MessageBox.Show("请选择项目");
                return;
            }
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("carno", txtCarNo2.Text.Trim());
            dict.Add("tdate", DateTime.Now.ToString("yyyy-MM-dd"));
            BoxItem item = cmbProject.SelectedItem as BoxItem;
            if (item != null)
            {
                dict.Add("proj", item.Code);
            }
            dict.Add("amount", txtAmount.Text.Trim());

            dict.Add("note", txtNote2.Text.Trim());

            if (AddCar(dict))
            {
                txtCarNo2.Text = string.Empty;
                cmbProject.SelectedIndex = -1;
                txtNote2.Text = string.Empty;
                txtAmount.Text = string.Empty;
            }


        }
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            string amount = txtAmount.Text.Trim();
            Regex regex = new Regex(@"(^\d{0,7}$)|(^\d{0,7}\.\d{0,2}$)");
            if (!regex.IsMatch(amount))
            {
                txtAmount.Text = "";
            }

        }

    }

    public delegate void BindDropBoxHandler(ComboBox box);

    public delegate void SearchCarHandler(string carNo);

    public delegate bool AddCarHandler(Dictionary<string, string> dict);
}
