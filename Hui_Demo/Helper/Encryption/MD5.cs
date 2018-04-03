using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Hui_Demo.Helper.Encryption
{
    public class MD5
    {

        public static string DefaultSalt = "LincIT";

        /// <summary>  
        /// MD5 加密字符串  
        /// </summary>  
        /// <param name="Password">源字符串</param>  
        /// <returns>加密后字符串</returns>  
        public static string Encrypt(string Password)
        {

            // 创建MD5类的默认实例：MD5CryptoServiceProvider  
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(Password);
            byte[] hs = md5.ComputeHash(bs);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hs)
            {
                // 以十六进制格式格式化  
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>  
        /// MD5盐值加密  
        /// </summary>  
        /// <param name="Password">源字符串</param>  
        /// <param name="Salt">盐值</param>  
        /// <returns>加密后字符串</returns>  
        public static string Encrypt(string Password, object Salt)
        {
            if (Salt == null) return Password;
            return Encrypt(Password + "{" + Salt.ToString() + "}");
        }
    }
}