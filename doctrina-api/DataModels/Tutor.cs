using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doctrine_api.DataModels
{
    public class Tutor
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string ACCOUNT_ID { get; set; }

        [Required]
        public DateTime CREATED_ON { get; set; }

        [ForeignKey("ACCOUNT_ID")]
        public Account ACCOUNT { get; set; }
    }
}

