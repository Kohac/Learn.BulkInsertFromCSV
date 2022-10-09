using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.BulkInsertFromCSV.Models;
[Table("MockingTrain")]
internal class CsvMockDto
{
    [Name("id")]
    [Column("id_try")]
    [Key]
    public long Id { get; set; }
    [Name("first_name")]
    public string? FirstName { get; set; }
    [Name("last_name")]
    public string? LastName { get; set; }
    [Name("email")]
    public string? Email { get; set; }
    [Name("gender")]
    public string? Gender { get; set; }
    [Name("wtf-aaa.")]
    public string? IpAddress { get; set; }
    [Name("sda sd")]
    public string? PhoneNumber { get; set; }

}
