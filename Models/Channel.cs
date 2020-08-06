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
    public partial class Channel
    {

        [XmlElement(ElementName = "title", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Title
        {
            get;
            set;
        }


        [XmlElement(ElementName = "description", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Description
        {
            get;
            set;
        }


        [XmlElement(ElementName = "lastBuildDate", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LastBuildDate
        {
            get;
            set;
        }


        [XmlElement(ElementName = "language", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Language
        {
            get;
            set;
        }


        [XmlElement(ElementName = "updatePeriod", Namespace = "http://purl.org/rss/1.0/modules/syndication/")]
        public string UpdatePeriod
        {
            get;
            set;
        }


        [XmlElement(ElementName = "updateFrequency", Namespace = "http://purl.org/rss/1.0/modules/syndication/")]
        public string UpdateFrequency
        {
            get;
            set;
        }


        [XmlElement(ElementName = "generator", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Generator
        {
            get;
            set;
        }


        [XmlElement("link", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public Link Link
        {
            get;
            set;
        }


        [XmlElement("item", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Item[] Items
        {
            get;
            set;
        }
    }
}