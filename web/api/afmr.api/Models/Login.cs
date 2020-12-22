using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace afmr.api.Models
{
    public class Login
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsPersisted { get; set; }
    }
}