namespace Mvc.ViewModels
{
    public class EmployeeInfoViewModel
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
