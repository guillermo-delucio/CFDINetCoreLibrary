using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class JubilacionPensionRetiro
    {
        [XmlAttribute("TotalUnaExhibicion")]
        public string totalUnaExhibicion { get; set; }

        [XmlAttribute("TotalParcialidad")]
        public string totalParcialidad { get; set; }

        [XmlAttribute("MontoDiario")]
        public string montoDiario { get; set; }

        [XmlAttribute("IngresoAcumulable")]
        public string ingresoAcumulable { get; set; }

        [XmlAttribute("IngresoNoAcumulable")]
        public string ingresoNoAcumulable { get; set; }
    }
}
