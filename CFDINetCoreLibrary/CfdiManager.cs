using CFDINetCoreLibrary.Models;
using CFDINetCoreLibrary.Models.Comprobantes;
using CFDINetCoreLibrary.Utils;
using Chilkat;
using ICSharpCode.SharpZipLib.Zip;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CFDINetCoreLibrary
{
    /// <summary>
    /// Clase encargada del manejo de comprobantes
    /// </summary>
    public class CfdiManager
    {
        #region Metodos de Conversion

        /// <summary>
        /// Convierte un comprobante a xml
        /// </summary>
        /// <param name="cfdi"></param>
        /// <param name="type"></param>
        /// <param name="namespaces"></param>
        /// <param name="isAddenda"></param>
        /// <returns>Xml del comprobante</returns>
        public static string castCfdiToXml(object cfdi, Type type, List<XmlNamespace> namespaces, Boolean isAddenda)
        {
            try
            {
                var serializer = new XmlSerializer(type);
                using (MemoryStream output = new MemoryStream())
                {
                    var settings = new XmlWriterSettings();
                    settings.Encoding = new UTF8Encoding(false);

                    using (XmlWriter xmlWriter = XmlWriter.Create(output, settings))
                    {
                        var ns = new XmlSerializerNamespaces();
                        namespaces.ForEach(n =>
                        {
                            ns.Add(n.nombre, n.url);
                        });

                        if (!isAddenda)
                        {
                            ns.Add("xsi", Constantes.XML_NAMESPACE);
                        }

                        serializer.Serialize(xmlWriter, cfdi, ns);
                    }

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(Encoding.UTF8.GetString(output.ToArray()));
                    return xmlDoc.ChildNodes[1].OuterXml;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Convierte un xml a un objeto comprobante
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="type"></param>
        /// <returns>Comprobante</returns>
        public static T castXmlToCfdi<T>(string xml, Type type)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(type);
                var doc = (T)serializer.Deserialize(new StringReader(xml));
                return doc;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Convierte un comprobante a json
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns>Json del comprobante</returns>
        public static string castCfdiToJson(object objeto)
        {
            try
            {
                return JsonConvert.SerializeObject(objeto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Convierte un json a un objeto comprobante
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns>Comprobante</returns>
        public static T castJsonToCfdi<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region Funciones Miscelaneas

        /// <summary>
        /// Convierte un archivo .cer a su representativo en .pem (Deprecated)
        /// </summary>
        /// <param name="rutaCertificado"></param>
        /// <param name="rutaGuardado"></param>
        /// <param name="rutaGuardadoArchivoPem"></param>
        /// <returns>Boolean</returns>
        public static Boolean convertirCertificadoAPem(string rutaCertificado, string rutaGuardado, string nombreArchivoPem)
        {
            try
            {
                string rutaArchivoPem = Path.Combine(rutaGuardado, nombreArchivoPem);

                if (!Directory.Exists(rutaGuardado))
                    Directory.CreateDirectory(rutaGuardado);

                if (File.Exists(rutaArchivoPem))
                    File.Delete(rutaArchivoPem);

                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                X509Certificate2 certificado = new X509Certificate2(rutaCertificado);

                builder.AppendLine("-----BEGIN CERTIFICATE-----");
                builder.AppendLine(Convert.ToBase64String(certificado.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks));
                builder.AppendLine("-----END CERTIFICATE-----");

                File.WriteAllText(rutaArchivoPem, builder.ToString());

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Convierte un archivo .key a su representativo en .pem pkcs8 (Deprecated)
        /// </summary>
        /// <param name="rutaArchivoKey"></param>
        /// <param name="secretArchivoKey"></param>
        /// <param name="rutaGuardado"></param>
        /// <param name="nombreArchivoPem"></param>
        /// <returns>Boolean</returns>
        public static Boolean convertirKeyAPem(string rutaArchivoKey, string secretArchivoKey, string rutaGuardado, string nombreArchivoPem)
        {
            try
            {
                string rutaArchivoPem = Path.Combine(rutaGuardado, nombreArchivoPem);

                if (!Directory.Exists(rutaGuardado))
                    Directory.CreateDirectory(rutaGuardado);

                if (File.Exists(rutaArchivoPem))
                    File.Delete(rutaArchivoPem);

                byte[] bytesArchivoKey = File.ReadAllBytes(rutaArchivoKey);

                AsymmetricKeyParameter asp = PrivateKeyFactory.DecryptKey(secretArchivoKey.ToCharArray(), bytesArchivoKey);

                MemoryStream ms = new MemoryStream();
                TextWriter writer = new StreamWriter(ms);
                StringWriter stWrite = new StringWriter();
                PemWriter pmw = new PemWriter(stWrite);
                pmw.WriteObject(asp);
                stWrite.Close();

                File.WriteAllText(rutaArchivoPem, stWrite.ToString());

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Genera el archivo pfx y devuelve el resultado con su contraseña
        /// </summary>
        /// <param name="rutaArchivoCer"></param>
        /// <param name="rutaArchivoKey"></param>
        /// <param name="secretArchivoKey"></param>
        /// <param name="rutaGuardado"></param>
        /// <param name="nombreArchivoPfx"></param>
        /// <param name="secretArchivoPfx"></param>
        /// <param name="conservarArchivo"></param>
        /// <returns>Pfx</returns>
        public static CfdiPfx generarArchivoPfx(string rutaArchivoCer, string rutaArchivoKey, string secretArchivoKey, string rutaGuardado, string nombreArchivoPfx, string secretArchivoPfx, Boolean conservarArchivo)
        {
            try
            {
                string rutaArchivoPfx = Path.Combine(rutaGuardado, nombreArchivoPfx);

                if (!Directory.Exists(rutaGuardado))
                    Directory.CreateDirectory(rutaGuardado);

                if (File.Exists(rutaArchivoPfx))
                    File.Delete(rutaArchivoPfx);

                X509Certificate2 certificado = new X509Certificate2(rutaArchivoCer);
                Org.BouncyCastle.X509.X509Certificate certificate = DotNetUtilities.FromX509Certificate(certificado);

                byte[] bytesArchivoKey = File.ReadAllBytes(rutaArchivoKey);
                AsymmetricKeyParameter privateKey = PrivateKeyFactory.DecryptKey(secretArchivoKey.ToCharArray(), bytesArchivoKey);

                var certEntry = new X509CertificateEntry(certificate);
                string friendlyName = certificate.SubjectDN.ToString();

                PrivateKeyInfo keyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKey);
                byte[] keyBytes = keyInfo.ToAsn1Object().GetEncoded();

                var builder = new Pkcs12StoreBuilder();
                builder.SetUseDerEncoding(true);
                var store = builder.Build();

                store.SetKeyEntry("PrivateKeyAlias", new AsymmetricKeyEntry(privateKey), new X509CertificateEntry[] { certEntry });

                byte[] pfxBytes = null;

                using (MemoryStream stream = new MemoryStream())
                {
                    store.Save(stream, secretArchivoPfx.ToCharArray(), new SecureRandom());
                    pfxBytes = stream.ToArray(); // Este sirve para la cancelacion
                }

                var result = Pkcs12Utilities.ConvertToDefiniteLength(pfxBytes);

                if (conservarArchivo)
                    File.WriteAllBytes(rutaArchivoPfx, result);

                return new CfdiPfx(result, secretArchivoPfx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Funciones de Cfdi

        /// <summary>
        /// Genera el archivo Xml del cfdi, incluyendo la lista de namespaces que utilizara
        /// </summary>
        /// <param name="cfdi"></param>
        /// <param name="namespaces"></param>
        /// <returns>Cfdi</returns>
        public static Cfdi generarCfdi33(Cfdi cfdi, List<XmlNamespace> namespaces)
        {
            try
            {
                string rutaTemporalXmlSinSello = Path.Combine(cfdi.rutaCfdi, cfdi.nombreCfdiSinSello);
                string rutaTemporalXmlSinTimbrar = Path.Combine(cfdi.rutaCfdi, cfdi.nombreCfdiSinTimbrar);

                if (!Directory.Exists(cfdi.rutaCfdi))
                    Directory.CreateDirectory(cfdi.rutaCfdi);

                if (File.Exists(rutaTemporalXmlSinSello))
                    File.Delete(rutaTemporalXmlSinSello);

                if (File.Exists(rutaTemporalXmlSinTimbrar))
                    File.Delete(rutaTemporalXmlSinTimbrar);

                XmlTextWriter xmlTextW = new XmlTextWriter(rutaTemporalXmlSinSello, Encoding.UTF8);

                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

                if (namespaces == null || !namespaces.Any())
                {
                    ns.Add("cfdi", Constantes.CFDI_NAMESPACE);
                    ns.Add("xsi", Constantes.XML_NAMESPACE);
                }
                else
                {
                    namespaces.ForEach(n =>
                    {
                        ns.Add(n.nombre, n.url);
                    });
                }

                XmlSerializer serialize = new XmlSerializer(typeof(Comprobante));
                serialize.Serialize(xmlTextW, cfdi.comprobante, ns);

                xmlTextW.Close();
                XDocument xDoc = XDocument.Load(rutaTemporalXmlSinSello);
                cfdi.xmlCfdiSinSello = xDoc.toXmlDocument();
                firmarXml(cfdi, ref xDoc);
                xDoc.Save(rutaTemporalXmlSinTimbrar);
                cfdi.xmlCfdiSinTimbrar = xDoc.toXmlDocument();
                cfdi.bytesCfdiSinTimbrar = File.ReadAllBytes(rutaTemporalXmlSinTimbrar);

                return cfdi;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene la informnacion del certificado, lo desencripta y aplica digestion SHA-256 para generar el sello.
        /// </summary>
        /// <param name="cfdi"></param>
        /// <param name="xml"></param>
        private static void firmarXml(Cfdi cfdi, ref XDocument xml)
        {
            try
            {
                obtenerCertificado(cfdi.rutaArchivoCer, ref xml);
                string cadenaOriginal = obtenerCadenaOriginal(cfdi.rutaXsltCadenaOriginal, xml);
                string algoritmoHash = "SHA-256";
                string xmlLlavePrivada = string.Empty;
                string sellobase64 = string.Empty;

                Rsa rsa = new Rsa();
                Rsa rsa2 = new Rsa();
                Cert certificado = new Cert();
                PrivateKey llavePrivada = new PrivateKey();
                Chilkat.PublicKey llavePublica;

                if (llavePrivada.LoadPkcs8EncryptedFile(cfdi.rutaArchivoKey, cfdi.secretArchivoKey) == false)
                    return;

                xmlLlavePrivada = llavePrivada.GetXml();

                if (rsa.UnlockComponent(Constantes.CHILKAT_UNLOCK_CODE) == false)
                {
                    //Debug.Write(rsa.LastErrorText);
                    return;
                }

                if (rsa.ImportPrivateKey(xmlLlavePrivada) == false)
                {
                    //Debug.Write(rsa.LastErrorText);
                    return;
                }

                rsa.Charset = "utf-8";
                rsa.EncodingMode = "base64";
                rsa.LittleEndian = false;

                if (certificado.LoadFromFile(cfdi.rutaArchivoCer) == false)
                    return;

                sellobase64 = rsa.SignStringENC(cadenaOriginal, algoritmoHash);

                xml.Root.SetAttributeValue("Sello", sellobase64);

                XElement xComprobante = xml.Root;
                xComprobante = HelpersXml.removerAtributosVacios(xml.Root, true);

                llavePublica = certificado.ExportPublicKey();

                if (rsa2.ImportPublicKey(llavePublica.GetXml()) == false)
                    return;

                rsa2.Charset = "utf-8";
                rsa.EncodingMode = "base64";
                rsa2.LittleEndian = false;

                if (rsa2.VerifyStringENC(cadenaOriginal, algoritmoHash, sellobase64) == false)
                    return;

                certificado.Dispose();

                cfdi.cadenaOriginal = cadenaOriginal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene la informacion del certificado
        /// </summary>
        /// <param name="rutaArvhivoCertificado"></param>
        /// <param name="xml"></param>
        private static void obtenerCertificado(string rutaArchivoCertificado, ref XDocument xml)
        {
            try
            {
                Cert certificado = new Cert();

                if (certificado.LoadFromFile(rutaArchivoCertificado) == false)
                    return;

                if (certificado.Expired == true)
                    return;

                string serie = certificado.SerialNumber;
                string noCertificado = string.Empty;

                for (int i = 0; i < serie.Length; i++)
                {
                    if (i % 2 != 0)
                        noCertificado += serie.ElementAt(i);
                }

                serie = noCertificado;

                xml.Root.SetAttributeValue("NoCertificado", noCertificado);
                xml.Root.SetAttributeValue("Certificado", certificado.GetEncoded());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Termina de llenar los campos faltantes de un modelo Cfdi como cadena original complemento, etc
        /// </summary>
        /// <param name="cfdi"></param>
        /// <returns>Cfdi</returns>
        public static Cfdi complementarCfdiTimbrado(Cfdi cfdi)
        {
            string rutaTemporalXmlSinSello = Path.Combine(cfdi.rutaCfdi, cfdi.nombreCfdiSinSello);
            string rutaTemporalXmlSinTimbrar = Path.Combine(cfdi.rutaCfdi, cfdi.nombreCfdiSinTimbrar);
            string rutaTemporalXmlTimbrado = Path.Combine(cfdi.rutaCfdi, cfdi.nombreCfdiTimbrado);

            if (File.Exists(rutaTemporalXmlTimbrado))
                File.Delete(rutaTemporalXmlTimbrado);

            XDocument xDoc = cfdi.xmlCfdiTimbrado.toXDocument();
            xDoc.Save(rutaTemporalXmlTimbrado);
            cfdi.bytesCfdiTimbrado = File.ReadAllBytes(rutaTemporalXmlTimbrado);

            cfdi.comprobanteTimbrado = castXmlToCfdi<Comprobante>(cfdi.xmlCfdiTimbrado.InnerXml, typeof(Comprobante));
            cfdi.cadenaOriginalComplemento = obtenerCadenaOriginalComplemento(cfdi.comprobanteTimbrado.complemento.timbreFiscalDigital.version, cfdi.comprobanteTimbrado.complemento.timbreFiscalDigital.uuid, cfdi.comprobanteTimbrado.complemento.timbreFiscalDigital.fechaTimbrado, cfdi.comprobanteTimbrado.complemento.timbreFiscalDigital.rfcProvCertif, cfdi.comprobanteTimbrado.complemento.timbreFiscalDigital.selloCfd, cfdi.comprobanteTimbrado.complemento.timbreFiscalDigital.noCertificadoSat);
            cfdi.cadenaCodigoQr = obtenerCadenaCodigoQr(decimal.Parse(cfdi.comprobante.total), cfdi.comprobante.emisor.rfc, cfdi.comprobante.receptor.rfc, cfdi.comprobanteTimbrado.complemento.timbreFiscalDigital.uuid, cfdi.comprobanteTimbrado.complemento.timbreFiscalDigital.selloCfd);
            cfdi.bytesCodigoQr = generarImagenQr(cfdi.cadenaCodigoQr);

            File.Delete(rutaTemporalXmlSinSello);
            File.Delete(rutaTemporalXmlSinTimbrar);

            return cfdi;
        }

        /// <summary>
        /// Obtiene la cadena original del cfdi
        /// </summary>
        /// <param name="rutaArchivoCadenaOriginal"></param>
        /// <param name="xml"></param>
        /// <returns>Cadena Original</returns>
        private static string obtenerCadenaOriginal(string rutaArchivoCadenaOriginal, XDocument xml)
        {
            try
            {
                string cadenaOriginal = null;

                XElement xComprobante = xml.Root;
                HelpersXml.removerAtributosVacios(xComprobante, true);

                string xmlTemporal = Path.GetTempFileName();
                dynamic nuevoXml = Path.GetTempFileName();

                xComprobante.Save(xmlTemporal);

                dynamic Xsl = new System.Xml.Xsl.XslCompiledTransform();
                Xsl.Load(rutaArchivoCadenaOriginal);
                Xsl.Transform(xmlTemporal, nuevoXml);
                Xsl = null;

                dynamic StreamReader = new StreamReader(nuevoXml);
                cadenaOriginal = StreamReader.ReadToEnd();
                StreamReader.Close();

                File.Delete(nuevoXml);
                File.Delete(xmlTemporal);

                StreamReader.Dispose();

                return cadenaOriginal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene la cadena original del complemento del cfdi
        /// </summary>
        /// <param name="version"></param>
        /// <param name="uuid"></param>
        /// <param name="fechaTimbrado"></param>
        /// <param name="rfcProvCertif"></param>
        /// <param name="selloCfd"></param>
        /// <param name="noCertificadoSat"></param>
        /// <returns>string</returns>
        public static string obtenerCadenaOriginalComplemento(string version, string uuid, string fechaTimbrado, string rfcProvCertif, string selloCfd, string noCertificadoSat)
        {
            try
            {
                string result = result = string.Concat("||", version, "|", uuid, "|", fechaTimbrado, "|", rfcProvCertif, "|", selloCfd, "|", noCertificadoSat, "||");
                Encoding utf_8 = Encoding.UTF8;
                byte[] utf8Bytes = Encoding.UTF8.GetBytes(result);
                string result2 = Encoding.UTF8.GetString(utf8Bytes);
                return result2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene la cadena del codigo qr
        /// </summary>
        /// <param name="total"></param>
        /// <param name="rfcEmisor"></param>
        /// <param name="rfcReceptor"></param>
        /// <param name="uuid"></param>
        /// <param name="selloCfdi"></param>
        /// <returns></returns>
        public static string obtenerCadenaCodigoQr(Decimal total, string rfcEmisor, string rfcReceptor, string uuid, string selloCfdi)
        {
            try
            {
                string urlCodigoCbb = Constantes.CFDI_URL_CBB;
                uuid = "id=" + uuid;
                rfcEmisor = "&re=" + rfcEmisor;
                rfcReceptor = "&rr=" + rfcReceptor;
                string totalString = "&tt=" + string.Format(Constantes.FORMATO_MONEDA_6_DIGITOS, total);
                selloCfdi = "&fe=" + selloCfdi.Substring(selloCfdi.Length - 8, 8);
                string result = string.Concat(urlCodigoCbb, uuid, rfcEmisor, rfcReceptor, totalString, selloCfdi);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Genera la imagen qr para el pdf
        /// </summary>
        /// <param name="cadenaQr"></param>
        /// <returns>Codigo QR</returns>
        public static byte[] generarImagenQr(string cadenaQr)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(cadenaQr, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap img = qrCode.GetGraphic(20);
            MemoryStream imagenStream = new MemoryStream();
            img.Save(imagenStream, ImageFormat.Jpeg);
            return imagenStream.ToArray();
        }

        /// <summary>
        /// Obtiene el xml timbrado desde un archivo zip
        /// </summary>
        /// <param name="cfdi"></param>
        /// <returns>Boolean</returns>
        public static Boolean obtenerDatosDesdeZip(Cfdi cfdi)
        {
            try
            {
                string rutaZip = Path.Combine(cfdi.rutaCfdi, cfdi.nombreCfdiZip);
                string rutaCfdiTimbrado = Path.Combine(cfdi.rutaCfdi, cfdi.nombreCfdiTimbrado);
                using (ZipInputStream sz = new ZipInputStream(File.OpenRead(rutaZip)))
                {
                    ICSharpCode.SharpZipLib.Zip.ZipEntry theEntry;
                    while ((theEntry = sz.GetNextEntry()) != null)
                    {
                        string fileName = Path.GetFileName(theEntry.Name);

                        if (fileName != string.Empty)
                        {
                            using (FileStream streamWriter = File.Create(rutaCfdiTimbrado))
                            {
                                int size = 2048;
                                byte[] data = new byte[2048];

                                while (true)
                                {
                                    size = sz.Read(data, 0, data.Length);
                                    if (size > 0)
                                        streamWriter.Write(data, 0, size);
                                    else
                                        break;
                                }

                                streamWriter.Close();
                            }
                        }
                    }
                }

                XmlReader reader = XmlReader.Create(rutaCfdiTimbrado);
                XDocument xDoc = XDocument.Load(rutaCfdiTimbrado);
                cfdi.xmlCfdiTimbrado = xDoc.toXmlDocument();
                cfdi.comprobanteTimbrado = castXmlToCfdi<Comprobante>(cfdi.xmlCfdiTimbrado.InnerXml, typeof(Comprobante));
                cfdi.bytesCfdiTimbrado = File.ReadAllBytes(rutaCfdiTimbrado);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Agrega la parte del timbre al cfdi original
        /// </summary>
        /// <param name="cfdiSinTimbrar"></param>
        /// <param name="timbre"></param>
        /// <param name="existeComplemento"></param>
        /// <returns>Xml</returns>
        public static XmlDocument agregarTimbreACfdi(XmlDocument cfdiSinTimbrar, string timbre, bool existeComplemento)
        {
            string InitFile = Constantes.XML_HEADER_UTF8;
            string FindLastNode = Constantes.CFDI_COMPROBANTE_FIN;
            string LocInvoice = cfdiSinTimbrar.InnerXml.Replace(FindLastNode, string.Empty);
            string InitComplemento = Constantes.CFDI_COMPLEMENTO_INICIO;
            string EndComplemento = Constantes.CFDI_COMPLEMENTO_FIN;
            string ringLocComplement = string.Empty;
            string XmlCompleto = string.Empty;
            XmlDocument cfdiTimbrado = new XmlDocument();

            string ringLoc = timbre.Replace(Constantes.XML_HEADER_UTF8, string.Empty);
            ringLoc = ringLoc.Replace(Constantes.XML_HEADER_ISO88591, string.Empty);

            if (existeComplemento)
            {
                ringLocComplement = string.Concat(LocInvoice.Replace(EndComplemento, ringLoc), EndComplemento);
                XmlCompleto = string.Concat(InitFile, ringLocComplement, FindLastNode);
            }
            else
            {
                ringLocComplement = string.Concat(InitComplemento, ringLoc, EndComplemento);
                XmlCompleto = string.Concat(InitFile, LocInvoice, ringLocComplement, FindLastNode);
            }

            cfdiTimbrado.LoadXml(XmlCompleto);
            return cfdiTimbrado;
        }

        #endregion
    }
}
