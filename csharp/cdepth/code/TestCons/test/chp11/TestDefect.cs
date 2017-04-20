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
            AllUsers = { 
                new Defect{Serverity=2,Status=0,LastModified=DateTime.Now.AddDays(-30),AssignedTo="Tim",Summary="非致命缺陷1",Name="使用已释放的内存"},
                new Defect{Serverity=1,Status=1,LastModified=DateTime.Now.AddDays(-60),AssignedTo="Tim",Summary="普通缺陷1",Name="重复释放内存"},
                new Defect{Serverity=3,Status=0,LastModified=DateTime.Now.AddDays(-20),AssignedTo="Tim",Summary="字符串没有判空",Name="缓冲区溢出"},
                new Defect{Serverity=2,Status=0,LastModified=DateTime.Now.AddDays(-16),AssignedTo="Tim",Summary="内存泄露",Name="不匹配的内存释放"},
                new Defect{Serverity=1,Status=1,LastModified=DateTime.Now.AddDays(5),AssignedTo="Tim",Summary="数据转换错误",Name="内存泄漏"},
                new Defect{Serverity=2,Status=0,LastModified=DateTime.Now.AddDays(30),AssignedTo="Hans",Summary="程序内部错误",Name="资源泄漏"},
                new Defect{Serverity=3,Status=0,LastModified=DateTime.Now.AddDays(20),AssignedTo="Tim",Summary="sql问题",Name="包含动态分配内存的成员变量的类没有定义赋值操作符或拷贝构造函数"},
                new Defect{Serverity=4,Status=0,LastModified=DateTime.Now.AddDays(10),AssignedTo="Tim",Summary="数据流没有关闭",Name="空指针解引用"},
                new Defect{Serverity=2,Status=0,LastModified=DateTime.Now.AddDays(4),AssignedTo="Tim",Summary="线程死锁",Name="非法计算"},
                new Defect{Serverity=1,Status=0,LastModified=DateTime.Now.AddDays(-15),AssignedTo="Tim",Summary="严重缺陷",Name="精度丢失"},
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

    }
}
