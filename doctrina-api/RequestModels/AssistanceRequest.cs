using System;
using System.ComponentModel.DataAnnotations;
using doctrine_api.Constants;

namespace doctrine_api.RequestModels
{
    public class AssistanceRequest
    {
        public string DETAILS { get; set; }

        [Required]
        public RequestCategories REQUEST_CATEGORY { get; set; }

        [Required]
        public EducationLevel EDUCATION_LEVEL { get; set; }
    }
}

