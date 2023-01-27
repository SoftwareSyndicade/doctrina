
using System.ComponentModel.DataAnnotations;
using System;

namespace doctrine_api.RequestModels
{
    public class SignInRequest
    {
        [Required(ErrorMessage = "Username is required")]
        [MinLength(5, ErrorMessage = "Username must be of 5 characters.")]
        public string USERNAME { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be of 8 characters.")]
        public string PASSWORD { get; set; }
    }
}

