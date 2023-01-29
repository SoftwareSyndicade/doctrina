using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using doctrine_api.Constants;

namespace doctrine_api.DataModels
{
    public class Degree
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string QUALIFICATION_ID { get; set; }

        [Required]
        public EducationLevel EDUCATION_LEVEL { get; set; }

        [Required]
        public Grades GRADES { get; set; }

        [Required]
        public DateTime CREATED_ON { get; set; }

        [ForeignKey("QUALIFICATION_ID")]
        public Qualification QUALIFICATION { get; set; }

    }
}

