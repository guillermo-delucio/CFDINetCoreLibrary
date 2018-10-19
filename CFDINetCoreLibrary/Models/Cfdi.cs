using CFDINetCoreLibrary.Models.Comprobantes;
using System.Xml;

namespace CFDINetCoreLibrary.Models
{
    /// <summary>
    /// Clase que contiene todo lo necesario para el manejo de comprobantes 3.3
    /// </summary>
    public class Cfdi
    {
        public Comprobante comprobante { get; set; }
        public Comprobante comprobanteTimbrado { get; set; }
        public XmlDocument xmlCfdiSinSello { get; set; }
        public XmlDocument xmlCfdiSinTimbrar { get; set; }
        public XmlDocument xmlCfdiTimbrado { get; set; }
        public string rutaArchivoCer { get; set; }
        public string rutaArchivoKey { get; set; }
        public string secretArchivoKey { get; set; }
        public string rutaXsltCadenaOriginal { get; set; }
        public string rutaCfdi { get; set; }
        public string nombreCfdiSinSello { get; set; }
        public string nombreCfdiSinTimbrar { get; set; }
        public string nombreCfdiTimbrado { get; set; }
        public string nombreCfdiZip { get; set; }
        public string nombreCfdiPdf { get; set; }
        public string cadenaOriginal { get; set; }
        public string cadenaOriginalComplemento { get; set; }
        public string cadenaCodigoQr { get; set; }
        public byte[] bytesCfdiSinTimbrar { get; set; }
        public byte[] bytesCfdiTimbrado { get; set; }
        public byte[] bytesCodigoQr { get; set; }
    }
}
