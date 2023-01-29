using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using doctrine_api.Constants;

namespace doctrine_api.DataModels
{
    public class Qualification
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string TUTOR_ID { get; set; }

        [Required]
        public QualificationType QUALIFICATION_TYPE { get; set; }

        [Required]
        public string INSTITUTION { get; set; }

        [Required]
        public string TITLE { get; set; }

        [Required]
        public string FIELD { get; set; }

        [Required]
        public int NUMBER_OF_YEARS { get; set; }

        [Required]
        public DateTime CREATED_ON { get; set; }

        [ForeignKey("TUTOR_ID")]
        public Tutor TUTOR { get; set; }
    }
}

