using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Comprobantes
{
    public class Emisor
    {
        [XmlAttribute("Nombre")]
        public string nombre { get; set; }

        [XmlAttribute("Rfc")]
        public string rfc { get; set; }

        [XmlAttribute("RegimenFiscal")]
        public string regimenFiscal { get; set; }
    }
}
