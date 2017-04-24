using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestCons.test.LTSClaz;

namespace TestCons.test.chp11
{
    public class TestLts
    {
        public void test() {
            using (var context = new DefectModelDataContext()) {
                context.Log = Console.Out;
                User time = context.User.Where(user => user.Name == "tim").Single();
                var query = from defect in context.Defect
                            where defect.Status != false
                            where defect.AssignedToUserID == time.UserID
                            select defect.Summary;
                foreach (var summary in query) {
                    Console.WriteLine(summary);
                }


            }
        }
        public void test2() {
            using (var context = new DefectModelDataContext()) {
                context.Log = Console.Out;
                var query = from user in context.User
                            let length = user.Name.Length
                            orderby length
                            select new { user.Name, Length = length };
                foreach (var entry in query) {
                    Console.WriteLine("  {0}:{1}", entry.Name, entry.Length);
                }
            }
        }

        public void test3() {
            using (var context = new DefectModelDataContext()) {
                context.Log = Console.Out;
                var query = from defect in context.Defect
                            join subscription in context.NotificationSubscription
                            on defect.ProjectID equals subscription.ProjectID
                            select new { defect.Summary, subscription.EmailAddress };
                foreach (var entry in query) {
                    Console.WriteLine("{0}:{1}", entry.Summary, entry.EmailAddress);
                }
            }
        }

        public void test4() {
            using (var context = new DefectModelDataContext()) {
                context.Log = Console.Out;
                var query = from defect in context.Defect
                            join subscription in context.NotificationSubscription
                            on defect.ProjectID equals subscription.ProjectID
                            into groupedSubscription
                            select new { Defect = defect, Subscription=groupedSubscription };
                foreach (var entry in query) {
                    Console.WriteLine(entry.Defect.Summary);
                    foreach (var subscription in entry.Subscription) {
                        Console.WriteLine(subscription.EmailAddress);
                    }
                }


            }
        }


    }
}
