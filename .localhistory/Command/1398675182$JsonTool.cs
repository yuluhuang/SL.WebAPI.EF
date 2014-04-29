using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public  class JsonTool<T>
    {
        public static string status(string s)
        {

            return "[{\"status\":\"" + s + "\"}]";
        }

        /// <summary>
        /// json格式转换
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string response(string s, IEnumerable<T> model)
        {

            return "[{\"status\":\"" + s + "\"}]";
        }
    }
}
