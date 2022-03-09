using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CreateUserLibrary.Model
{
    internal class RegistrationForm
    {
        [Required]
        internal string DisplayName { get; set; }
        [Required]
        internal string UserName { get; set; }
        [Required]
        internal string Email { get; set; }
        [Required]
        internal string Password { get; set; }
    }
}
