using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class Incapacidad
    {
        [XmlAttribute("DiasIncapacidad")]
        public string diasIncapacidad { get; set; }

        [XmlAttribute("TipoIncapacidad")]
        public string tipoIncapacidad { get; set; }

        [XmlAttribute("ImporteMonetario")]
        public string importeMonetario { get; set; }
    }
}
