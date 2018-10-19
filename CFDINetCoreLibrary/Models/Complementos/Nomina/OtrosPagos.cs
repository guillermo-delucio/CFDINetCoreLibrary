using System.Collections.Generic;
using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class OtrosPagos
    {
        [XmlElement("OtroPago")]
        public List<OtroPago> otrosPagos { get; set; }

        public OtrosPagos()
        {
            otrosPagos = new List<OtroPago>();
        }
    }
}
