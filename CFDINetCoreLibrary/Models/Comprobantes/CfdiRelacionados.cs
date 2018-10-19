using System.Collections.Generic;
using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Comprobantes
{
    public class CfdiRelacionados
    {
        [XmlAttribute("TipoRelacion")]
        public string tipoRelacion { get; set; }

        [XmlElement("CfdiRelacionado")]
        public List<CfdiRelacionado> cfdiRelacionado { get; set; }

        public CfdiRelacionados()
        {
            cfdiRelacionado = new List<CfdiRelacionado>();
        }
    }
}
