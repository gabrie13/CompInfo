using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CompInfo.Models;
using CompInfo.Controllers;

namespace CompInfo.Services
{
    public class CompetitorService : ICompetitorService
    {
        private CompInfoDB db = new CompInfoDB();

        public List<CompetitorViewModel> GetAll()
        {
            var competitorList = db.Competitors.ToList();
            return competitorList.Select(comp => CompDtO(comp)).ToList();
        }

        private static CompetitorViewModel CompDtO(Competitor comp)
        {
            return new CompetitorViewModel
            {
                CompetitorId = comp.CompetitorId,
                CompName     = comp.CompName,
                Market       = comp.Market, 
                CompUrl      = comp.CompUrl,
                BasedIn      = comp.BasedIn
            };
        }
    }
}