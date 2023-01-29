using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace doctrine_api.DataModels
{
    public class Account
    {
        [Key]
        public string ID { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(15)]
        public string USERNAME { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(25)]
        [NotMapped]
        public string PASSWORD { get; set; }

        [Required]
        public string PASSWORD_HASH { get; set; }

        [Required]
        public byte[] SALT { get; set; }

        [Required]
        public string FIRST_NAME { get; set; }

        public string? MIDDEL_NAME { get; set; }

        [Required]
        public string LAST_NAME { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PHONE_NUMBER { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public String EMAIL { get; set; }

        public byte[]? IMAGE { get; set; }

        [Required]
        public DateTime CREATED_ON { get; set; }
    }
}

