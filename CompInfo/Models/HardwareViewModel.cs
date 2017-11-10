﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CompInfo.Models
{
    public class HardwareViewModel
    {
        [Key]
        public int HardwareId { get; set; }

        public string Product { get; set; }

        [Display(Name = "Product Decription")]
        public string ProdDesc { get; set; }

        [Display(Name = "Beijer Advantages")]
        public string AdvOverBeijer { get; set; }

        [Display(Name = "Additional Specs")]
        public string AdditionalSpecs { get; set; }

    }
}