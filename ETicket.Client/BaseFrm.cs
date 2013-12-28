using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ETicket.Client
{
    public class BaseFrm : Form
    {

        /// <summary>
        /// 主窗口
        /// </summary>
        public Form EnterFrm { get; set; }

        public void ShowEnter()
        {
            if (EnterFrm != null)
            {
                EnterFrm.Show();
                this.Hide();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (this.EnterFrm != null)
            {
                EnterFrm.Show();
            }
        }
    }
}

