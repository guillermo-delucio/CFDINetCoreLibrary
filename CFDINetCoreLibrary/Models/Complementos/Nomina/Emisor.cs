using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class Emisor
    {
        [XmlAttribute("Curp")]
        public string curp { get; set; }

        [XmlAttribute("RegistroPatronal")]
        public string registroPatronal { get; set; }

        [XmlAttribute("RfcPatronOrigen")]
        public string rfcPatronOrigen { get; set; }

        [XmlElement("EntidadSNCF")]
        public EntidadSNCF entidadSncf { get; set; }
    }
}
