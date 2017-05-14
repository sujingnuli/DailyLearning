using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace TestWeb.cs
{
    public class ExcelUtil
    {
        public static void ExportExcel(List<System.Data.DataTable> dts) {
            if (dts == null ||dts.Count== 0)
                return;
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null) {
                return;
            }
            System.Globalization.CultureInfo CurrentCI = new System.Globalization.CultureInfo("en-US");
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Range range;
            long rowRead = 0;
            float percent = 0;
            for (int mk = 1; mk < dts.Count+1; mk++)
            {
               System.Data.DataTable dt = dts[mk-1];
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(workbook.Worksheets.get_Item(mk));
                worksheet.Name = dt.Rows[1]["Name"].ToString();       
                long totalCount = dt.Rows.Count;
                string[] titles = new string[] { "序号", "昵称", "日期", "内容", "状态" };
                //首行标题
                range = worksheet.get_Range("A1", "E1");
                range.ClearContents();
                range.MergeCells = true;
                worksheet.Cells[1, 1] = "计划表 — " + dt.Rows[1]["Name"].ToString();
                range = worksheet.Cells[1, 1];
                range.Font.Name = "黑体";
                range.Font.Size = 15;
                range.Font.Bold = 25;
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                range.RowHeight = 60;
                range.Borders.LineStyle =  Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                range.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, System.Drawing.Color.Red.ToArgb());
                //range.Borders.Weight = 5;
                //第二合并行
                range = worksheet.get_Range("A2", "E2");
                range.ClearContents();
                range.MergeCells = true;
                worksheet.Cells[1][2] = "报表生成于:" + DateTime.Now.ToString();
                range = worksheet.Cells[1][2];
                range.Font.Name = "宋体";
                range.Font.Color = Color.Red;
                range.Font.Size = 10;
                range.HorizontalAlignment = 4;// Microsoft.Office.Interop.Excel.XlVAlign.X;
                range.RowHeight = 30;
                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
               // range.Borders.Weight = 3;
                //标题行
                for (int i = 0; i < titles.Length; i++)
                {
                    worksheet.Cells[3, i + 1] = titles[i];
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[3, i + 1];
                    range.Interior.ColorIndex = 41;
                    range.Font.Bold = true;
                    range.Borders.LineStyle =  Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                   // range.Borders.Weight = 2;
                    if (i == 2)
                    {
                        range.Columns.ColumnWidth = 15;
                    }
                    if (i == 3)
                    {
                        range.Columns.ColumnWidth = 40;
                    }
                }
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (i == 2)
                        {
                            range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[r + 4, i + 1];
                            range.NumberFormat = @"yyyy-mm-dd";
                            worksheet.Cells[r + 4, i + 1] = Convert.ToDateTime(dt.Rows[r][i]).ToString("yyyy-MM-dd");
                        }
                        else if(i!=dt.Columns.Count-1)
                        {
                            worksheet.Cells[r + 4, i + 1] = dt.Rows[r][i].ToString();
                        }
                        range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[r + 4, i + 1];
                        range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        if (r % 2 == 1)
                        {
                            range.Interior.ColorIndex = 24;
                        }
                    }
                   
                    rowRead++;
                    percent = ((float)(100 * rowRead) / totalCount);
                   
                }
            }
            xlApp.Visible = true;
            workbook.Saved = true;
            string filepath = @"D:\myProject\excel\"+DateTime.Now.ToString("yyyyMMdd")+"_Plan.xlsx";
            if (File.Exists(filepath)) {
                try
                {
                    File.Delete(filepath);
                }
                catch (Exception e) {
                    throw new Exception("文件正在使用中");
                }
             }
            workbook.SaveCopyAs(filepath);
            workbook.Close(false, Type.Missing, Type.Missing);
            workbook = null;
            xlApp.Quit();
            xlApp = null;
        }
    }
}