namespace ETicket.Client
{
    partial class MainFrm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ucTicket7 = new ETicket.Client.UcTicket();
            this.ucTicket6 = new ETicket.Client.UcTicket();
            this.ucTicket5 = new ETicket.Client.UcTicket();
            this.ucTicket4 = new ETicket.Client.UcTicket();
            this.ucTicket3 = new ETicket.Client.UcTicket();
            this.ucTicket1 = new ETicket.Client.UcTicket();
            this.ucTicket2 = new ETicket.Client.UcTicket();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCarNote = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtCarNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblStatic = new System.Windows.Forms.Label();
            this.dtGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ucTicket7);
            this.groupBox1.Controls.Add(this.ucTicket6);
            this.groupBox1.Controls.Add(this.ucTicket5);
            this.groupBox1.Controls.Add(this.ucTicket4);
            this.groupBox1.Controls.Add(this.ucTicket3);
            this.groupBox1.Controls.Add(this.ucTicket1);
            this.groupBox1.Controls.Add(this.ucTicket2);
            this.groupBox1.Location = new System.Drawing.Point(13, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 260);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工单输入";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "备注";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "金额";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "施工项目";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "查询";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "车牌";
            // 
            // ucTicket7
            // 
            this.ucTicket7.Location = new System.Drawing.Point(6, 222);
            this.ucTicket7.Name = "ucTicket7";
            this.ucTicket7.Size = new System.Drawing.Size(485, 33);
            this.ucTicket7.TabIndex = 7;
            this.ucTicket7.BindDropBox += new ETicket.Client.BindDropBoxHandler(this.ucTicket2_BindDropBox);
            this.ucTicket7.SearchCar += new ETicket.Client.SearchCarHandler(this.ucTicket2_SearchCar);
            this.ucTicket7.AddCar += new ETicket.Client.AddCarHandler(this.ucTicket2_AddCar);
            // 
            // ucTicket6
            // 
            this.ucTicket6.Location = new System.Drawing.Point(6, 192);
            this.ucTicket6.Name = "ucTicket6";
            this.ucTicket6.Size = new System.Drawing.Size(485, 33);
            this.ucTicket6.TabIndex = 6;
            this.ucTicket6.BindDropBox += new ETicket.Client.BindDropBoxHandler(this.ucTicket2_BindDropBox);
            this.ucTicket6.SearchCar += new ETicket.Client.SearchCarHandler(this.ucTicket2_SearchCar);
            this.ucTicket6.AddCar += new ETicket.Client.AddCarHandler(this.ucTicket2_AddCar);
            // 
            // ucTicket5
            // 
            this.ucTicket5.Location = new System.Drawing.Point(6, 163);
            this.ucTicket5.Name = "ucTicket5";
            this.ucTicket5.Size = new System.Drawing.Size(485, 33);
            this.ucTicket5.TabIndex = 5;
            this.ucTicket5.BindDropBox += new ETicket.Client.BindDropBoxHandler(this.ucTicket2_BindDropBox);
            this.ucTicket5.SearchCar += new ETicket.Client.SearchCarHandler(this.ucTicket2_SearchCar);
            this.ucTicket5.AddCar += new ETicket.Client.AddCarHandler(this.ucTicket2_AddCar);
            // 
            // ucTicket4
            // 
            this.ucTicket4.Location = new System.Drawing.Point(6, 131);
            this.ucTicket4.Name = "ucTicket4";
            this.ucTicket4.Size = new System.Drawing.Size(485, 33);
            this.ucTicket4.TabIndex = 4;
            this.ucTicket4.BindDropBox += new ETicket.Client.BindDropBoxHandler(this.ucTicket2_BindDropBox);
            this.ucTicket4.SearchCar += new ETicket.Client.SearchCarHandler(this.ucTicket2_SearchCar);
            this.ucTicket4.AddCar += new ETicket.Client.AddCarHandler(this.ucTicket2_AddCar);
            // 
            // ucTicket3
            // 
            this.ucTicket3.Location = new System.Drawing.Point(6, 103);
            this.ucTicket3.Name = "ucTicket3";
            this.ucTicket3.Size = new System.Drawing.Size(485, 33);
            this.ucTicket3.TabIndex = 3;
            this.ucTicket3.BindDropBox += new ETicket.Client.BindDropBoxHandler(this.ucTicket2_BindDropBox);
            this.ucTicket3.SearchCar += new ETicket.Client.SearchCarHandler(this.ucTicket2_SearchCar);
            this.ucTicket3.AddCar += new ETicket.Client.AddCarHandler(this.ucTicket2_AddCar);
            // 
            // ucTicket1
            // 
            this.ucTicket1.Location = new System.Drawing.Point(6, 75);
            this.ucTicket1.Name = "ucTicket1";
            this.ucTicket1.Size = new System.Drawing.Size(485, 33);
            this.ucTicket1.TabIndex = 2;
            this.ucTicket1.BindDropBox += new ETicket.Client.BindDropBoxHandler(this.ucTicket2_BindDropBox);
            this.ucTicket1.SearchCar += new ETicket.Client.SearchCarHandler(this.ucTicket2_SearchCar);
            this.ucTicket1.AddCar += new ETicket.Client.AddCarHandler(this.ucTicket2_AddCar);
            // 
            // ucTicket2
            // 
            this.ucTicket2.Location = new System.Drawing.Point(6, 48);
            this.ucTicket2.Name = "ucTicket2";
            this.ucTicket2.Size = new System.Drawing.Size(485, 33);
            this.ucTicket2.TabIndex = 1;
            this.ucTicket2.BindDropBox += new ETicket.Client.BindDropBoxHandler(this.ucTicket2_BindDropBox);
            this.ucTicket2.SearchCar += new ETicket.Client.SearchCarHandler(this.ucTicket2_SearchCar);
            this.ucTicket2.AddCar += new ETicket.Client.AddCarHandler(this.ucTicket2_AddCar);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmHistory,
            this.tsmExport,
            this.tsmBackup,
            this.tsmExit});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // tsmHistory
            // 
            this.tsmHistory.Name = "tsmHistory";
            this.tsmHistory.Size = new System.Drawing.Size(98, 22);
            this.tsmHistory.Text = "历史";
            this.tsmHistory.Click += new System.EventHandler(this.tsmHistory_Click);
            // 
            // tsmExport
            // 
            this.tsmExport.Name = "tsmExport";
            this.tsmExport.Size = new System.Drawing.Size(98, 22);
            this.tsmExport.Text = "导出";
            this.tsmExport.Click += new System.EventHandler(this.tsmExport_Click);
            // 
            // tsmBackup
            // 
            this.tsmBackup.Name = "tsmBackup";
            this.tsmBackup.Size = new System.Drawing.Size(98, 22);
            this.tsmBackup.Text = "备份";
            this.tsmBackup.Click += new System.EventHandler(this.tsmBackup_Click);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(98, 22);
            this.tsmExit.Text = "退出";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCarNote);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.txtCarNo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(502, 413);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "车主详情";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(12, 115);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(468, 292);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "历史交易";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(462, 272);
            this.dataGridView1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "备注";
            // 
            // txtCarNote
            // 
            this.txtCarNote.Location = new System.Drawing.Point(46, 57);
            this.txtCarNote.MaxLength = 254;
            this.txtCarNote.Multiline = true;
            this.txtCarNote.Name = "txtCarNote";
            this.txtCarNote.Size = new System.Drawing.Size(421, 52);
            this.txtCarNote.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(152, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "追加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtCarNo
            // 
            this.txtCarNo.Location = new System.Drawing.Point(46, 20);
            this.txtCarNo.MaxLength = 7;
            this.txtCarNo.Name = "txtCarNo";
            this.txtCarNo.Size = new System.Drawing.Size(100, 21);
            this.txtCarNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "车牌";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblStatic);
            this.groupBox3.Controls.Add(this.dtGrid);
            this.groupBox3.Location = new System.Drawing.Point(520, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(476, 690);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "流水";
            // 
            // lblStatic
            // 
            this.lblStatic.AutoSize = true;
            this.lblStatic.Location = new System.Drawing.Point(7, 21);
            this.lblStatic.Name = "lblStatic";
            this.lblStatic.Size = new System.Drawing.Size(53, 12);
            this.lblStatic.TabIndex = 1;
            this.lblStatic.Text = "流水统计";
            // 
            // dtGrid
            // 
            this.dtGrid.AllowUserToAddRows = false;
            this.dtGrid.AllowUserToDeleteRows = false;
            this.dtGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrid.Location = new System.Drawing.Point(6, 97);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.ReadOnly = true;
            this.dtGrid.RowHeadersVisible = false;
            this.dtGrid.RowTemplate.Height = 23;
            this.dtGrid.Size = new System.Drawing.Size(464, 587);
            this.dtGrid.TabIndex = 0;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrm";
            this.Text = "美保行汽车生活馆";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmBackup;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCarNo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtCarNote;
        private System.Windows.Forms.DataGridView dtGrid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private UcTicket ucTicket5;
        private UcTicket ucTicket4;
        private UcTicket ucTicket3;
        private UcTicket ucTicket1;
        private UcTicket ucTicket2;
        private System.Windows.Forms.Label lblStatic;
        private UcTicket ucTicket7;
        private UcTicket ucTicket6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem tsmHistory;
        private System.Windows.Forms.ToolStripMenuItem tsmExport;
    }
}

