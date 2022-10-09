using Dapper.Bulk;
using Learn.BulkInsertFromCSV.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.BulkInsertFromCSV.DbManagers;

internal class DapperBulk
{
    private IConfiguration _config;
    public DapperBulk(IConfiguration config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }
    private SqlConnection GetConnection()
    {
        return new SqlConnection(_config.GetConnectionString("Default"));
    }
    public void BulkInsertData(IEnumerable<DapperMockDto> data)
    {
        using (var conn = GetConnection())
        {
            conn.Open();
            try
            {
                conn.BulkInsert<DapperMockDto>(data);
            }
            catch(SqlException sx)
            {
                Console.WriteLine(sx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }
    }
}
