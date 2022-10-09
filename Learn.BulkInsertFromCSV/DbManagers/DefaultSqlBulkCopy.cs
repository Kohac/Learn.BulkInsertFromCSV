using Learn.BulkInsertFromCSV.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.BulkInsertFromCSV.DbManagers
{
    internal class DefaultSqlBulkCopy
    {
        private IConfiguration _config;
        public DefaultSqlBulkCopy(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString("Default"));
        }
        public void BulkInsertData(DataTable data)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = "dbo.MockingTable";

                    bulkCopy.WriteToServer(data);
                }
            }
        }
    }
}
