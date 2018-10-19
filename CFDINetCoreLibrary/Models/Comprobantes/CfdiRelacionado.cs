using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Comprobantes
{
    public class CfdiRelacionado
    {
        [XmlAttribute("UUID")]
        public string uuid { get; set; }
    }
}
