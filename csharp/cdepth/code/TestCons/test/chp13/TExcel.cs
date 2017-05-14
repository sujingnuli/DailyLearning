using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp13
{
   public class TExcel
    {
       public static void test() {
           Application app = new Application { Visible = true };
           app.Workbooks.Add();
           Worksheet worksheet = app.ActiveSheet;
           Range start = (Range)worksheet.Cells[1, 1];
           Range end = (Range)worksheet.Cells[1, 20];
           worksheet.Range[start, end].Value = Enumerable.Range(1, 20).ToArray();
       }
       public static void test1() {
           Application app = new Application { Visible = true };
           app.Workbooks.Add();
           Worksheet worksheet = app.ActiveSheet;
           Range start = (Range)worksheet.Cells[1, 1];
           Range end = (Range)worksheet.Cells[3, 10];
           int[,] arr=new int[3,10];
           for(int i=0;i<3;i++){
             for(int j=0;j<10;j++){
                arr[i,j]=j+1;
             }
           }
           worksheet.Range[start, end].Value = arr;
        
       }
    }
}
