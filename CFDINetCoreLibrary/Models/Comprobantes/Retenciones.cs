using System.Collections.Generic;
using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Comprobantes
{
    public class Retenciones
    {
        [XmlElement("Retencion")]
        public List<Retencion> retencion { get; set; }

        public Retenciones()
        {
            retencion = new List<Retencion>();
        }
    }
}
