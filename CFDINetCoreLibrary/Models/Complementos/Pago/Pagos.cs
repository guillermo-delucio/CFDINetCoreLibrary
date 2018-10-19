using System.Collections.Generic;
using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Pago
{
    public class Pagos
    {
        [XmlAttribute("Version")]
        public string version { get; set; }

        [XmlElement("Pago")]
        public List<Pago> pago { get; set; }

        public Pagos()
        {
            pago = new List<Pago>();
        }
    }
}
