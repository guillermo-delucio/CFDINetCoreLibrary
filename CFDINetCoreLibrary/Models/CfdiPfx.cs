namespace CFDINetCoreLibrary.Models
{
    /// <summary>
    /// Esta clase contiene los elementos necesarios para la creacion de archivos pfx
    /// </summary>
    public class CfdiPfx
    {
        public byte[] bytesPfx { get; set; }
        public string secretPfx { get; set; }

        public CfdiPfx()
        {
        }

        public CfdiPfx(byte[] bytesPfx, string secretPfx)
        {
            this.bytesPfx = bytesPfx;
            this.secretPfx = secretPfx;
        }
    }
}
