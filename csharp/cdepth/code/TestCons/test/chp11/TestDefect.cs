using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp11
{
    public  class TestDefect
    {
        SampleData sampleData = new SampleData
        {
            Start=DateTime.Now.AddDays(-5),
            End=DateTime.Now.AddDays(5),
            AllUsers = { 
                new Defect{Serverity=2,Status=0,LastModified=DateTime.Now.AddDays(-30),AssignedTo="Tim",Summary="非致命缺陷1",Name="使用已释放的内存",Project="LanProject",Creadted=new Created{Date=DateTime.Now.AddDays(-3)}},
                new Defect{Serverity=1,Status=1,LastModified=DateTime.Now.AddDays(-60),AssignedTo="Tim",Summary="普通缺陷1",Name="重复释放内存",Project="CunProject",Creadted=new Created{Date=DateTime.Now.AddDays(-3)}},
                new Defect{Serverity=3,Status=0,LastModified=DateTime.Now.AddDays(-20),AssignedTo="Tim",Summary="字符串没有判空",Name="缓冲区溢出",Project="TanProject",Creadted=new Created{Date=DateTime.Now.AddDays(-3)}},
                new Defect{Serverity=2,Status=0,LastModified=DateTime.Now.AddDays(-16),AssignedTo="Tim",Summary="内存泄露",Name="不匹配的内存释放",Project="LanProject",Creadted=new Created{Date=DateTime.Now.AddDays(-3)}},
                new Defect{Serverity=1,Status=1,LastModified=DateTime.Now.AddDays(5),AssignedTo="Tim",Summary="数据转换错误",Name="内存泄漏",Project="ProProject",Creadted=new Created{Date=DateTime.Now.AddDays(2)}},
                new Defect{Serverity=2,Status=0,LastModified=DateTime.Now.AddDays(30),AssignedTo="Hans",Summary="程序内部错误",Name="资源泄漏",Project="LanProject",Creadted=new Created{Date=DateTime.Now.AddDays(2)}},
                new Defect{Serverity=3,Status=0,LastModified=DateTime.Now.AddDays(20),AssignedTo="Tim",Summary="sql问题",Name="包含动态分配内存的成员变量的类没有定义赋值操作符或拷贝构造函数",Project="LanProject",Creadted=new Created{Date=DateTime.Now.AddDays(2)}},
                new Defect{Serverity=4,Status=0,LastModified=DateTime.Now.AddDays(10),AssignedTo="Tim",Summary="数据流没有关闭",Name="空指针解引用",Project="LanProject",Creadted=new Created{Date=DateTime.Now.AddDays(2)}},
                new Defect{Serverity=2,Status=0,LastModified=DateTime.Now.AddDays(4),AssignedTo="Tim",Summary="线程死锁",Name="非法计算",Project="LanProject",Creadted=new Created{Date=DateTime.Now}},
                new Defect{Serverity=1,Status=0,LastModified=DateTime.Now.AddDays(-15),AssignedTo="Tim",Summary="线程死锁",Name="精度丢失",Project="CunProject",Creadted=new Created{Date=DateTime.Now}},
            },
            AllSubscriptions = { 
                new Subscription{Project="LanProject",EmailAddress="mediabugs@skeeySoft.com"},
                new Subscription{Project="LanProject",EmailAddress="testbugs@skeeySoft.com"},
                new Subscription{Project="CunProject",EmailAddress="ewrwrwr@skeeySoft.com"},
                new Subscription{Project="LanProject",EmailAddress="softbugs@skeeySoft.com"},
                new Subscription{Project="CunProject",EmailAddress="readybugs@skeeySoft.com"},
                new Subscription{Project="CunProject",EmailAddress="ouijfne@skeeySoft.com"},
                new Subscription{Project="CunProject",EmailAddress="gfserew@skeeySoft.com"},
                new Subscription{Project="CunProject",EmailAddress="werwer@skeeySoft.com"},
                new Subscription{Project="CunProject",EmailAddress="erwewr@skeeySoft.com"},
                new Subscription{Project="ProProject",EmailAddress="readybugs@skeeySoft.com"},
                new Subscription{Project="ProProject",EmailAddress="tlant@skeeySoft.com"},
                new Subscription{Project="ProProject",EmailAddress="cejarie@skeeySoft.com"},

            }
        };
        public void test() {
            var query = from defect in sampleData.AllUsers
                        where defect.Status != (int)Status.Closed
                        where defect.AssignedTo == "Tim"
                        orderby defect.Serverity descending,defect.LastModified
                        select defect;
            foreach (var defect in query) {
                Console.WriteLine("{0}:{1} ({2:d})", defect.Serverity, defect.Summary, defect.LastModified);
            }
        }
        public void test2() {
            var query = from user in sampleData.AllUsers
                        orderby user.Name.Length
                        select user.Name;
            foreach (var name in query) {
                Console.WriteLine("{0}:{1}", name, name.Length);
            }
        }
        /**
         * let 子句查询 
         * 
         * **/
        public void test3() {
            var query = from user in sampleData.AllUsers
                        let length = user.Name.Length
                        orderby length
                        select new { Name = user.Name, Length = length };
            foreach (var user in query) {
                Console.WriteLine("{0}:{1}", user.Length, user.Name);
            }
        }
        /**
         * 关联查询
         * **/
        public void test4 (){
            var query = from defect in sampleData.AllUsers
                        join subscription in sampleData.AllSubscriptions
                        on defect.Project equals subscription.Project
                        select new { defect.Summary, subscription.EmailAddress };
            foreach (var entry in query) {
                Console.WriteLine("{0}:{1}", entry.Summary, entry.EmailAddress);
            }
        }
        /**
         * join into 查询
         * 
         * 
         * */

        public void test5() {
            var query = from defect in sampleData.AllUsers
                        join subscription in sampleData.AllSubscriptions
                        on defect.Project equals subscription.Project
                        into groupedSubscriptions
                        select new { Defect = defect, Subscriptions = groupedSubscriptions };
            foreach (var entry in query) {
                Console.WriteLine(entry.Defect.Summary);
                foreach (var subscription in entry.Subscriptions) {
                    Console.WriteLine("    {0}", subscription.EmailAddress);
                }
            
            }
        }
        /**
         * 
         * 
         * 5月份每一天的创建的缺陷的数量
         * **/
        public void test6() {
            var dates = DateTimeRange(sampleData.Start, sampleData.End);
            var query = from date in dates
                        join defect in sampleData.AllUsers
                        on date.Day equals defect.Creadted.Date.Day
                        into joined
                        select new { Date = date, Count = joined.Count() };
            foreach (var entry in query) {
                Console.WriteLine("({0:d}):{1}", entry.Date, entry.Count);
            }
        }

        public IEnumerable<DateTime> DateTimeRange(DateTime start, DateTime end) {
            for (DateTime day = start; day <= end; day = day.AddDays(1))
            {
                yield return day;
            }
        }
        /**
         * 交叉查询：笛卡尔积查询
         * 
         * */
        public void test7() {
            var query = from left in Enumerable.Range(1, 4)
                        from right in Enumerable.Range(11, left)
                        select new { Left = left, Right = right };
            foreach (var entry in query) {
                Console.WriteLine("{0}:{1}", entry.Left, entry.Right);
            }
        }
        /**
         * group by 子句
         * 
         * */
        public void test8() {
            var query = from defect in sampleData.AllUsers
                        where defect.AssignedTo != null
                        group defect by defect.AssignedTo;
            foreach (var entry in query) {
                Console.WriteLine(entry.Key);
                foreach (var defect in entry) {
                    Console.WriteLine("    ({0})  {1}", defect.Serverity, defect.Summary);
                }
            }
        }
        /**
         * group by 子句 
         * 
         * 
         * */
        public void test9() {
            var query = from defect in sampleData.AllUsers
                        where defect.AssignedTo != null
                        group defect.Summary by defect.AssignedTo;
            foreach (var entry in query) {
                Console.WriteLine(entry.Key);
                foreach (var summay in entry) {
                    Console.WriteLine("    {0}", summay);
                }
            }
        }
        /**
         * 延续查询
         * 
         * */
        public void test10() {
            var query = from defect in sampleData.AllUsers
                        where defect.AssignedTo != null
                        group defect by defect.AssignedTo into grouped
                        select new { Assignes = grouped.Key, Count = grouped.Count() };
            foreach (var entry in query) {
                Console.WriteLine("{0}:{1}", entry.Assignes, entry.Count);
            }

        }
        public void test11() { 
        
        }
    }
}
