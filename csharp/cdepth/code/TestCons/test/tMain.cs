using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCons.test.chp10;
using TestCons.test.chp11;
using TestCons.test.chp12;

namespace TestCons.test
{
    public class tMain
    {
        public static void Main(string[] args) {

            TestObservable TO = new TestObservable();
            TO.test();
            Console.ReadKey();
            
        }
        
    }
}
