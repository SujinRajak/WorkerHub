﻿using System.ComponentModel.DataAnnotations;

namespace Mvc.ViewModels
{
    public class SignUpViewModel
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;
    }
}
