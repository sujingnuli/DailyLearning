using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp13
{
    class Configuration
    {
        public  int agentThreads { get; set; }
        public  string agentThreadName { get; set; }

        public static  Configuration FromScriptScope(ScriptScope scope){
            Configuration con = new Configuration
            {
                  agentThreads=scope.GetVariable("agentThreads"),
                  agentThreadName=scope.GetVariable("agentThreadName")
            };
            return con;
        }
    }
}
