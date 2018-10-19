using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class SubsidioAlEmpleo
    {
        [XmlAttribute("SubsidioCausado")]
        public string subsidioCausado { get; set; }
    }
}
