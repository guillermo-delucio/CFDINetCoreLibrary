namespace CFDINetCoreLibrary.Utils
{
    /// <summary>
    /// Constantes utilizadas en la libreria
    /// </summary>
    public static class Constantes
    {
        #region Namespaces

        public const string XML_NAMESPACE = "http://www.w3.org/2001/XMLSchema-instance";
        public const string CFDI_NAMESPACE = "http://www.sat.gob.mx/cfd/3";
        public const string TFD_NAMESPACE = "http://www.sat.gob.mx/TimbreFiscalDigital";
        public const string PAGOS_NAMESPACE = "http://www.sat.gob.mx/Pagos";
        public const string NOMINA_NAMESPACE = "http://www.sat.gob.mx/nomina12";

        #endregion

        #region Xml

        public const string XML_HEADER_UTF8 = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        public const string XML_HEADER_ISO88591 = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>";
        public const string CFDI_COMPROBANTE_FIN = "</cfdi:Comprobante>";
        public const string CFDI_COMPLEMENTO_INICIO = "<cfdi:Complemento>";
        public const string CFDI_COMPLEMENTO_FIN = "</cfdi:Complemento>";

        #endregion

        #region Cfdi

        public const string CFDI_URL_CBB = @"https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?";

        #endregion

        #region Formatos

        public const string FORMATO_MONEDA_6_DIGITOS = "{0:0000000000.000000}";

        #endregion

        #region Miscelaneos

        public const string CHILKAT_UNLOCK_CODE = "RSA!TEAM!BEAN_3351D4535RlU";

        #endregion
    }
}
