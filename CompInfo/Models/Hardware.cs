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

        [DataType(DataType.MultilineText)]
        public string Product { get; set; }

        [DataType(DataType.MultilineText)]
        public string ProdDesc { get; set; }

        [DataType(DataType.MultilineText)]
        public string AdvOverBeijer { get; set; }

        [DataType(DataType.MultilineText)]
        public string AdditionalSpecs { get; set; }
    }
}