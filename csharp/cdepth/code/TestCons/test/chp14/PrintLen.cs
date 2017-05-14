using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp14
{
    public class PrintLen
    {
        public async static Task<int> GetPageLengthAsync(string url) {
            using (HttpClient client = new HttpClient()) {
                Task<string> fetchString = client.GetStringAsync(url);
                
                int length = (await fetchString).Length;
                return length;
            }
        }
        public  void test() {
            Task<int> fetchLength = GetPageLengthAsync("http://www.baidu.com");
            Console.WriteLine(fetchLength.Result);
        }
    }
}
