using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace MobilePro
{
    class clsEncryption
    {
        private byte[] b = ASCIIEncoding.ASCII.GetBytes("KeanYiap");

        internal string EncryptPwd(string strPwd)
        {
            try
            {
                DESCryptoServiceProvider cp = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, cp.CreateEncryptor(b, b), CryptoStreamMode.Write);

                StreamWriter writer = new StreamWriter(cs);

                writer.Write(strPwd);
                writer.Flush();
                cs.FlushFinalBlock();
                writer.Flush();

                return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            }
            catch
            {
                return strPwd;
            }
        }

        internal string DecryptPwd(string strPwd)
        {
            try
            {
                DESCryptoServiceProvider cp = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream(Convert.FromBase64String(strPwd));
                CryptoStream cs = new CryptoStream(ms, cp.CreateDecryptor(b, b), CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(cs);

                return reader.ReadToEnd();
            }
            catch
            {
                return strPwd;
            }
        }
    }
}
