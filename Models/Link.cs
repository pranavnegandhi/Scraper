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
    public partial class Link
    {

        [XmlAttribute("href")]
        public string Href
        {
            get;
            set;
        }


        [XmlAttribute("rel")]
        public string Rel
        {
            get;
            set;
        }


        [XmlAttribute("type")]
        public string Type
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