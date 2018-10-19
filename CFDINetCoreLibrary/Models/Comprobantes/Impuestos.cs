using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Comprobantes
{
    public class Impuestos
    {
        [XmlAttribute("TotalImpuestosTrasladados")]
        public string totalImpuestosTrasladados { get; set; }

        [XmlAttribute("TotalImpuestosRetenidos")]
        public string totalImpuestosRetenidos { get; set; }

        [XmlElement("Traslados")]
        public Traslados traslados { get; set; }

        [XmlElement("Retenciones")]
        public Retenciones retenciones { get; set; }
    }
}
