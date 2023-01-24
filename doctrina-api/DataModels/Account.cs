using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace doctrine_api.DataModels
{
    public class Account
    {
        [Key]
        public int ID { get; set; }

        [NotNull]
        public string FIRST_NAME { get; set; }

        public string? MIDDEL_NAME { get; set; }

        [NotNull]
        public string LAST_NAME { get; set; }

        [NotNull]
        [DataType(DataType.PhoneNumber)]
        public int PHONE_NUMBER { get; set; }

        [NotNull]
        [DataType(DataType.EmailAddress)]
        public String EMAIL { get; set; }

        public byte[]? IMAGE { get; set; }
    }
}

