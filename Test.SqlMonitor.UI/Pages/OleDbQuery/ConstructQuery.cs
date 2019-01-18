using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Common;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls;
using Microsoft.EnterpriseManagement.UI;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Test.SqlMonitor.UI.Code;

namespace Test.SqlMonitor.UI.Pages.OleDbQuery
{
    public partial class ConstructQuery : UIPage
    {
        private const string runAsImpersonationProfileString = "Integrated Security=SSPI";
        private const string runAsSimpleProfileName = "Test.SqlMonitor.MP.SecureReference.OleDbQuery.SimpleRunAsProfile";
        private const string runAsSimpleProfileString = "User Id=$RunAs[Name=\"{0}\"]/UserName$;Password=$RunAs[Name=\"{0}\"]/Password$";

        private bool pageLock;
        private bool PageLock { set { pageLock = value; ValidatePage(); } }

        private string ServerName { get { return (txtServerName.Text ?? string.Empty).Trim(); } set { txtServerName.Text = value; } }
        private string DatabaseName { get { return (txtDatabaseName.Text ?? string.Empty).Trim(); } set { txtDatabaseName.Text = value; } }
        private int QueryTimeout { get { return iucQueryTimeout.IntervalInBaseUnit; } set { iucQueryTimeout.IntervalInBaseUnit = value; } }
        private int NumSamples { get { return Convert.ToInt32(numNumSamples.Value); } set { numNumSamples.Value = value; } }
        private string Query { get { return (rtbQuery.Text ?? string.Empty).Trim(); } set { rtbQuery.Text = value; } }
        private string RunAsMode
        {
            get
            {
                return cbRunAsMode.Checked ?
                    runAsImpersonationProfileString :
                    string.Format(runAsSimpleProfileString, GetAliasedName(GetRunAsProfile(runAsSimpleProfileName)));
            }
            set
            {
                cbRunAsMode.Checked = value?.Equals(runAsImpersonationProfileString) ?? true;
            }
        }
        private string ProviderName
        {
            get
            {
                string text = cmbProvider.SelectedItem as string;
                if (text == null || !providers.ContainsKey(text))
                {
                    return null;
                }
                return providers[text];
            }
            set
            {
                if (value == null || !providers.ContainsValue(value))
                {
                    cmbProvider.SelectedIndex = -1;
                }
                else
                {
                    foreach (var item in providers)
                    {
                        if (item.Value.Equals(value))
                        {
                            cmbProvider.SelectedItem = item.Key;
                            break;
                        }
                    }
                }  
            }
        }

        private Dictionary<string, string> providers;
        private PropertySelector paramsSelector = new PropertySelector();

        public ConstructQuery()
        {
            InitializeComponent();
        }

        #region Overrides
        public override void LoadPageConfig()
        {
            PopulateProvidersComboBox();

            if (IsCreationMode)
            {
                if (!string.IsNullOrEmpty(PageParamsXml))
                {
                    var config = (ConstructQueryConfig)XmlHelper.Deserialize(PageParamsXml, typeof(ConstructQueryConfig), true);
                    SetControls(config);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(InputConfigurationXml))
                    throw new ArgumentNullException();

                var config = (ConstructQueryConfig)XmlHelper.Deserialize(InputConfigurationXml, typeof(ConstructQueryConfig), true);
                SetControls(config);
            }

            if (!iucQueryTimeout.LoadControl())
                throw new ArgumentException();

            InitializeForTarget();            
            paramsSelector.PropertyParameterChanged += OnPropertyParameterChanged;
            ValidatePage();
        }

        public override bool SavePageConfig()
        {
            if (!ValidatePage() || !iucQueryTimeout.SaveControl()) { return false; }

            StringBuilder buffer = new StringBuilder();
            XmlWriter xmlWriter = XmlHelper.CreateXmlWriter(buffer);
            xmlWriter.WriteElementString("ServerName", ServerName);
            xmlWriter.WriteElementString("DatabaseName", DatabaseName);
            xmlWriter.WriteElementString("ProviderName", ProviderName);
            xmlWriter.WriteStartElement("Query");
            xmlWriter.WriteCData(Query);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteElementString("QueryTimeout", QueryTimeout.ToString());
            if (numNumSamples.Enabled) { xmlWriter.WriteElementString("NumSamples", NumSamples.ToString()); }
            xmlWriter.WriteElementString("RunAsMode", RunAsMode);
            xmlWriter.Close();
            OutputConfigurationXml = buffer.ToString();

            return true;
        }

        protected override void PageContextObjectChanged(ObjectChangedEventArgs args)
        {
            InitializeForTarget();
            base.PageContextObjectChanged(args);
        }

        #endregion

        #region Methods
        private bool ValidatePage()
        {
            if (pageLock)
            {
                return IsConfigValid = false;
            }

            if (string.IsNullOrEmpty(ServerName))
            {
                return IsConfigValid = false;
            }

            if (string.IsNullOrEmpty(DatabaseName))
            {
                return IsConfigValid = false;
            }

            if (string.IsNullOrEmpty(Query))
            {
                return IsConfigValid = false;
            }

            if (string.IsNullOrEmpty(ProviderName))
            {
                return IsConfigValid = false;
            }

            return IsConfigValid = true;
        }

