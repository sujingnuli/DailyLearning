using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp10
{
    public class People{
        public People() { }
        List<Person> persons=new List<Person>();
        public List<Person> Persons{get{return this.persons;}}
    }
    public class Person
    {
        public string Name{get;set;}
        public int Age{get;set;}
    }
    public class PeopleTest {
        public void test() {
            People people =new People{Persons={
                    new Person{Name="Hans",Age=15},
                    new Person{Name="Jan",Age=18},
                    new Person{Name="Linda",Age=20},
                  }
            };
            var adult = from per in people.Persons
                        where per.Age >= 18
                        select per.Name;
            foreach (var p in adult) {
                Console.WriteLine("Name={0}",p);
            }
      
        }
    }
}
