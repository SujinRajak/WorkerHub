
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WorkerHub.Domain.Entities;

namespace Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string PermanentAddress { get; set; }
        public string TemporaryAddress { get; set; }
        public string Sex { get; set; }
        public bool InactiveUsers { get; set; }
        public string Descripition { get; set; }
        public bool Availablility { get; set; }
        public string img { get; set; }
        public DateTime dob { get; set; }
        public string citizenship { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string streetname { get; set; }
        public string states { get; set; }
        public string bloodgroup { get; set; }

    }
}
