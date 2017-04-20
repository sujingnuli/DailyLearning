using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp11
{
    public class CastT
    {
        public void test() {
            ArrayList list = new ArrayList { "First", "Second", "Third" };
            var strs = from string str in list
                       select str.Substring(0, 3);
            foreach (string str in strs) {
                Console.WriteLine(str);
            }
        }

        /**
         * 该段代码转义后的表达式： 
         *      var strs=list.Cast<string>().Select(str=>str.Substring(0,3));
         * 
         **/
    }
}
