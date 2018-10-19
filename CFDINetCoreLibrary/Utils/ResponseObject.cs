using static CFDINetCoreLibrary.Utils.Enumeradores;

namespace CFDINetCoreLibrary.Utils
{
    /// <summary>
    /// Clase utilizada para enviar una respuesta general
    /// </summary>
    public class ResponseObject
    {
        public int responseCode { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public ResponseObject()
        {

        }

        public ResponseObject(ResponseCode responseCode, string message, object data)
        {
            this.responseCode = (int)responseCode;
            this.message = message;
            this.data = data;
        }
    }
}
