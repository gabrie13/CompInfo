using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CompInfo.Models
{
    public class Hardware
    {
        [Key]
        public int HardwareId { get; set; }

        public string Product { get; set; }

        public string ProdDesc { get; set; }

        public string AdvOverBeijer { get; set; }

        public string AdditionalSpecs { get; set; }
    }
}