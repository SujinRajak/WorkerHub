using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public partial class vw_HiringMangersList
    {
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? Availablility { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Sex { get; set; }
        public bool? InactiveUsers { get; set; }
        public string? Img { get; set; }
        public DateTime? Dob { get; set; }
        public string? Citizenship { get; set; }
        public string? FullAddress { get; set; }
        public string? Bloodgroup { get; set; }
        public string? Role { get; set; }
    }
}
