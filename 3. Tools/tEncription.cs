using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class tEncription
    {
        protected static byte[] Clave = Encoding.ASCII.GetBytes("5YSDL4ADAPS");
        protected static byte[] IV = Encoding.ASCII.GetBytes("AFAPSDYSTLW.37hAES");


        public static string Encripta(string Cadena)
        {
            if (!String.IsNullOrEmpty(Cadena))
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(Cadena);
                byte[] encripted;
                RijndaelManaged cripto = new RijndaelManaged();
                using (MemoryStream ms = new MemoryStream(inputBytes.Length))
                {
                    using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(Clave, IV), CryptoStreamMode.Write))
                    {
                        objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
                        objCryptoStream.FlushFinalBlock();
                        objCryptoStream.Close();
                    }
                    encripted = ms.ToArray();
                }
                return Base64UrlEncoder.Encode(encripted);
            }
            return "";
        }

        public static string Desencripta(string Cadena)
        {
            if (!String.IsNullOrEmpty(Cadena))
            {
                string textoLimpio = String.Empty;
                try
                {
                    byte[] inputBytes = Base64UrlEncoder.DecodeBytes(Cadena);
                    byte[] resultBytes = new byte[inputBytes.Length];
                    RijndaelManaged cripto = new RijndaelManaged();

                    using (MemoryStream ms = new MemoryStream(inputBytes))
                    {
                        using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(Clave, IV), CryptoStreamMode.Read))
                        {
                            using (StreamReader sr = new StreamReader(objCryptoStream, true))
                            {

                                textoLimpio = sr.ReadToEnd();

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    var x = ex;
                }
                return textoLimpio;
            }
            return "";
        }
    }
}
