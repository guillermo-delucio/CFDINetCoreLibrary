using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Comprobantes
{
    public class Retencion
    {
        [XmlAttribute("Importe")]
        public string importe { get; set; }

        [XmlAttribute("TasaOCuota")]
        public string tasaOCuota { get; set; }

        [XmlAttribute("Impuesto")]
        public string impuesto { get; set; }

        [XmlAttribute("TipoFactor")]
        public string tipoFactor { get; set; }

        [XmlAttribute("Base")]
        public string baseImpuesto { get; set; }
    }
}
