using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class Subcontratacion
    {
        [XmlAttribute("RfcLabora")]
        public string rfcLabora { get; set; }

        [XmlAttribute("PorcentajeTiempo")]
        public string PorcentajeTiempo { get; set; }
    }
}
