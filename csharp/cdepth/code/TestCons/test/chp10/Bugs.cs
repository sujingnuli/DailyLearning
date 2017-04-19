using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp10
{
    /**
     * 统计一个程序员有几个Bug。并按照数量排序
     **/
    public class Bugs
    {
        List<Bug> bugs = new List<Bug>();
        public List<Bug> Bugz { get { return this.bugs; } }

        public int Count() {
            return this.bugs.Count;
        }
    }
    public class Bug {
        public string Name { get; set; }
        public string Developer { get; set; }
    }

    public class BugTest {
        public void test() {
            Bugs bugs = new Bugs
            {
                Bugz =
                {
                   new Bug{Name="b0",Developer="lily"},
                   new Bug{Name="b0",Developer="Hans"},
                   new Bug{Name="b2",Developer="lily"},
                   new Bug{Name="b1",Developer="Hans"},
                   new Bug{Name="b1",Developer="Dan"},
                   new Bug{Name="b1",Developer="Jane"},
                   new Bug{Name="b2",Developer="Dane"},
                   new Bug{Name="b3",Developer="lily"},
                   new Bug{Name="b2",Developer="Hans"},
                   new Bug{Name="b4",Developer="lily"},
                }
            };

           var bc= bugs.Bugz.GroupBy(bug => bug.Developer).Select(list => new
            {
                Name = list.Key,
                Count = list.Count()
            }).OrderByDescending(x => x.Count);

            foreach(var item in bc){
                Console.WriteLine("bug's Developer:{0} ,bug's Count:{1}", item.Name, item.Count);
            }
        }
    }
}
