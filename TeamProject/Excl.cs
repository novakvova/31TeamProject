using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Entities;
using TeamProject.Models;

namespace TeamProject
{
    public class Excl
    {

        DataSet dataSet = new DataSet();
        static public void WriteToExcel()
        {
            EFContext _ctx = new EFContext();
                List<UserModel> list = new List<UserModel>();
                foreach(var a in _ctx.Users.ToList())
                list.Add(new UserModel { ID = a.ID, Email = a.Email, FirstName = a.FirstName, LastName = a.LastName, Password = a.Password });
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
            List<CarModel> list2 = new List<CarModel>();
            foreach (var a in _ctx.Autos.ToList())
                list2.Add(new CarModel { ID = a.ID, Brand = a.Brand, VIN = a.VIN, GraduationYear = a.GraduationYear, StateNumber = a.StateNumber });
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
            List<BrokerModel> list3 = new List<BrokerModel>();
            foreach (var a in _ctx.Brokers.ToList())
                list3.Add(new BrokerModel { ID = a.ID, Email = a.Email, FirstName = a.FirstName, LastName = a.LastName, Password = a.Password });
            wb = new XLWorkbook();
            ws = wb.Worksheets.Add("DataWorksheet");
            properties = list3.First().GetType().GetProperties();
            headerNames = properties.Select(prop => prop.Name).ToList();
            for (int i = 0; i < headerNames.Count; i++)
            {
                ws.Cell(1, i + 1).Value = headerNames[i];
            }
            ws.Cell(2, 1).InsertData(list3);
            wb.SaveAs(@"Brokers.xlsx");
        }
    }
}
