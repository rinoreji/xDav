using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace XDav.Helper
{
    public static class GeneralHelper
    {
        /// <summary>
        ///	Retrieve's a file's custom property information file path (*.property)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetCustomPropertyInfoFilePath(string filePath)
        {
            string _propFilePath = null;

            FileInfo _fileInfo = new FileInfo(filePath);
            if (_fileInfo.Exists)
                _propFilePath = _fileInfo.FullName + "._.property";

            return _propFilePath;
        }

        internal static HttpVerb GetVerb(string verb)
        {
            switch (verb.ToUpper())
            {
                case "POST" :
                    return HttpVerb.POST;
                case "GET" :
                    return HttpVerb.GET;
                case "PUT":
                    return HttpVerb.PUT;
                case "DELETE" :
                   return HttpVerb.DELETE;
                case "LOCK":
                    return HttpVerb.LOCK;
                case "UNLOCK":
                    return HttpVerb.UNLOCK;
                case "OPTIONS":
                    return HttpVerb.OPTIONS;
                case "HEAD":
                    return HttpVerb.HEAD;
                default:
                    return HttpVerb.GET;
            }
        }
        
        /// <summary>
        /// Compute hash for string encoded as UTF8
        /// </summary>
        /// <param name="s">String to be hashed</param>
        /// <returns>32-character hex string</returns>
        public static string Md5HashStringForUtf8String(string s)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(s);

            MD5 md5 = MD5.Create();
            byte[] hashBytes = md5.ComputeHash(bytes);

            var result = HexStringFromBytes(hashBytes);
            return result;
        }

        /// <summary>
        /// Convert an array of bytes to a string of hex digits
        /// </summary>
        /// <param name="bytes">Array of bytes</param>
        /// <returns>
        /// String of hex digits
        /// </returns>
        public static string HexStringFromBytes(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string hex in bytes.Select(b => b.ToString("x2")))
                sb.Append(hex);
            return sb.ToString();
        }
    }
}
