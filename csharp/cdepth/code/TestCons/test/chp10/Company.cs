using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp10
{
    public class Company
    {
       // List<Dept> departments = new List<Dept>();
        public List<Dept> Departments { get; set; }
    }
    public class Dept {
        public Dept() { }
        public string Name { get; set; }
       // List<Employee> employees = new List<Employee>();
        public List<Employee> Employees { get; set; }
    }
    public class Employee {
        public double salary { get; set; }
    }

    public class ComTest {
        public void test() {
            Company company = new Company()
            {
                Departments =new List<Dept> { 
                   new Dept{Name="dept1",
                       Employees=new List<Employee>(){
                         new Employee{salary=3000},
                         new Employee{salary=2000},
                         new Employee{salary=4000},
                         new Employee{salary=7000}
                       }
                   },
                   new Dept{Name="dept2",Employees=new List<Employee>(){
                        new Employee{salary=3000},
                        new Employee{salary=4000},
                        new Employee{salary=2000}
                   }}
                }
            };

            var depts=company.Departments.Select(dept => new { dept.Name, Cost = dept.Employees.Sum(emp => emp.salary) }).OrderByDescending(dept => dept.Cost);
            foreach (var item in depts) {
                Console.WriteLine(item);
            }
        }
    }
}
