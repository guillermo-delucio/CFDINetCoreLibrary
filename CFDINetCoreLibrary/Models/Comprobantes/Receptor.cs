using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Comprobantes
{
    public class Receptor
    {
        [XmlAttribute("Nombre")]
        public string nombre { get; set; }

        [XmlAttribute("Rfc")]
        public string rfc { get; set; }

        [XmlAttribute("UsoCFDI")]
        public string usoCfdi { get; set; }

        [XmlAttribute("ResidenciaFiscal")]
        public string residenciaFiscal { get; set; }

        [XmlAttribute("NumRegIdTrib")]
        public string numRegIdTrib { get; set; }
    }
}
