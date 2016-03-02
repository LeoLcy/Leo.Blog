using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace Leo.Blog.Common.Encrypt
{
    public class EncryptTools
    {
        /// <summary>
        /// MD5加密方式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5(string str, string appendText)
        {
            string needStr = string.IsNullOrEmpty(appendText) ? str : str + appendText;
            lock (typeof(EncryptTools))
            {
                byte[] b = Encoding.UTF8.GetBytes(needStr);
                b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
                string ret = "";
                for (int i = 0; i < b.Length; i++)
                    ret += b[i].ToString("x").PadLeft(2, '0');
                return ret;
            }
        }
        /// <summary>
        /// MD5加密方式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5(string str)
        {
            lock (typeof(EncryptTools))
            {
                byte[] b = Encoding.UTF8.GetBytes(str);
                b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
                string ret = "";
                for (int i = 0; i < b.Length; i++)
                    ret += b[i].ToString("x").PadLeft(2, '0');
                return ret;
            }
        }

        private const string StrEncrKey = "#@?,:*&%^!~";
        /// <summary>
        /// DESC解密
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string Decode(string strText)
        {
            byte[] rgbKey = new byte[0];
            byte[] rgbIV = new byte[] { 0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef };
            byte[] buffer = new byte[strText.Length];
            try
            {
                rgbKey = Encoding.UTF8.GetBytes(StrEncrKey.Substring(0, 8));
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                buffer = Convert.FromBase64String(strText);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        /// <summary>
        /// DESC加密
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string Encode(string strText)
        {
            byte[] rgbKey = new byte[0];
            byte[] rgbIV = new byte[] { 0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef };
            try
            {
                string s = StrEncrKey.Substring(0, 8);
                rgbKey = Encoding.UTF8.GetBytes(s);
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                byte[] bytes = Encoding.UTF8.GetBytes(strText);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                return Convert.ToBase64String(stream.ToArray());
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
    }
}
