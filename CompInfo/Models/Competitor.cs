using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CompInfo.Models
{
    public class Competitor
    {
        public int CompetitorId { get; set; }

        public string CompName { get; set; }

        public string Market { get; set; }

        public string BasedIn { get; set; }

        public string CompUrl { get; set; }

    }
}