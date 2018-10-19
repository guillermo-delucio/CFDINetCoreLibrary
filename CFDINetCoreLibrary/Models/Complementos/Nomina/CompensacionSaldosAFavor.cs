using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class CompensacionSaldosAFavor
    {
        [XmlAttribute("SaldoAFavor")]
        public string saldoAFavor { get; set; }

        [XmlAttribute("Año")]
        public string anio { get; set; }

        [XmlAttribute("RemanenteSalFav")]
        public string remanenteSaldoAFavor { get; set; }
    }
}
