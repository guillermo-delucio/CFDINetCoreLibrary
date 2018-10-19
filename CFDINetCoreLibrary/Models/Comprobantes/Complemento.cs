using CFDINetCoreLibrary.Models.Complementos.Nomina;
using CFDINetCoreLibrary.Models.Complementos.Pago;
using CFDINetCoreLibrary.Models.Complementos.TimbreFiscal;
using CFDINetCoreLibrary.Utils;
using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Comprobantes
{
    public class Complemento
    {
        [XmlElement("TimbreFiscalDigital", Namespace = Constantes.TFD_NAMESPACE)]
        public TimbreFiscal timbreFiscalDigital { get; set; }

        [XmlElement("Pagos", Namespace = Constantes.PAGOS_NAMESPACE)]
        public Pagos pagos { get; set; }

        [XmlElement("Nomina", Namespace = Constantes.NOMINA_NAMESPACE)]
        public Nomina nomina { get; set; }
    }
}
