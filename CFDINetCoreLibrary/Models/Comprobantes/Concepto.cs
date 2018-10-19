using System.Collections.Generic;
using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Comprobantes
{
    public class Concepto
    {
        [XmlAttribute("Importe")]
        public string importe { get; set; }

        [XmlAttribute("ValorUnitario")]
        public string valorUnitario { get; set; }

        [XmlAttribute("Descripcion")]
        public string descripcion { get; set; }

        [XmlAttribute("NoIdentificacion")]
        public string noIdentificacion { get; set; }

        [XmlAttribute("Unidad")]
        public string unidad { get; set; }

        [XmlAttribute("Cantidad")]
        public string cantidad { get; set; }

        [XmlAttribute("Descuento")]
        public string descuento { get; set; }

        [XmlAttribute("ClaveUnidad")]
        public string claveUnidad { get; set; }

        [XmlAttribute("ClaveProdServ")]
        public string claveProdServ { get; set; }

        [XmlElement("Impuestos")]
        public Impuestos impuestos { get; set; }

        [XmlElement("InformacionAduanera")]
        public List<InformacionAduanera> informacionAduanera { get; set; }

        [XmlElement("CuentaPredial")]
        public List<CuentaPredial> cuentaPredial { get; set; }

        public Concepto()
        {
            informacionAduanera = new List<InformacionAduanera>();
            cuentaPredial = new List<CuentaPredial>();
        }
    }
}
