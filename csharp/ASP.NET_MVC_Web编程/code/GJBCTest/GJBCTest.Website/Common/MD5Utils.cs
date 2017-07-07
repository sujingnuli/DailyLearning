using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace GJBCTest.Website.Common
{
    public class MD5Utils
    {
        //32位 MD5加密
        public static string GetMD5_32(string input) {
            if (string.IsNullOrEmpty(input)) { return string.Empty; }
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(input));
            StringBuilder sb=new StringBuilder();
            for (int i = 0; i < data.Length; i++) {
                sb.Append(data[i].ToString("x2"));//整齐十六进制。例如由0xA=>0x0A
            }
            return sb.ToString();
        }

        public static string GetMD5_16(string input) {
            return GetMD5_32(input).Substring(8, 16);
        }

        public static string GetMD5_8(string input) {
            return GetMD5_32(input).Substring(8, 8);
        }
    }
}