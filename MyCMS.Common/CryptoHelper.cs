using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Utilities
{
    public class CryptoHelper
    {
        const string key = "MyCMS!@#$%Key";

        public static string encryptString(string text)
        {
            //Declare the below
            var cryptDES3 = new TripleDESCryptoServiceProvider();
            var cryptMD5Hash = new MD5CryptoServiceProvider();
            cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
            cryptDES3.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = cryptDES3.CreateEncryptor();
            byte[] buff = ASCIIEncoding.ASCII.GetBytes(text);
            string Encrypt = Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
            Encrypt = Encrypt.Replace("+", "!");
            return Encrypt;
        }

        public static string decryptString(string text)
        {
            //Declare the below
            var cryptDES3 = new TripleDESCryptoServiceProvider();
            var cryptMD5Hash = new MD5CryptoServiceProvider();
            text = text.Replace("!", "+");
            byte[] buf = new byte[text.Length];
            cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
            cryptDES3.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = cryptDES3.CreateDecryptor();
            buf = Convert.FromBase64String(text);
            string Decrypt = ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buf, 0, buf.Length));
            return Decrypt;
        }
    }
}
