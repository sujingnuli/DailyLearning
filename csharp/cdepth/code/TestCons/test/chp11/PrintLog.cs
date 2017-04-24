using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp11
{
    /**
     * 遍历目录下文件日志，并打印日志中错误部门，
     * 笛卡儿积 SelectMany 应用 linq to Object 交叉查询
     * 
     * */
    public class PrintLog
    {
        public string logDir=@"D:\log";
        public void test() {
            var query = from file in Directory.GetFiles(logDir, "*.log")
                        from line in Readlines(file)
                        let entry = new LogEntry(line)
                        where entry.Type == EntryType.Error
                        select entry;
            foreach (var entry in query) {
                Console.WriteLine("[{0}]:{1}", entry.Type, entry.Content);
            }
        }

        public static IEnumerable<string> Readlines(string file) {
        
             return    File.ReadLines(file,Encoding.GetEncoding("GB2312"));
         
        }

        public class LogEntry {
            public LogEntry(string line) {
                if (!string.IsNullOrEmpty(line.Trim()))
                {
                    string[] strs = line.Replace('[', ' ').Trim().Split(']');
                    Type = strs[0].Trim();
                    Content = strs[1].Trim();
                }
            }
            public string Type { get; set; }
            public string Content { get; set; }
        }
    }
    public class EntryType { 
       public static string Error="Error";
       public static string Warn="Warn";
       public static string  Info="Info";
       public static string Succ = "Succ";
    }
}
