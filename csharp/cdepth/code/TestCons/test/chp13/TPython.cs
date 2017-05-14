using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp13
{
    public  class TPython
    {
        public void test() {
            ScriptEngine engine = Python.CreateEngine();
            engine.Execute("print 'Hello World!'");
            engine.ExecuteFile("tt.py");
        }
        /**
         * ScriptEngine,ScripeScope
         * 
         * */
        public void test2() {
            string python = @"
text='Hello'
output=input+1
";
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            scope.SetVariable("input", 10);
            engine.Execute(python, scope);
            Console.WriteLine(scope.GetVariable("text"));
            Console.WriteLine(scope.GetVariable("output"));
            Console.WriteLine(scope.GetVariable("input"));

        }
        /**
         * 调用python脚本中的方法
         * */
        public void test3() {
            string python = @"
def sayHello(user):print 'Hello %(name)s' %{'name':user}
";
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            engine.Execute(python, scope);
            dynamic function = scope.GetVariable("sayHello");
            function("Jon");
        }

        public void test4() {
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            engine.ExecuteFile("app.py", scope);
            Configuration con= Configuration.FromScriptScope(scope);
            Console.WriteLine("ThreadName=" + con.agentThreadName + ",Threads=" + con.agentThreads);
        }
    }
}
