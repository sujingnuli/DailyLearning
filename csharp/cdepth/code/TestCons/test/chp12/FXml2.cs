using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestCons.test.chp12
{
    public class FXml2
    {
        public void test() {
            SampleData sd = new SampleData().GetInstance();
            var users = new XElement("users",
                   sd.AllUsers.Select(user =>
                        new XElement("user",
                                new XAttribute("name", user.Name),
                                new XAttribute("type", user.UserType)
                             )
                   )
                );
            Console.WriteLine(users);
        }
        public void test2() {
            SampleData sd = new SampleData().GetInstance();
            var users = new XElement("developers",
                    from user in sd.AllUsers
                    where user.UserType == "Stu"
                    select new XElement("developer", user.Name)
                );
            Console.WriteLine(users);
        }
    }
}
