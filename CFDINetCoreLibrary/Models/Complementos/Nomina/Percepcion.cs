using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class Percepcion
    {
        [XmlAttribute("TipoPercepcion")]
        public string tipoPercepcion { get; set; }

        [XmlAttribute("Clave")]
        public string clave { get; set; }

        [XmlAttribute("Concepto")]
        public string concepto { get; set; }

        [XmlAttribute("ImporteGravado")]
        public string importeGravado { get; set; }

        [XmlAttribute("ImporteExento")]
        public string importeExento { get; set; }

        [XmlElement("AccionesOTitulos")]
        public AccionesOTitulos accionesOTitulos { get; set; }

        [XmlElement("HorasExtra")]
        public HorasExtra horasExtra { get; set; }
    }
}
