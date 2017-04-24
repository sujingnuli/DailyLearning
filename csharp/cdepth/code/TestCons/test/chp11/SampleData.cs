using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp11
{
    public  class SampleData
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        List<Defect> allUsers = new List<Defect>();
        public List<Defect> AllUsers { get { return this.allUsers; } }
        List<Subscription> allSubscriptions = new List<Subscription>();
        public List<Subscription> AllSubscriptions { get { return this.allSubscriptions; } }
    }
    public class Defect {
        public Created Creadted { get; set; }
        public int Serverity { get; set; }
        public int Status { get; set; }
        public DateTime LastModified { get; set; }
        public string AssignedTo { get; set; }
        public string Summary { get; set; }
        public string Name { get; set; }
        public string Project { get; set; }
    }
    public class Subscription{
        public string Project { get; set; }
        public string EmailAddress { get; set; }
    }
    public class Created {
        public DateTime Date { get; set; }
    }
    public enum Status{
        Closed=1,
        Open=0
    }
}
