using CFDINetCoreLibrary.Models.Comprobantes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Pago
{
    public class Pago
    {
        [XmlAttribute("FechaPago")]
        public string fechaPago { get; set; }

        [XmlAttribute("FormaDePagoP")]
        public string formaDePago { get; set; }

        [XmlAttribute("MonedaP")]
        public string moneda { get; set; }

        [XmlAttribute("TipoCambioP")]
        public string tipoCambio { get; set; }

        [XmlAttribute("Monto")]
        public string monto { get; set; }

        [XmlAttribute("NumOperacion")]
        public string numeroOperacion { get; set; }

        [XmlAttribute("RfcEmisorCtaOrd")]
        public string rfcEmisorCuentaOrdenante { get; set; }

        [XmlAttribute("NomBancoOrdExt")]
        public string nombreBancoOrdenante { get; set; }

        [XmlAttribute("CtaOrdenante")]
        public string cuentaOrdenante { get; set; }

        [XmlAttribute("RfcEmisorCtaBen")]
        public string rfcEmisorCuentaBeneficiario { get; set; }

        [XmlAttribute("CtaBeneficiario")]
        public string cuentaBeneficiario { get; set; }

        [XmlAttribute("TipoCadPago")]
        public string tipoCadenaPago { get; set; }

        [XmlAttribute("CertPago")]
        public string certificadoPago { get; set; }

        [XmlAttribute("CadPago")]
        public string cadenaPago { get; set; }

        [XmlAttribute("SelloPago")]
        public string selloPago { get; set; }

        [XmlElement("DoctoRelacionado")]
        public List<DocumentoRelacionado> documentosRelacionados { get; set; }

        [XmlElement("Impuestos")]
        public Impuestos impuestos { get; set; }

        public Pago()
        {
            documentosRelacionados = new List<DocumentoRelacionado>();
            impuestos = new Impuestos();
        }
    }
}
