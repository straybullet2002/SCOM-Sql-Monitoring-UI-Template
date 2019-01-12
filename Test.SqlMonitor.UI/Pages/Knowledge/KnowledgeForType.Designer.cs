namespace Test.SqlMonitor.UI.Pages.Knowledge
{
    partial class KnowledgeForType
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
            this.knowledgeControl = new Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.KnowledgeControl();
            this.SuspendLayout();
            // 
            // knowledgeControl
            // 
            this.knowledgeControl.AllowWebBrowserDrop = false;
            this.knowledgeControl.ArticleManagementPack = null;
            this.knowledgeControl.DefaultContent = "";
            this.knowledgeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knowledgeControl.DoItNowEnabled = true;
            this.knowledgeControl.EnableCustomHandlers = true;
            this.knowledgeControl.Entity = null;
            this.knowledgeControl.Group = null;
            this.knowledgeControl.IsWebBrowserContextMenuEnabled = false;
            this.knowledgeControl.KnowledgeId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.knowledgeControl.KnowledgeType = Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.KnowledgeType.Any;
            this.knowledgeControl.Location = new System.Drawing.Point(0, 0);
            this.knowledgeControl.Name = "knowledgeControl";
            this.knowledgeControl.Size = new System.Drawing.Size(480, 403);
            this.knowledgeControl.TabIndex = 0;
            // 
            // KnowledgeForType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.knowledgeControl);
            this.HeaderText = "Help";
            this.Name = "KnowledgeForType";
            this.NavigationText = "Help";
            this.TabName = "Help";
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.KnowledgeControl knowledgeControl;
    }
}
