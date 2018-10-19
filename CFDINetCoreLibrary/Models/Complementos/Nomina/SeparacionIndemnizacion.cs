using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class SeparacionIndemnizacion
    {
        [XmlAttribute("TotalPagado")]
        public string totalPagado { get; set; }

        [XmlAttribute("NumAñosServicio")]
        public string numeroAniosServicio { get; set; }

        [XmlAttribute("UltimoSueldoMensOrd")]
        public string ultimoSueldoMensualOrdinario { get; set; }

        [XmlAttribute("IngresoAcumulable")]
        public string ingresoAcumulable { get; set; }

        [XmlAttribute("IngresoNoAcumulable")]
        public string ingresoNoAcumulable { get; set; }
    }
}
