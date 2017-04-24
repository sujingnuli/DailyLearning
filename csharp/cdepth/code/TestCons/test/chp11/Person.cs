using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp11
{
    public class Person
    {
        public int Age { get; set; }
    }
    public class PersonTest {
        public void test() { 
           List<Person> people=new List<Person>();
           var audltName = people.Where(person => person.Age >= 18).ToList();
        }
    }
}
