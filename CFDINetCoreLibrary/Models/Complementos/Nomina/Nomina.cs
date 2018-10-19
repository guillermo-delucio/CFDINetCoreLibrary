using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class Nomina
    {
        [XmlAttribute("Version")]
        public string version { get; set; }

        [XmlAttribute("TipoNomina")]
        public string tipoNomina { get; set; }

        [XmlAttribute("FechaPago")]
        public string fechaPago { get; set; }

        [XmlAttribute("FechaInicialPago")]
        public string fechaInicialPago { get; set; }

        [XmlAttribute("FechaFinalPago")]
        public string fechaFinalPago { get; set; }

        [XmlAttribute("NumDiasPagados")]
        public string numeroDiasPagados { get; set; }

        [XmlAttribute("TotalPercepciones")]
        public string totalPercepciones { get; set; }

        [XmlAttribute("TotalDeducciones")]
        public string totalDeducciones { get; set; }

        [XmlAttribute("TotalOtrosPagos")]
        public string totalOtrosPagos { get; set; }

        [XmlElement("Emisor")]
        public Emisor emisor { get; set; }

        [XmlElement("Receptor")]
        public Receptor receptor { get; set; }

        [XmlElement("Percepciones")]
        public Percepciones percepciones { get; set; }

        [XmlElement("Deducciones")]
        public Deducciones deducciones { get; set; }

        [XmlElement("OtrosPagos")]
        public OtrosPagos otrosPagos { get; set; }

        [XmlElement("Incapacidades")]
        public Incapacidades incapacidades { get; set; }

        public Nomina()
        {
            emisor = new Emisor();
            receptor = new Receptor();
            percepciones = new Percepciones();
            deducciones = new Deducciones();
        }
    }
}
