using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestCons.test.chp12
{
   public  class FXml
    {
       public void test() {
           XElement x = new XElement("root",
                       new XElement("child",
                               new XElement("grandChild", "text")
                           ),
                       new XElement("other-child")
                  );
          Console.WriteLine( x.ToString());
       }
    }
}
