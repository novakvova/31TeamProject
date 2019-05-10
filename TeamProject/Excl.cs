using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Entities;

namespace TeamProject
{
    public class Excl
    {

        DataSet dataSet = new DataSet();
        static public void WriteToExcel()
        {
            EFContext _ctx = new EFContext();
            var list =_ctx.Users.ToList();
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("DataWorksheet");
            PropertyInfo[] properties = list.First().GetType().GetProperties();
            List<string> headerNames = properties.Select(prop => prop.Name).ToList();
            for (int i = 0; i < headerNames.Count; i++)
            {
                ws.Cell(1, i + 1).Value = headerNames[i];
            }
            ws.Cell(2, 1).InsertData(list);
            wb.SaveAs(@"Users.xlsx");
            var list2 = _ctx.Autos.ToList();
             wb = new XLWorkbook();
             ws = wb.Worksheets.Add("DataWorksheet");
             properties = list2.First().GetType().GetProperties();
             headerNames = properties.Select(prop => prop.Name).ToList();
            for (int i = 0; i < headerNames.Count; i++)
            {
                ws.Cell(1, i + 1).Value = headerNames[i];
            }
            ws.Cell(2, 1).InsertData(list2);
            wb.SaveAs(@"Cars.xlsx");
        }
    }
}
