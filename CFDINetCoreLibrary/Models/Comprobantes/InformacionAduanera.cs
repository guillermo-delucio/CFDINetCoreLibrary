using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Comprobantes
{
    public class InformacionAduanera
    {
        [XmlAttribute("NumeroPedimento")]
        public string numeroPedimento { get; set; }
    }
}
