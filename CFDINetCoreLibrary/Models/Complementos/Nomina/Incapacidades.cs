using System.Collections.Generic;
using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class Incapacidades
    {
        [XmlElement("Incapacidad")]
        public List<Incapacidad> incapacidades { get; set; }

        public Incapacidades()
        {
            incapacidades = new List<Incapacidad>();
        }
    }
}
