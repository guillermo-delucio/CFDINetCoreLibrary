using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class HorasExtra
    {
        [XmlAttribute("Dias")]
        public string dias { get; set; }

        [XmlAttribute("TipoHoras")]
        public string tipoHoras { get; set; }

        [XmlAttribute("HorasExtra")]
        public string horasExtra { get; set; }

        [XmlAttribute("ImportePagado")]
        public string importePagado { get; set; }
    }
}
