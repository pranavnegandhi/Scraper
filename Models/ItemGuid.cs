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
    public partial class ItemGuid
    {

        [XmlAttribute("isPermaLink")]
        public string IsPermaLink
        {
            get;
            set;
        }


        [XmlText()]
        public string Value
        {
            get;
            set;
        }
    }
}