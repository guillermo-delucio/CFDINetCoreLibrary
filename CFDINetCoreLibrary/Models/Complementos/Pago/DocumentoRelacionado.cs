using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Pago
{
    public class DocumentoRelacionado
    {
        [XmlAttribute("IdDocumento")]
        public string idDocumento { get; set; }

        [XmlAttribute("Serie")]
        public string serie { get; set; }

        [XmlAttribute("Folio")]
        public string folio { get; set; }

        [XmlAttribute("MonedaDR")]
        public string moneda { get; set; }

        [XmlAttribute("TipoCambioDR")]
        public string tipoCambio { get; set; }

        [XmlAttribute("MetodoDePagoDR")]
        public string metodoDePago { get; set; }

        [XmlAttribute("NumParcialidad")]
        public string numeroParcialidad { get; set; }

        [XmlAttribute("ImpSaldoAnt")]
        public string importeSaldoAnterior { get; set; }

        [XmlAttribute("ImpPagado")]
        public string importePagado { get; set; }

        [XmlAttribute("ImpSaldoInsoluto")]
        public string importeSaldoInsoluto { get; set; }
    }
}
