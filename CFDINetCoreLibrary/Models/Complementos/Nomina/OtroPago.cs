using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class OtroPago
    {
        [XmlAttribute("TipoOtroPago")]
        public string tipoOtroPago { get; set; }

        [XmlAttribute("Clave")]
        public string clave { get; set; }

        [XmlAttribute("Concepto")]
        public string concepto { get; set; }

        [XmlAttribute("Importe")]
        public string importe { get; set; }

        [XmlElement("SubsidioAlEmpleo")]
        public SubsidioAlEmpleo subsidioAlEmpleo { get; set; }

        [XmlElement("CompensacionSaldosAFavor")]
        public CompensacionSaldosAFavor compensacionSaldosAFavor { get; set; }
    }
}
