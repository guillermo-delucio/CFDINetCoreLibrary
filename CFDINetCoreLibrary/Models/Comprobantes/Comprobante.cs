using CFDINetCoreLibrary.Utils;
using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Comprobantes
{
    /// <summary>
    /// Contiene las propiedades de un cfdi
    /// </summary>
    [XmlRoot("Comprobante", Namespace = Constantes.CFDI_NAMESPACE)]
    public class Comprobante
    {
        [XmlAttribute("LugarExpedicion")]
        public string lugarExpedicion { get; set; }

        [XmlAttribute("MetodoPago")]
        public string metodoDePago { get; set; }

        [XmlAttribute("TipoDeComprobante")]
        public string tipoDeComprobante { get; set; }

        [XmlAttribute("Total")]
        public string total { get; set; }

        [XmlAttribute("Moneda")]
        public string moneda { get; set; }

        [XmlAttribute("TipoCambio")]
        public string tipoCambio { get; set; }

        [XmlAttribute("SubTotal")]
        public string subTotal { get; set; }

        [XmlAttribute("Descuento")]
        public string descuento { get; set; }

        [XmlAttribute("CondicionesDePago")]
        public string condicionesDePago { get; set; }

        [XmlAttribute("Certificado")]
        public string certificado { get; set; }

        [XmlAttribute("NoCertificado")]
        public string noCertificado { get; set; }

        [XmlAttribute("FormaPago")]
        public string formaDePago { get; set; }

        [XmlAttribute("Sello")]
        public string sello { get; set; }

        [XmlAttribute("Fecha")]
        public string fecha { get; set; }

        [XmlAttribute("Folio")]
        public string folio { get; set; }

        [XmlAttribute("Serie")]
        public string serie { get; set; }

        [XmlAttribute("Version")]
        public string version { get; set; }

        [XmlAttribute("Confirmacion")]
        public string confirmacion { get; set; }

        [XmlAttribute(AttributeName = "schemaLocation", Namespace = Constantes.XML_NAMESPACE)]
        public string schemaLocation { get; set; }

        [XmlElement("CfdiRelacionados")]
        public CfdiRelacionados cfdiRelacionados { get; set; }

        [XmlElement("Emisor")]
        public Emisor emisor { get; set; }

        [XmlElement("Receptor")]
        public Receptor receptor { get; set; }

        [XmlElement("Conceptos")]
        public Conceptos conceptos { get; set; }

        [XmlElement("Impuestos")]
        public Impuestos impuestos { get; set; }

        [XmlElement("Complemento")]
        public Complemento complemento { get; set; }

        public string totalLetra { get; set; }

        public Comprobante()
        {
            emisor = new Emisor();
            receptor = new Receptor();
            conceptos = new Conceptos();
        }
    }
}
