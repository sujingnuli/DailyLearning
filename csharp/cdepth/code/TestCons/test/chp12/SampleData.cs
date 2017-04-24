using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp12
{
    class SampleData
    {
        List<User> allUsers = new List<User>();
        public List<User> AllUsers { get { return allUsers; } }
        public SampleData GetInstance() {
            SampleData sampleData = new SampleData
            {
                AllUsers =
                {
                    new User{Name="Hans",UserType="Stu"},
                    new User{Name="Linda",UserType="Stu"},
                    new User{Name="Huliy",UserType="Teach"}
                }
            };
            return sampleData;
        }
    }
    class User {
        public string Name { get; set; }
        public string UserType { get; set; }
    }
}
