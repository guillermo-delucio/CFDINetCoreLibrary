using System.Collections.Generic;
using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Comprobantes
{
    public class Conceptos
    {
        [XmlElement("Concepto")]
        public List<Concepto> concepto { get; set; }

        public Conceptos()
        {
            concepto = new List<Concepto>();
        }
    }
}
