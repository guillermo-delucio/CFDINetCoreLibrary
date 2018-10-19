using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class AccionesOTitulos
    {
        [XmlAttribute("ValorMercado")]
        public string valorMercado { get; set; }

        [XmlAttribute("PrecioAlOtorgarse")]
        public string precioAlOtorgarse { get; set; }
    }
}
