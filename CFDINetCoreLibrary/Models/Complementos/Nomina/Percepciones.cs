using System.Collections.Generic;
using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class Percepciones
    {
        [XmlAttribute("TotalSueldos")]
        public string totalSueldos { get; set; }

        [XmlAttribute("TotalSeparacionIndemnizacion")]
        public string totalSeparacionIndemnizacion { get; set; }

        [XmlAttribute("TotalJubilacionPensionRetiro")]
        public string totalJubilacionPensionRetiro { get; set; }

        [XmlAttribute("TotalGravado")]
        public string totalGravado { get; set; }

        [XmlAttribute("TotalExento")]
        public string totalExento { get; set; }

        [XmlElement("Percepcion")]
        public List<Percepcion> percepciones { get; set; }

        [XmlElement("JubilacionPensionRetiro")]
        public List<JubilacionPensionRetiro> jubilacionesPensionesRetiros { get; set; }

        [XmlElement("SeparacionIndemnizacion")]
        public List<SeparacionIndemnizacion> separacionesIndemnizaciones { get; set; }

        public Percepciones()
        {
            percepciones = new List<Percepcion>();
        }
    }
}
