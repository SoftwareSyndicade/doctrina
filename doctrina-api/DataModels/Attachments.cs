using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doctrine_api.DataModels
{
    public class Attachments
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string REQUEST_ID { get; set; }

        [Required]
        public string NAME { get; set; }

        [Required]
        public byte[] CONTENT { get; set; }

        [Required]
        public string MIME_TYPE { get; set; }

        [Required]
        public DateTime CREATED_ON { get; set; }

        [ForeignKey("REQUEST_ID")]
        public AssistanceReuest ASSISTANCE_REQUEST { get; set; }
    }
}

