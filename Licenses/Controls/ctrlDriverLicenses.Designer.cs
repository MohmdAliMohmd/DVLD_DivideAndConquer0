namespace DVLD_DivideAndConquer.Licenses.Controls
{
    partial class ctrlDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tcDriverLicenses = new System.Windows.Forms.TabControl();
            this.tpLocalLicenses = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLocalLicensesRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLocalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.cmsLocalLicenseHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbInternaionalLicenses = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lblInternaionalLicensesRecords = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvInternaionalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.cmsInterenationalLicenseHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.InternaionalLicenseHistorytoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tcDriverLicenses.SuspendLayout();
            this.tpLocalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).BeginInit();
            this.cmsLocalLicenseHistory.SuspendLayout();
            this.tbInternaionalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternaionalLicensesHistory)).BeginInit();
            this.cmsInterenationalLicenseHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tcDriverLicenses);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1052, 273);
            this.groupBox1.TabIndex = 132;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tcDriverLicenses
            // 
            this.tcDriverLicenses.Controls.Add(this.tpLocalLicenses);
            this.tcDriverLicenses.Controls.Add(this.tbInternaionalLicenses);
            this.tcDriverLicenses.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcDriverLicenses.Location = new System.Drawing.Point(10, 24);
            this.tcDriverLicenses.Name = "tcDriverLicenses";
            this.tcDriverLicenses.SelectedIndex = 0;
            this.tcDriverLicenses.Size = new System.Drawing.Size(1032, 243);
            this.tcDriverLicenses.TabIndex = 131;
            // 
            // tpLocalLicenses
            // 
            this.tpLocalLicenses.BackColor = System.Drawing.SystemColors.Control;
            this.tpLocalLicenses.Controls.Add(this.label1);
            this.tpLocalLicenses.Controls.Add(this.lblLocalLicensesRecords);
            this.tpLocalLicenses.Controls.Add(this.label2);
            this.tpLocalLicenses.Controls.Add(this.dgvLocalLicensesHistory);
            this.tpLocalLicenses.Location = new System.Drawing.Point(4, 34);
            this.tpLocalLicenses.Name = "tpLocalLicenses";
            this.tpLocalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocalLicenses.Size = new System.Drawing.Size(1024, 205);
            this.tpLocalLicenses.TabIndex = 0;
            this.tpLocalLicenses.Text = "Local";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 25);
            this.label1.TabIndex = 135;
            this.label1.Text = "Local Licenses History:";
            // 
            // lblLocalLicensesRecords
            // 
            this.lblLocalLicensesRecords.AutoSize = true;
            this.lblLocalLicensesRecords.Location = new System.Drawing.Point(111, 174);
            this.lblLocalLicensesRecords.Name = "lblLocalLicensesRecords";
            this.lblLocalLicensesRecords.Size = new System.Drawing.Size(28, 25);
            this.lblLocalLicensesRecords.TabIndex = 134;
            this.lblLocalLicensesRecords.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 133;
            this.label2.Text = "# Records:";
            // 
            // dgvLocalLicensesHistory
            // 
            this.dgvLocalLicensesHistory.AllowUserToAddRows = false;
            this.dgvLocalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgvLocalLicensesHistory.AllowUserToResizeRows = false;
            this.dgvLocalLicensesHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicensesHistory.ContextMenuStrip = this.cmsLocalLicenseHistory;
            this.dgvLocalLicensesHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLocalLicensesHistory.Location = new System.Drawing.Point(14, 32);
            this.dgvLocalLicensesHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLocalLicensesHistory.MultiSelect = false;
            this.dgvLocalLicensesHistory.Name = "dgvLocalLicensesHistory";
            this.dgvLocalLicensesHistory.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalLicensesHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalLicensesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalLicensesHistory.Size = new System.Drawing.Size(996, 138);
            this.dgvLocalLicensesHistory.TabIndex = 132;
            this.dgvLocalLicensesHistory.TabStop = false;
            this.dgvLocalLicensesHistory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocalLicensesHistory_CellDoubleClick);
            this.dgvLocalLicensesHistory.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocalLicensesHistory_CellMouseLeave);
            this.dgvLocalLicensesHistory.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLocalLicensesHistory_CellMouseMove);
            // 
            // cmsLocalLicenseHistory
            // 
            this.cmsLocalLicenseHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsLocalLicenseHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.cmsLocalLicenseHistory.Name = "cmsLocalLicenseHistory";
            this.cmsLocalLicenseHistory.Size = new System.Drawing.Size(238, 34);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(237, 30);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // tbInternaionalLicenses
            // 
            this.tbInternaionalLicenses.BackColor = System.Drawing.SystemColors.Control;
            this.tbInternaionalLicenses.Controls.Add(this.label3);
            this.tbInternaionalLicenses.Controls.Add(this.lblInternaionalLicensesRecords);
            this.tbInternaionalLicenses.Controls.Add(this.label5);
            this.tbInternaionalLicenses.Controls.Add(this.dgvInternaionalLicensesHistory);
            this.tbInternaionalLicenses.Location = new System.Drawing.Point(4, 34);
            this.tbInternaionalLicenses.Name = "tbInternaionalLicenses";
            this.tbInternaionalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tbInternaionalLicenses.Size = new System.Drawing.Size(1024, 205);
            this.tbInternaionalLicenses.TabIndex = 1;
            this.tbInternaionalLicenses.Text = "Internaional";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 25);
            this.label3.TabIndex = 139;
            this.label3.Text = "Internaional Licenses History:";
            // 
            // lblInternaionalLicensesRecords
            // 
            this.lblInternaionalLicensesRecords.AutoSize = true;
            this.lblInternaionalLicensesRecords.Location = new System.Drawing.Point(111, 174);
            this.lblInternaionalLicensesRecords.Name = "lblInternaionalLicensesRecords";
            this.lblInternaionalLicensesRecords.Size = new System.Drawing.Size(28, 25);
            this.lblInternaionalLicensesRecords.TabIndex = 138;
            this.lblInternaionalLicensesRecords.Text = "??";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 25);
            this.label5.TabIndex = 137;
            this.label5.Text = "# Records:";
            // 
            // dgvInternaionalLicensesHistory
            // 
            this.dgvInternaionalLicensesHistory.AllowUserToAddRows = false;
            this.dgvInternaionalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgvInternaionalLicensesHistory.AllowUserToResizeRows = false;
            this.dgvInternaionalLicensesHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternaionalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternaionalLicensesHistory.ContextMenuStrip = this.cmsInterenationalLicenseHistory;
            this.dgvInternaionalLicensesHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInternaionalLicensesHistory.Location = new System.Drawing.Point(14, 32);
            this.dgvInternaionalLicensesHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvInternaionalLicensesHistory.MultiSelect = false;
            this.dgvInternaionalLicensesHistory.Name = "dgvInternaionalLicensesHistory";
            this.dgvInternaionalLicensesHistory.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternaionalLicensesHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInternaionalLicensesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternaionalLicensesHistory.Size = new System.Drawing.Size(996, 138);
            this.dgvInternaionalLicensesHistory.TabIndex = 136;
            this.dgvInternaionalLicensesHistory.TabStop = false;
            this.dgvInternaionalLicensesHistory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInternaionalLicensesHistory_CellDoubleClick);
            this.dgvInternaionalLicensesHistory.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInternaionalLicensesHistory_CellMouseLeave);
            this.dgvInternaionalLicensesHistory.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvInternaionalLicensesHistory_CellMouseMove);
            // 
            // cmsInterenationalLicenseHistory
            // 
            this.cmsInterenationalLicenseHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsInterenationalLicenseHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InternaionalLicenseHistorytoolStripMenuItem});
            this.cmsInterenationalLicenseHistory.Name = "cmsLocalLicenseHistory";
            this.cmsInterenationalLicenseHistory.Size = new System.Drawing.Size(238, 34);
            // 
            // InternaionalLicenseHistorytoolStripMenuItem
            // 
            this.InternaionalLicenseHistorytoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.InternaionalLicenseHistorytoolStripMenuItem.Name = "InternaionalLicenseHistorytoolStripMenuItem";
            this.InternaionalLicenseHistorytoolStripMenuItem.Size = new System.Drawing.Size(237, 30);
            this.InternaionalLicenseHistorytoolStripMenuItem.Text = "Show License Info";
            this.InternaionalLicenseHistorytoolStripMenuItem.Click += new System.EventHandler(this.InternaionalLicenseHistorytoolStripMenuItem_Click);
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(1055, 286);
            this.groupBox1.ResumeLayout(false);
            this.tcDriverLicenses.ResumeLayout(false);
            this.tpLocalLicenses.ResumeLayout(false);
            this.tpLocalLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).EndInit();
            this.cmsLocalLicenseHistory.ResumeLayout(false);
            this.tbInternaionalLicenses.ResumeLayout(false);
            this.tbInternaionalLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternaionalLicensesHistory)).EndInit();
            this.cmsInterenationalLicenseHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tcDriverLicenses;
        private System.Windows.Forms.TabPage tpLocalLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLocalLicensesRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLocalLicensesHistory;
        private System.Windows.Forms.TabPage tbInternaionalLicenses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblInternaionalLicensesRecords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvInternaionalLicensesHistory;
        private System.Windows.Forms.ContextMenuStrip cmsInterenationalLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem InternaionalLicenseHistorytoolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsLocalLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
    }
}
