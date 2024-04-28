using System.ComponentModel.DataAnnotations;

namespace EmailHandler
{
    internal class EmailConfiguration
    {
        [Required]
        public string From { get; set; }
        [Required]
        public string Host { get; set; }
        [Required]
        public int Port { get; set; }
        //[Required]
        public string Username { get; set; }
        //[Required]
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
    }
}
