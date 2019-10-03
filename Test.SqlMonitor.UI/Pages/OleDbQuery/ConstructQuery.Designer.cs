namespace Test.SqlMonitor.UI.Pages.OleDbQuery
{
    partial class ConstructQuery
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
            this.pageSectionLabel = new Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel();
            this.rtbQuery = new System.Windows.Forms.RichTextBox();
            this.lbQuery = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lbServerName = new System.Windows.Forms.Label();
            this.lbDatabaseName = new System.Windows.Forms.Label();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.iucQueryTimeout = new Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.IntervalUnitControl();
            this.lbQueryTimeout = new System.Windows.Forms.Label();
            this.lbNumSamples = new System.Windows.Forms.Label();
            this.numNumSamples = new System.Windows.Forms.NumericUpDown();
            this.btnSelectDatabaseName = new System.Windows.Forms.Button();
            this.btnSelectServerName = new System.Windows.Forms.Button();
            this.cbRunAsMode = new System.Windows.Forms.CheckBox();
            this.cmbProvider = new System.Windows.Forms.ComboBox();
            this.lbProvider = new System.Windows.Forms.Label();
            this.btnRunTestTask = new System.Windows.Forms.Button();
            this.bgwRunTestTask = new System.ComponentModel.BackgroundWorker();
            this.lblConnectionStringOptions = new System.Windows.Forms.Label();
            this.txtConnectionStringOptions = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numNumSamples)).BeginInit();
            this.SuspendLayout();
            // 
            // pageSectionLabel
            // 
            this.pageSectionLabel.AutoSize = true;
            this.pageSectionLabel.BackColor = System.Drawing.Color.Transparent;
            this.pageSectionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.pageSectionLabel.Location = new System.Drawing.Point(3, 9);
            this.pageSectionLabel.MinimumSize = new System.Drawing.Size(244, 0);
            this.pageSectionLabel.Name = "pageSectionLabel";
            this.pageSectionLabel.Size = new System.Drawing.Size(244, 18);
            this.pageSectionLabel.TabIndex = 10;
            this.pageSectionLabel.Text = "Sql connection and query";
            this.pageSectionLabel.UseCompatibleTextRendering = true;
            // 
            // rtbQuery
            // 
            this.rtbQuery.AcceptsTab = true;
            this.rtbQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbQuery.Location = new System.Drawing.Point(14, 235);
            this.rtbQuery.Name = "rtbQuery";
            this.rtbQuery.Size = new System.Drawing.Size(436, 169);
            this.rtbQuery.TabIndex = 11;
            this.rtbQuery.Text = "";
            this.rtbQuery.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // lbQuery
            // 
            this.lbQuery.AutoSize = true;
            this.lbQuery.Location = new System.Drawing.Point(11, 219);
            this.lbQuery.Name = "lbQuery";
            this.lbQuery.Size = new System.Drawing.Size(38, 13);
            this.lbQuery.TabIndex = 12;
            this.lbQuery.Text = "Query:";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(14, 57);
            this.txtServerName.MaxLength = 300;
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(203, 20);
            this.txtServerName.TabIndex = 13;
            this.txtServerName.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // lbServerName
            // 
            this.lbServerName.AutoSize = true;
            this.lbServerName.Location = new System.Drawing.Point(11, 40);
            this.lbServerName.Name = "lbServerName";
            this.lbServerName.Size = new System.Drawing.Size(41, 13);
            this.lbServerName.TabIndex = 14;
            this.lbServerName.Text = "Server:";
            // 
            // lbDatabaseName
            // 
            this.lbDatabaseName.AutoSize = true;
            this.lbDatabaseName.Location = new System.Drawing.Point(255, 40);
            this.lbDatabaseName.Name = "lbDatabaseName";
            this.lbDatabaseName.Size = new System.Drawing.Size(56, 13);
            this.lbDatabaseName.TabIndex = 16;
            this.lbDatabaseName.Text = "Database:";
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(258, 57);
            this.txtDatabaseName.MaxLength = 300;
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(166, 20);
            this.txtDatabaseName.TabIndex = 15;
            this.txtDatabaseName.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // iucQueryTimeout
            // 
            this.iucQueryTimeout.BackColor = System.Drawing.Color.Transparent;
            this.iucQueryTimeout.EnforceLimits = true;
            this.iucQueryTimeout.IntervalInBaseUnit = 60;
            this.iucQueryTimeout.Location = new System.Drawing.Point(14, 101);
            this.iucQueryTimeout.Margin = new System.Windows.Forms.Padding(0);
            this.iucQueryTimeout.MaxValueInBaseUnit = 2147483647;
            this.iucQueryTimeout.MinValueInBaseUnit = 1;
            this.iucQueryTimeout.Name = "iucQueryTimeout";
            this.iucQueryTimeout.Size = new System.Drawing.Size(203, 21);
            this.iucQueryTimeout.TabIndex = 17;
            // 
            // lbQueryTimeout
            // 
            this.lbQueryTimeout.AutoSize = true;
            this.lbQueryTimeout.Location = new System.Drawing.Point(11, 85);
            this.lbQueryTimeout.Name = "lbQueryTimeout";
            this.lbQueryTimeout.Size = new System.Drawing.Size(75, 13);
            this.lbQueryTimeout.TabIndex = 18;
            this.lbQueryTimeout.Text = "Query timeout:";
            // 
            // lbNumSamples
            // 
            this.lbNumSamples.AutoSize = true;
            this.lbNumSamples.Location = new System.Drawing.Point(255, 85);
            this.lbNumSamples.Name = "lbNumSamples";
            this.lbNumSamples.Size = new System.Drawing.Size(100, 13);
            this.lbNumSamples.TabIndex = 19;
            this.lbNumSamples.Text = "Number of samples:";
            // 
            // numNumSamples
            // 
            this.numNumSamples.Location = new System.Drawing.Point(258, 102);
            this.numNumSamples.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numNumSamples.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNumSamples.Name = "numNumSamples";
            this.numNumSamples.Size = new System.Drawing.Size(69, 20);
            this.numNumSamples.TabIndex = 20;
            this.numNumSamples.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSelectDatabaseName
            // 
            this.btnSelectDatabaseName.Location = new System.Drawing.Point(428, 56);
            this.btnSelectDatabaseName.Name = "btnSelectDatabaseName";
            this.btnSelectDatabaseName.Size = new System.Drawing.Size(22, 22);
            this.btnSelectDatabaseName.TabIndex = 21;
            this.btnSelectDatabaseName.Tag = this.txtDatabaseName;
            this.btnSelectDatabaseName.Text = "…";
            this.btnSelectDatabaseName.UseVisualStyleBackColor = true;
            this.btnSelectDatabaseName.Click += new System.EventHandler(this.btnPropertySelector_Click);
            // 
            // btnSelectServerName
            // 
            this.btnSelectServerName.Location = new System.Drawing.Point(220, 56);
            this.btnSelectServerName.Name = "btnSelectServerName";
            this.btnSelectServerName.Size = new System.Drawing.Size(22, 22);
            this.btnSelectServerName.TabIndex = 22;
            this.btnSelectServerName.Tag = this.txtServerName;
            this.btnSelectServerName.Text = "…";
            this.btnSelectServerName.UseVisualStyleBackColor = true;
            this.btnSelectServerName.Click += new System.EventHandler(this.btnPropertySelector_Click);
            // 
            // cbRunAsMode
            // 
            this.cbRunAsMode.AutoSize = true;
            this.cbRunAsMode.Location = new System.Drawing.Point(307, 152);
            this.cbRunAsMode.Name = "cbRunAsMode";
            this.cbRunAsMode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbRunAsMode.Size = new System.Drawing.Size(137, 17);
            this.cbRunAsMode.TabIndex = 23;
            this.cbRunAsMode.Text = "Use Integrated Security";
            this.cbRunAsMode.UseVisualStyleBackColor = true;
            // 
            // cmbProvider
            // 
            this.cmbProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvider.FormattingEnabled = true;
            this.cmbProvider.Location = new System.Drawing.Point(14, 148);
            this.cmbProvider.Name = "cmbProvider";
            this.cmbProvider.Size = new System.Drawing.Size(287, 21);
            this.cmbProvider.TabIndex = 24;
            this.cmbProvider.SelectedIndexChanged += new System.EventHandler(this.cmbProvider_SelectedIndexChanged);
            // 
            // lbProvider
            // 
            this.lbProvider.AutoSize = true;
            this.lbProvider.Location = new System.Drawing.Point(11, 131);
            this.lbProvider.Name = "lbProvider";
            this.lbProvider.Size = new System.Drawing.Size(49, 13);
            this.lbProvider.TabIndex = 25;
            this.lbProvider.Text = "Provider:";
            // 
            // btnRunTestTask
            // 
            this.btnRunTestTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunTestTask.Location = new System.Drawing.Point(366, 408);
            this.btnRunTestTask.Name = "btnRunTestTask";
            this.btnRunTestTask.Size = new System.Drawing.Size(84, 23);
            this.btnRunTestTask.TabIndex = 26;
            this.btnRunTestTask.Text = "Test query";
            this.btnRunTestTask.UseVisualStyleBackColor = true;
            this.btnRunTestTask.Click += new System.EventHandler(this.btnRunTestTask_Click);
            // 
            // bgwRunTestTask
            // 
            this.bgwRunTestTask.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRunTestTask_DoWork);
            this.bgwRunTestTask.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRunTestTask_RunWorkerCompleted);
            // 
            // lblConnectionStringOptions
            // 
            this.lblConnectionStringOptions.AutoSize = true;
            this.lblConnectionStringOptions.Location = new System.Drawing.Point(11, 177);
            this.lblConnectionStringOptions.Name = "lblConnectionStringOptions";
            this.lblConnectionStringOptions.Size = new System.Drawing.Size(195, 13);
            this.lblConnectionStringOptions.TabIndex = 27;
            this.lblConnectionStringOptions.Text = "Additional connection string parameters:";
            // 
            // txtConnectionStringOptions
            // 
            this.txtConnectionStringOptions.Location = new System.Drawing.Point(14, 193);
            this.txtConnectionStringOptions.MaxLength = 400;
            this.txtConnectionStringOptions.Name = "txtConnectionStringOptions";
            this.txtConnectionStringOptions.Size = new System.Drawing.Size(436, 20);
            this.txtConnectionStringOptions.TabIndex = 28;
            // 
            // ConstructQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtConnectionStringOptions);
            this.Controls.Add(this.lblConnectionStringOptions);
            this.Controls.Add(this.btnRunTestTask);
            this.Controls.Add(this.lbProvider);
            this.Controls.Add(this.cmbProvider);
            this.Controls.Add(this.cbRunAsMode);
            this.Controls.Add(this.btnSelectServerName);
            this.Controls.Add(this.btnSelectDatabaseName);
            this.Controls.Add(this.numNumSamples);
            this.Controls.Add(this.lbNumSamples);
            this.Controls.Add(this.iucQueryTimeout);
            this.Controls.Add(this.lbQueryTimeout);
            this.Controls.Add(this.lbDatabaseName);
            this.Controls.Add(this.txtDatabaseName);
            this.Controls.Add(this.lbServerName);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.lbQuery);
            this.Controls.Add(this.rtbQuery);
            this.Controls.Add(this.pageSectionLabel);
            this.Name = "ConstructQuery";
            this.Size = new System.Drawing.Size(460, 435);
            ((System.ComponentModel.ISupportInitialize)(this.numNumSamples)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel pageSectionLabel;
        private System.Windows.Forms.RichTextBox rtbQuery;
        private System.Windows.Forms.Label lbQuery;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label lbServerName;
        private System.Windows.Forms.Label lbDatabaseName;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.IntervalUnitControl iucQueryTimeout;
        private System.Windows.Forms.Label lbQueryTimeout;
        private System.Windows.Forms.Label lbNumSamples;
        private System.Windows.Forms.NumericUpDown numNumSamples;
        private System.Windows.Forms.Button btnSelectServerName;
        private System.Windows.Forms.Button btnSelectDatabaseName;
        private System.Windows.Forms.CheckBox cbRunAsMode;
        private System.Windows.Forms.ComboBox cmbProvider;
        private System.Windows.Forms.Label lbProvider;
        private System.Windows.Forms.Button btnRunTestTask;
        private System.ComponentModel.BackgroundWorker bgwRunTestTask;
        private System.Windows.Forms.Label lblConnectionStringOptions;
        private System.Windows.Forms.TextBox txtConnectionStringOptions;
    }
}
