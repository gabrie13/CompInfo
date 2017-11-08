using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CompInfo.Models
{
    public class CompetitorViewModel
    {
        [Key]
        public int    CompetitorId { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompName { get; set; }

        public string Market { get; set; }

        [Display(Name = "Based In")]
        public string BasedIn { get; set; }

        [Display(Name = "Url")]
        public string CompUrl { get; set; }
    }
}