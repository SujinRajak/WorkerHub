
using Microsoft.AspNetCore.Identity;
using System;

namespace Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsDeactivated { get; set; }
        public Guid? DeactivatorId { get; set; }
        public DateTime? DeactivationTime { get; set; }
        public bool ForcePasswordChange { get; set; }
        public string DialingCode { get; set; }

    }
}