        private void InitializeForTarget()
        {
            paramsSelector.Initialize(this.TargetedType, this.DestinationManagementPack);
        }

        private ManagementPackSecureReference GetRunAsProfile(string profileName)
        {
            var runAsSimpleAccount = this.ManagementGroup.Security.GetSecureReferences(
                new ManagementPackSecureReferenceCriteria(
                    string.Format("Name Matches '{0}'", profileName)));
            return runAsSimpleAccount.Count > 0 ? runAsSimpleAccount[0] : throw new ArgumentNullException("Run as account not found");
        }

        private void ShowProperties(Button button, PropertySelector selector)
        {
            Point screen = this.PointToScreen(new Point(button.Right, button.Top));
            selector.ShowProperties(screen);
        }

        private void SetControls(ConstructQueryConfig config)
        {
            ServerName = config.ServerName;
            DatabaseName = config.DatabaseName;
            ProviderName = config.ProviderName;
            QueryTimeout = config.QueryTimeout;
            if (config.NumSamples == 0)
            {
                numNumSamples.Enabled = false;
            }
            else
            {
                NumSamples = config.NumSamples;
            }            
            Query = config.Query;
            RunAsMode = config.RunAsMode;            
        }

        private void PopulateProvidersComboBox()
        {
            providers = new Dictionary<string, string>();
            OleDbDataReader rootEnumerator = OleDbEnumerator.GetRootEnumerator();
            if (rootEnumerator != null)
            {
                foreach (DbDataRecord dbDataRecord in rootEnumerator)
                {
                    string text = dbDataRecord[2] as string;
                    providers[text] = (dbDataRecord[0] as string);
                    int num = (int)dbDataRecord[3];
                    if ((!cmbProvider.Items.Contains(text) && 1 == num) || 3 == num)
                    {
                        cmbProvider.Items.Add(text);
                    }
                }
            }
        }

        private void DisplayTaskXmlModal(string xml)
        {
            XmlDocument doc = new XmlDocument();            
            try
            {
                doc.LoadXml(xml);
                doc.InsertBefore(doc.CreateXmlDeclaration("1.0", string.Empty, string.Empty), doc.DocumentElement);
            }
            catch
            {
                MessageBox.Show("Invalid xml: " + xml, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Form form = new Form())
            {
                form.Width = 600;
                form.Height = 500;
                form.MinimizeBox = false;
                WebBrowser webBrowser = new WebBrowser();
                webBrowser.Dock = DockStyle.Fill;
                webBrowser.IsWebBrowserContextMenuEnabled = false;
                webBrowser.AllowNavigation = false;
                webBrowser.AllowWebBrowserDrop = false;
                webBrowser.DocumentText = doc.OuterXml;
                form.Controls.Add(webBrowser);
                form.ShowDialog();
            }
        }
        #endregion

        #region EventHanders
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            ValidatePage();
        }

        private void cmbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidatePage();
        }

        private void OnPropertyParameterChanged(object sender, PropertySelector.PropertyEventArgs e)
        {
            var targetTextBox = (TextBox)this.paramsSelector.Tag;
            targetTextBox.AppendText(e.PropertyParameter);
        }

        private void btnPropertySelector_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            this.paramsSelector.Tag = button.Tag;
            ShowProperties((Button)sender, this.paramsSelector);
        }

        private void btnRunTestTask_Click(object sender, EventArgs e)
        {
            if (!ValidatePage()) { return; }

            btnRunTestTask.Enabled = false;
            btnRunTestTask.Text = "Please wait";
            PageLock = true;

            bgwRunTestTask.RunWorkerAsync(
                (object)new string[]
                {
                    string.Format("Provider={0};Data Source={1};Initial Catalog={2};Integrated Security=SSPI",
                    ProviderName, ServerName, DatabaseName),
                    Query,
                    "60"
                });
        }

        private void bgwRunTestTask_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            TaskRunnerHelper taskRunner = new TaskRunnerHelper(this.ManagementGroup);
            var parameters = (string[])e.Argument;
            var result = taskRunner.RunTestTask(
                parameters[0], parameters[1], int.Parse(parameters[2]));
            e.Result = result;
        }

        private void bgwRunTestTask_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    MessageBox.Show(
                        e.Error.Message,
                        "Failed to run test task",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                var result = (Microsoft.EnterpriseManagement.Runtime.TaskResult)e.Result;
                if (result == null || result.Status != Microsoft.EnterpriseManagement.Runtime.TaskStatus.Succeeded)
                {
                    MessageBox.Show(
                        result?.ErrorMessage ?? "Unspecified error",
                        "Failed to complete test task",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    DisplayTaskXmlModal(result.Output);
                }
            }
            finally
            {
                PageLock = false;
                btnRunTestTask.Text = "Test query";
                btnRunTestTask.Enabled = true;
            }
        }
        #endregion
    }
}
