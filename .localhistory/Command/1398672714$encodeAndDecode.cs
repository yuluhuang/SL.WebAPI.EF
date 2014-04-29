using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace UN.Command
{
    public  class encodeAndDecode
    {
        /// <summary>
        /// 获得hash值 #目的：获取用户名和盐[通过用户输入的用户名]
        /// </summary>
        /// <param name="md5Hash"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public  static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// 将密码加盐哈希【注册】
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string passwordToMd5(string password, string salt)
        {

            using (MD5 md5Hash = MD5.Create())
            {
                return GetMd5Hash(md5Hash, password + salt);//将用户编号hash
            }
        }
       
    }
}
