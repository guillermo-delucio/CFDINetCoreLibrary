using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class EntidadSNCF
    {
        [XmlAttribute("OrigenRecurso")]
        public string origenRecurso { get; set; }

        [XmlAttribute("MontoRecursoPropio")]
        public string montoRecursoPropio { get; set; }
    }
}
