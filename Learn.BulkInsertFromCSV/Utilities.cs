using Learn.BulkInsertFromCSV.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.BulkInsertFromCSV
{
    internal static class Utilities
    {
        public static IEnumerable<DapperMockDto> MapCsvToDapper(IEnumerable<CsvMockDto> data)
        {
            return from dd in data
                               select new DapperMockDto()
                               {
                                   IdKey = dd.Id,
                                   PhoneNumber = dd.PhoneNumber,
                                   Email = dd.Email,
                                   FirstName = dd.FirstName,
                                   Gender = dd.Gender,
                                   IpAddress = dd.IpAddress,
                                   LastName = dd.LastName
                               };
        }
        public static IEnumerable<MockingTable> MapCsvToEfCore(IEnumerable<CsvMockDto> data)
        {
            return from dd in data
                   select new MockingTable()
                   {
                       Id = dd.Id + 100001,
                       PhoneNumber = dd.PhoneNumber,
                       Email = dd.Email,
                       FirstName = dd.FirstName,
                       Gender = dd.Gender,
                       IpAddress = dd.IpAddress,
                       LastName = dd.LastName
                   };
        }
        public static DataTable MapCSVToDataTable(IEnumerable<CsvMockDto> data)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("Email");
            dt.Columns.Add("Gender");
            dt.Columns.Add("IpAddress");
            dt.Columns.Add("PhoneNumber");

            foreach (var item in data)
            {
                dt.Rows.Add(item.Id + 200001, item.FirstName,item.LastName,item.Email,item.Gender, item.IpAddress,item.PhoneNumber);
            }
            return dt;
        }
    }
}
