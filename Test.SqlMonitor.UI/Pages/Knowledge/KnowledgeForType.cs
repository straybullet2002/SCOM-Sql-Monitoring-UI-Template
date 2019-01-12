using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Common;
using Microsoft.EnterpriseManagement.UI;
using System.Collections.Generic;

namespace Test.SqlMonitor.UI.Pages.Knowledge
{
    public partial class KnowledgeForType : UIPage
    {
        public KnowledgeForType()
        {
            InitializeComponent();
        }

        public override void LoadPageConfig()
        {
            IsConfigValid = true;
            if (string.IsNullOrEmpty(PageParamsXml))
                return;

            try
            {
                string knowledgeElement = XmlHelper.CreateXPathDocument(PageParamsXml).CreateNavigator().SelectSingleNode("/ElementName").Value;
                var knowledgeArticle = GetKnowledgeArticle(knowledgeElement);
                if (!string.IsNullOrEmpty(knowledgeArticle?.MamlContent))
                {
                    knowledgeControl.ShowMamlContent(knowledgeArticle.MamlContent);
                }
            }
            catch { }
        }

        public override bool SavePageConfig()
        {
            return true;
        }

        protected virtual ManagementPackKnowledgeArticle GetKnowledgeArticle(string elementName)
        {
            ManagementPackKnowledgeArticle knowledgeArticle = null;
            if (this.ManagementGroup != null)
            {
                IList<ManagementPackKnowledgeArticle> articles = this.ManagementGroup.Knowledge.GetKnowledgeArticles(
                    new ManagementPackKnowledgeArticleCriteria(
                        string.Format("ElementName = '{0}'", elementName)));
                if (articles.Count > 0)
                {
                    using (IEnumerator<ManagementPackKnowledgeArticle> enumerator = articles.GetEnumerator())
                    {
                        if (enumerator.MoveNext())
                            knowledgeArticle = enumerator.Current;
                    }
                }
            }
            return knowledgeArticle;
        }

        /*
        protected virtual ManagementPackKnowledgeArticle GetKnowledgeArticle()
        {
            ManagementPackKnowledgeArticle knowledgeArticle = (ManagementPackKnowledgeArticle) null;
            if (this.get_ManagementGroup() != null)
            {
            IList<ManagementPackKnowledgeArticle> policy = ViewHelper.FilterKnowledgeArticlesAccordingToPolicy(this.get_ManagementGroup().Knowledge.GetKnowledgeArticles(this.Element), this.Element.GetManagementPack(), (KnowledgeType) 1);
            if (policy.Count > 0)
            {
                using (IEnumerator<ManagementPackKnowledgeArticle> enumerator = policy.GetEnumerator())
                {
                if (enumerator.MoveNext())
                    knowledgeArticle = enumerator.Current;
                }
            }
            }
            else
            knowledgeArticle = this.Element.GetKnowledgeArticle(CultureInfo.CurrentCulture);
            bool flag = true;
            if (this.get_ManagementGroup() != null)
            flag = this.get_ManagementGroup().Security.IsUserAdministrator() || this.get_ManagementGroup().Security.IsUserAuthor();
            this.SetEditButtonVisible(!this.Element.GetManagementPack().Sealed && flag);
            return knowledgeArticle;
        }
        */
    }
}
