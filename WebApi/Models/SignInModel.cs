﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class SignInModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
