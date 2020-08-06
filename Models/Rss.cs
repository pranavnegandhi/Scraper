using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Notadesigner.Scraper.Models
{
    [GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(ElementName = "rss", Namespace = "", IsNullable = false)]
    public partial class Rss
    {


        [XmlElement("channel", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Channel[] Channel
        {
            get;
            set;
        }


        [XmlAttribute("version")]
        public string Version
        {
            get;
            set;
        }
    }

    [GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class NewDataSet
    {

        [XmlElement("rss")]
        public Rss[] Items
        {
            get;
            set;
        }
    }
}