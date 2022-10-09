using System.ComponentModel.DataAnnotations.Schema;

namespace Learn.BulkInsertFromCSV.Models;

[Table("MockingTable")]
internal class DapperMockDto
{
    
    [Column("Id")]
    public long IdKey { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Gender { get; set; }
    public string? IpAddress { get; set; }
    public string? PhoneNumber { get; set; }

}
