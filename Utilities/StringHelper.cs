using System;
using System.Text;

namespace Utilities
{
    public static class StringHelper
    {
        /// <summary>
        /// 得到字符串长度，一个汉字长度为2
        /// </summary>
        /// <param name="that">参数字符串</param>
        /// <returns></returns>
        public static int GetLength(this string that)
        {
            var ascii = new ASCIIEncoding();
            var tempLen = 0;
            var bytes = ascii.GetBytes(that);
            foreach (var b in bytes)
            {
                if (b == 63)
                    tempLen += 2;
                else
                    tempLen += 1;
            }
            return tempLen;
        }

        /// <summary>
        /// 判断字符串是否为空(去除前后空格)
        /// </summary>
        /// <param name="that"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string that)
        {
            if (that == null) return true;
            if (that.Trim() == string.Empty) return true;
            return false;
        }

        /// <summary>
        /// 移除指定字符串(支持批量)
        /// </summary>
        /// <param name="that"></param>
        /// <param name="some"></param>
        /// <returns></returns>
        public static string RemoveSomething(this string that, params string[] some)
        {
            foreach (var item in some)
            {
                that = that.Replace(item, string.Empty);
            }
            return that;
        }

        /// <summary>
        /// 一定长度的随机字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetNonce(int length)
        {
            const string n = "qwertyuioplkjhgfdsazxcvbnm1234567890QWERTYUIOPLKJHGFDSAZXCVBNM";
            var s = "";
            var r = new Random();
            for (var i = 0; i < length; i++)
            {
                s += n[r.Next(0, n.Length)];
            }
            return s;
        }
    }
}
