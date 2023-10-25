using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace WMSOffice.Window
{
    public class SecurityHelper
    {
        public static string TemporaryKey { get { return "Jgnbvf-Afhv? KNL"; } }

        private static TripleDES CreateDES(string key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
            des.IV = new byte[des.BlockSize / 8];
            return des;
        }

        public static string Encrypt(string message, string key)
        {
            TripleDES des = CreateDES(key);
            ICryptoTransform ct = des.CreateEncryptor();
            byte[] input = Encoding.Unicode.GetBytes(message);
            return Convert.ToBase64String(ct.TransformFinalBlock(input, 0, input.Length));
        }

        public static string Decrypt(string cypher, string key)
        {
            byte[] b = Convert.FromBase64String(cypher);
            TripleDES des = CreateDES(key);
            ICryptoTransform ct = des.CreateDecryptor();
            byte[] output = ct.TransformFinalBlock(b, 0, b.Length);
            return Encoding.Unicode.GetString(output);
        }
    }
}
