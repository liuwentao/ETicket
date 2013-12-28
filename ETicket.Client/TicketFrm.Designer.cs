using System.Windows.Forms;

namespace ETicket.Client
{
    partial class TicketFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtGrid = new System.Windows.Forms.DataGridView();
            this.cell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onwer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limitdegree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limitFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastprint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.current = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLastPrint = new System.Windows.Forms.Label();
            this.cmbBuild = new System.Windows.Forms.ComboBox();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dtGrid);
            this.groupBox3.Location = new System.Drawing.Point(13, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(844, 351);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "电费明细";
            // 
            // dtGrid
            // 
            this.dtGrid.AllowUserToAddRows = false;
            this.dtGrid.AllowUserToDeleteRows = false;
            this.dtGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cell,
            this.onwer,
            this.userType,
            this.limitdegree,
            this.limitFee,
            this.lastMonth,
            this.lastprint,
            this.current,
            this.price,
            this.diff,
            this.pub,
            this.amount});
            this.dtGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGrid.Location = new System.Drawing.Point(3, 17);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.RowHeadersVisible = false;
            this.dtGrid.RowTemplate.Height = 23;
            this.dtGrid.Size = new System.Drawing.Size(838, 331);
            this.dtGrid.TabIndex = 1;
            this.dtGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrid_CellEndEdit);
            // 
            // cell
            // 
            this.cell.DataPropertyName = "cell";
            this.cell.HeaderText = "单元";
            this.cell.Name = "cell";
            this.cell.ReadOnly = true;
            // 
            // onwer
            // 
            this.onwer.DataPropertyName = "owner";
            this.onwer.HeaderText = "业主";
            this.onwer.Name = "onwer";
            this.onwer.ReadOnly = true;
            // 
            // userType
            // 
            this.userType.DataPropertyName = "usertype";
            this.userType.HeaderText = "用户类型";
            this.userType.Name = "userType";
            this.userType.ReadOnly = true;
            // 
            // limitdegree
            // 
            this.limitdegree.DataPropertyName = "limitdegree";
            this.limitdegree.HeaderText = "阶梯额度";
            this.limitdegree.Name = "limitdegree";
            this.limitdegree.ReadOnly = true;
            this.limitdegree.Visible = false;
            // 
            // limitFee
            // 
            this.limitFee.DataPropertyName = "limitFee";
            this.limitFee.HeaderText = "阶梯电价";
            this.limitFee.Name = "limitFee";
            this.limitFee.Visible = false;
            // 
            // lastMonth
            // 
            this.lastMonth.DataPropertyName = "last";
            this.lastMonth.HeaderText = "上月";
            this.lastMonth.Name = "lastMonth";
            // 
            // lastprint
            // 
            this.lastprint.DataPropertyName = "lastprint";
            this.lastprint.HeaderText = "上次录入时间";
            this.lastprint.Name = "lastprint";
            // 
            // current
            // 
            this.current.DataPropertyName = "current";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            this.current.DefaultCellStyle = dataGridViewCellStyle1;
            this.current.HeaderText = "本月";
            this.current.Name = "current";
            this.current.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "电价";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // diff
            // 
            this.diff.DataPropertyName = "diff";
            this.diff.HeaderText = "差额";
            this.diff.Name = "diff";
            this.diff.ReadOnly = true;
            // 
            // pub
            // 
            this.pub.DataPropertyName = "public";
            this.pub.HeaderText = "公摊";
            this.pub.Name = "pub";
            this.pub.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            this.amount.HeaderText = "金额";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(12, 439);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(845, 43);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(544, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "打印";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(147, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLastPrint);
            this.groupBox1.Controls.Add(this.cmbBuild);
            this.groupBox1.Controls.Add(this.cmbArea);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(844, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "条件";
            // 
            // lblLastPrint
            // 
            this.lblLastPrint.AutoSize = true;
            this.lblLastPrint.Location = new System.Drawing.Point(345, 24);
            this.lblLastPrint.Name = "lblLastPrint";
            this.lblLastPrint.Size = new System.Drawing.Size(23, 12);
            this.lblLastPrint.TabIndex = 6;
            this.lblLastPrint.Text = "...";
            // 
            // cmbBuild
            // 
            this.cmbBuild.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuild.FormattingEnabled = true;
            this.cmbBuild.Location = new System.Drawing.Point(206, 17);
            this.cmbBuild.Name = "cmbBuild";
            this.cmbBuild.Size = new System.Drawing.Size(121, 20);
            this.cmbBuild.TabIndex = 5;
            this.cmbBuild.SelectedIndexChanged += new System.EventHandler(this.cmbBuild_SelectedIndexChanged);
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(44, 18);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(121, 20);
            this.cmbArea.TabIndex = 4;
            this.cmbArea.SelectedIndexChanged += new System.EventHandler(this.cmbArea_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "楼号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "小区";
            // 
            // TicketFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 494);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TicketFrm";
            this.Text = "电费填单";
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBuild;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtGrid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn public1;
        private Label lblLastPrint;
        private DataGridViewTextBoxColumn cell;
        private DataGridViewTextBoxColumn onwer;
        private DataGridViewTextBoxColumn userType;
        private DataGridViewTextBoxColumn limitdegree;
        private DataGridViewTextBoxColumn limitFee;
        private DataGridViewTextBoxColumn lastMonth;
        private DataGridViewTextBoxColumn lastprint;
        private DataGridViewTextBoxColumn current;
        private DataGridViewTextBoxColumn price;
        private DataGridViewTextBoxColumn diff;
        private DataGridViewTextBoxColumn pub;
        private DataGridViewTextBoxColumn amount;
    }
}