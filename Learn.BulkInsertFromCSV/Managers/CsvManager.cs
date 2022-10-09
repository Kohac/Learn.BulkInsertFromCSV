using CsvHelper;
using Learn.BulkInsertFromCSV.Models;
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace Learn.BulkInsertFromCSV.Managers;

internal class CsvManager
{
    private IConfiguration? _config;

    public CsvManager(IConfiguration? config)
    {
        _config = config;
    }

    public IEnumerable<CsvMockDto> ReadMockCsv(string fileName)
    {
        IEnumerable<CsvMockDto>? records = null;
        using (var reader = new StreamReader(
            Path.Combine(
                _config.GetSection("csvSetup").GetValue<string>("path"),
                //_config.GetSection("CsvSetup").GetValue<string>("name")
                fileName
            )))
        using (var cr = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            records = cr.GetRecords<CsvMockDto>().ToList();
        }
        return records;
    }
}
