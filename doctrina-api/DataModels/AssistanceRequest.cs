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
        public bool IS_RECURRING { get; set; }

        [Required]
        public string DETAILS { get; set; }

        [Required]
        public string TUTOR { get; set; }

        public string MEETING_LINK { get; set; }

        [Required]
        public DateTime DEADLINE { get; set; }

        [Required]
        public bool COMPLETED { get; set; }

        [Required]
        public bool PAID { get; set; }
    }
}

