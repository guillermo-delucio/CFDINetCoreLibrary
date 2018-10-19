using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class Deduccion
    {
        [XmlAttribute("TipoDeduccion")]
        public string tipoDeduccion { get; set; }

        [XmlAttribute("Clave")]
        public string clave { get; set; }

        [XmlAttribute("Concepto")]
        public string concepto { get; set; }

        [XmlAttribute("Importe")]
        public string importe { get; set; }
    }
}
