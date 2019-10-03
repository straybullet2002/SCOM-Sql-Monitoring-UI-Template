using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Test.SqlMonitor.UI.Pages.OleDbQuery
{
    [Serializable, XmlType(AnonymousType = true), XmlRoot(Namespace = "", IsNullable = false)]
    public class ConstructQueryConfig
    {
        //[XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string ProviderName { get; set; }
        public string ConnectionStringOptions { get; set; }
        public string Query { get; set; }
        public int QueryTimeout { get; set; }
        public int NumSamples { get; set; } // Pass zero value to disable control
        public string RunAsMode { get; set; }        
    }
}
