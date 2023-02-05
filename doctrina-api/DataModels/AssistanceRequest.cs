using System;
using System.ComponentModel.DataAnnotations;
using doctrine_api.Constants;

namespace doctrine_api.DataModels
{
    public class AssistanceReuest
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public RequestCategories CATEGORY { get; set; }

        [Required]
        public EducationLevel EDUCATION_LEVEL { get; set; }

        //public bool IS_RECURRING { get; set; }

        [Required]
        public string DETAILS { get; set; }

        //public string TUTOR { get; set; }

        //public string? MEETING_LINK { get; set; }

        //public DateTime DEADLINE { get; set; }

        //public bool COMPLETED { get; set; }

        //public bool PAID { get; set; }

        [Required]
        public DateTime CREATED_ON { get; set; }

        //public string CREATED_BY { get; set; }
    }
}

