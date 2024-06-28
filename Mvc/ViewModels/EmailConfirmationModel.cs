namespace Mvc.ViewModels
{
    public class EmailConfirmationModel
    {
        public string UserName { get; set; }
        public string EmailConfirmationLink { get; set; }
        public string LoginUrl { get; set; }
        public string Password { get; set; }

    }
}
