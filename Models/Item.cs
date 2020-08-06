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
    public partial class Item
    {

        [XmlElement(ElementName = "title", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Title
        {
            get;
            set;
        }


        [XmlElement(ElementName = "link", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Link
        {
            get;
            set;
        }


        [XmlElement(ElementName = "creator", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Creator
        {
            get;
            set;
        }


        [XmlElement(ElementName = "pubDate", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PubDate
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


        [XmlElement("category", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public Category[] Category
        {
            get;
            set;
        }


        [XmlElement("guid", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public ItemGuid[] Guid
        {
            get;
            set;
        }
    }
}