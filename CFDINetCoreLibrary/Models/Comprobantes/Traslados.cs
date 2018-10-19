using System.Collections.Generic;
using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Comprobantes
{
    public class Traslados
    {
        [XmlElement("Traslado")]
        public List<Traslado> traslado { get; set; }

        public Traslados()
        {
            traslado = new List<Traslado>();
        }
    }
}
