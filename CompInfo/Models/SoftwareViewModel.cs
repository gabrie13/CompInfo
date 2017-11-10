using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CompInfo.Models
{
    public class SoftwareViewModel
    {
        [Key]
        public int SoftwareId { get; set; }

        public string Product { get; set; }

        [Display(Name = "Product Description")]
        public string ProdDesc { get; set; }

        [Display(Name = "Advantage over Beijer")]
        public string AdvOverBeijer { get; set; }

        [Display(Name = "Additional Specs")]
        public string AdditionalSpecs { get; set; }
    }
}