using System;
using System.Text;

namespace CFDINetCoreLibrary.Utils
{
    /// <summary>
    /// Utilerias para codificacion y decodificacion
    /// </summary>
    public class HelpersEncode
    {
        /// <summary>
        /// Codifica un texto a base64
        /// </summary>
        /// <param name="texto"></param>
        /// <returns>string</returns>
        public static string toBase64(string texto)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(texto);
            return Convert.ToBase64String(byteArray);
        }

        /// <summary>
        /// Decodifica un texto de base64
        /// </summary>
        /// <param name="texto"></param>
        /// <returns>string</returns>
        public static string fromBase64(string texto)
        {
            byte[] byteArray = Convert.FromBase64String(texto);
            return Encoding.UTF8.GetString(byteArray);
        }
    }
}
