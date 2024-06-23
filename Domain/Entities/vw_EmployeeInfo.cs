using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class vw_EmployeeInfo
    {
        public string Id { get; set; } = null!;
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? Availablility { get; set; }
        public string? Img { get; set; }
        public bool? Locked { get; set; }
        public string? Role { get; set; }
    }
}
