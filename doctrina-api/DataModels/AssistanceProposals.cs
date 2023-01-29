using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doctrine_api.DataModels
{
    public class AssistanceProposals
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string REQUEST_ID { get; set; }

        [Required]
        public string TUTOR { get; set; }

        [Required]
        public string ACTIVE { get; set; }

        [Required]
        public int HOURS { get; set; }

        [Required]
        public double COST { get; set; }

        [Required]
        public double PERHOUR_RATE { get; set; }

        public double DISCOUNT { get; set; }

        [Required]
        public string AVAILABILITY { get; set; }

        [Required]
        public DateTime CREATED_ON { get; set; }

        [Required]
        public string CREATED_BY { get; set; }

        [ForeignKey("REQUEST_ID")]
        public AssistanceReuest ASSISTANCE_REQUEST { get; set; }
    }
}

