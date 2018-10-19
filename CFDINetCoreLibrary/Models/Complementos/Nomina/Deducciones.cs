using System.Collections.Generic;
using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class Deducciones
    {
        [XmlAttribute("TotalOtrasDeducciones")]
        public string totalOtrasDeducciones { get; set; }

        [XmlAttribute("TotalImpuestosRetenidos")]
        public string totalImpuestosRetenidos { get; set; }

        [XmlElement("Deduccion")]
        public List<Deduccion> deducciones { get; set; }

        public Deducciones()
        {
            deducciones = new List<Deduccion>();
        }
    }
}
