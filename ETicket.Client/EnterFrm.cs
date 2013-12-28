using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ETicket.Client.Dal;
using Microsoft.Reporting.WinForms;

namespace ETicket.Client
{
    public partial class EnterFrm : Form
    {
        public EnterFrm()
        {
            InitializeComponent();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            var frm = new UserFrm();
            frm.EnterFrm = this;
            frm.Show();
            this.Hide();
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            var frm = new TicketFrm();
            frm.EnterFrm = this;
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new ConfigFrm();
            frm.EnterFrm = this;
            frm.Show();
            this.Hide();
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            try
            {
                var ds = new Ticket();
                var table = ds.Tables["ticket"];
                for (int i = 0; i < 9; i++)
                {
                    var row = table.NewRow();
                    row["cell"] = "一层东户";
                    row["lastMonth"] = 1000;
                    row["current"] = 2000;
                    row["owner"] = "test001";
                    table.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
