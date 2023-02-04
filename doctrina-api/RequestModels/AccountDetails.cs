using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using doctrine_api.Constants;

namespace doctrine_api.RequestModels
{
    public class AccountDetails
    {
        [Required(ErrorMessage = "First name is manhdatory field.")]
        public string FIRST_NAME { get; set; }

        public string? MIDDLE_NAME { get; set; }

        [Required(ErrorMessage = "Last name is mandatory field.")]
        public string LAST_NAME { get; set; }

        [Required(ErrorMessage = "Username is mandatory field.")]
        [MinLength(6, ErrorMessage = "Minimum length for username is 6 characters.")]
        [MaxLength(15, ErrorMessage = "Maximum length for username is 15 characters.")]
        public string USERNAME { get; set; }

        [Required(ErrorMessage = "Password is mandatory field.")]
        [MinLength(8, ErrorMessage = "Minimum length for password is 8 characters.")]
        [MaxLength(25, ErrorMessage = "Maximum length for password is 25 characters.")]
        public string PASSWORD { get; set; }

        [Required(ErrorMessage = "Phone number is mandatory field.")]
        public string PHONE_NUMBER { get; set; }

        [Required(ErrorMessage = "E-mail is mandatory field.")]
        [DataType(DataType.EmailAddress)]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "Account type required")]
        public AccountTypes ACCOUNT_TYPE { get; set; }
    }
}

