using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp12
{
    
    public class TestObservable
    {
        public void test() {
            test3(15, z: 20);
        }

        public void test2(string name,string age) {
            Console.WriteLine("{0} is {1} years old", name, age);
        }
        public void test3(int x,int y=20,int z=30) {
            Console.WriteLine("{0},{1},{1}", x, y, z);
        }
    }
}
