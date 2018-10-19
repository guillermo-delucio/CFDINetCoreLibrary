using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.TimbreFiscal
{
    public class TimbreFiscal
    {
        [XmlAttribute("Version")]
        public string version { get; set; }

        [XmlAttribute("UUID")]
        public string uuid { get; set; }

        [XmlAttribute("FechaTimbrado")]
        public string fechaTimbrado { get; set; }

        [XmlAttribute("SelloCFD")]
        public string selloCfd { get; set; }

        [XmlAttribute("NoCertificadoSAT")]
        public string noCertificadoSat { get; set; }

        [XmlAttribute("SelloSAT")]
        public string selloSat { get; set; }

        [XmlAttribute("RfcProvCertif")]
        public string rfcProvCertif { get; set; }

        [XmlAttribute("Leyenda")]
        public string leyenda { get; set; }
    }
}
