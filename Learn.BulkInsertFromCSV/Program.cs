var serviceProvider = new ServiceCollection().RegisterServices().BuildServiceProvider();
IConfiguration? config = serviceProvider.GetService<IConfiguration>();
var dapperBulk = serviceProvider.GetService<DapperBulk>();
var defaultBulkCopy = serviceProvider.GetService<DefaultSqlBulkCopy>();
var _context = serviceProvider.GetService<ApplicationDbContext>();

//Choose count of mock file datas
string? fileName = "100_000.csv";
CsvManager csvManager = new CsvManager(config);


TimerManager.StartWatches("CSVRead");
var mockDataFromCsv = csvManager.ReadMockCsv(fileName);
TimerManager.StopWatches("CSVRead");


TimerManager.StartWatches("Custom mapping");
var dapperData = Utilities.MapCsvToDapper(mockDataFromCsv);
var efCoreData = Utilities.MapCsvToEfCore(mockDataFromCsv);
var bulkCopyData = Utilities.MapCSVToDataTable(mockDataFromCsv);
TimerManager.StopWatches("Custom mapping");

TimerManager.StartWatches("DapperBulkInsert");
dapperBulk.BulkInsertData(dapperData);
TimerManager.StopWatches("DapperBulkInsert");

TimerManager.StartWatches("EFCore");
_context.AddRange(efCoreData);
_context.SaveChanges();
TimerManager.StopWatches("EFCore");

TimerManager.StartWatches("DefaultBulkCopy");
defaultBulkCopy.BulkInsertData(bulkCopyData);
TimerManager.StopWatches("DefaultBulkCopy");


#if DEBUG
Console.ReadLine();
#endif