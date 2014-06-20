﻿namespace ToBeImplemented.Domain.ViewModel.Users
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}