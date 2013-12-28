namespace ETicket.Client
{
    partial class UcTicket
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddTicket = new System.Windows.Forms.Button();
            this.txtNote2 = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCarNo2 = new System.Windows.Forms.TextBox();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnAddTicket
            // 
            this.btnAddTicket.Location = new System.Drawing.Point(422, 4);
            this.btnAddTicket.Name = "btnAddTicket";
            this.btnAddTicket.Size = new System.Drawing.Size(53, 23);
            this.btnAddTicket.TabIndex = 15;
            this.btnAddTicket.Text = "追加";
            this.btnAddTicket.UseVisualStyleBackColor = true;
            this.btnAddTicket.Click += new System.EventHandler(this.btnAddTicket_Click);
            // 
            // txtNote2
            // 
            this.txtNote2.Location = new System.Drawing.Point(274, 7);
            this.txtNote2.MaxLength = 100;
            this.txtNote2.Name = "txtNote2";
            this.txtNote2.Size = new System.Drawing.Size(133, 21);
            this.txtNote2.TabIndex = 14;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(222, 6);
            this.txtAmount.MaxLength = 8;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(46, 21);
            this.txtAmount.TabIndex = 13;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(74, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(34, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "查";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCarNo2
            // 
            this.txtCarNo2.Location = new System.Drawing.Point(8, 6);
            this.txtCarNo2.MaxLength = 7;
            this.txtCarNo2.Name = "txtCarNo2";
            this.txtCarNo2.Size = new System.Drawing.Size(60, 21);
            this.txtCarNo2.TabIndex = 9;
            // 
            // cmbProject
            // 
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(119, 7);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(97, 20);
            this.cmbProject.TabIndex = 12;
            // 
            // UcTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddTicket);
            this.Controls.Add(this.txtNote2);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtCarNo2);
            this.Name = "UcTicket";
            this.Size = new System.Drawing.Size(482, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddTicket;
        private System.Windows.Forms.TextBox txtNote2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCarNo2;
        private System.Windows.Forms.ComboBox cmbProject;
    }
}
