using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TestCons.test.util;

namespace TestCons.test.chp10
{
    public class tStream
    {
        public static void test() {
            WebRequest request = WebRequest.Create(@"http://www.baidu.com");
            using(WebResponse response=request.GetResponse())
            using(Stream responseStream=response.GetResponseStream())
            using (FileStream output = File.Create("response.dat")) {
                StreamUtil.Copy(responseStream, output);
            }
        }
    }
}
