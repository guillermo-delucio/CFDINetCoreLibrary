using System.Xml;
using System.Xml.Linq;

namespace CFDINetCoreLibrary.Utils
{
    /// <summary>
    /// Utilidades para manipulacion de xmls
    /// </summary>
    public static class HelpersXml
    {
        /// <summary>
        /// Elimina los atributos vacios de un nodo de un xml
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="incluirNodosHijos"></param>
        /// <returns>XElement</returns>
        public static XElement removerAtributosVacios(XElement elemento, bool incluirNodosHijos = false)
        {
            dynamic current = elemento.LastAttribute;

            while (current != null)
            {
                dynamic temp = current.PreviousAttribute;
                if (current.Value == string.Empty)
                {
                    if (current.Name != "Sello")
                        current.Remove();
                }
                current = temp;
            }

            if (incluirNodosHijos)
            {
                foreach (XElement child in elemento.Descendants())
                {
                    removerAtributosVacios(child);
                }
            }

            return elemento;
        }

        /// <summary>
        /// Convierte un XDocument a un XmlDocument
        /// </summary>
        /// <param name="xDocument"></param>
        /// <returns>XmlDocument</returns>
        public static XmlDocument toXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        /// <summary>
        /// Convierte un XmlDocument a un XDocument
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <returns>XDocument</returns>
        public static XDocument toXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }
    }
}
