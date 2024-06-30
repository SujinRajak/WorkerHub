using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class vw_UserRoles
    {
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; }
        public string? RoleId { get; set; }
    }
}
