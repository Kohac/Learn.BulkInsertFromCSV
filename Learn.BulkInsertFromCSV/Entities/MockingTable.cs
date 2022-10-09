using System;
using System.Collections.Generic;

namespace Learn.BulkInsertFromCSV.Entities
{
    public partial class MockingTable
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? IpAddress { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
