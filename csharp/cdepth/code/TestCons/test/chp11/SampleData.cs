using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp11
{
    public  class SampleData
    {
        List<Defect> allUsers = new List<Defect>();
        public List<Defect> AllUsers { get { return this.allUsers; } }
    }
    public class Defect {
        public int Serverity { get; set; }
        public int Status { get; set; }
        public DateTime LastModified { get; set; }
        public string AssignedTo { get; set; }
        public string Summary { get; set; }
        public string Name { get; set; }
    }
    public enum Status{
        Closed=1,
        Open=0
    }
}
