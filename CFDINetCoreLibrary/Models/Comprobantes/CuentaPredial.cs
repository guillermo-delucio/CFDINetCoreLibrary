using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Comprobantes
{
    public class CuentaPredial
    {
        [XmlAttribute("Numero")]
        public string numero { get; set; }
    }
}
