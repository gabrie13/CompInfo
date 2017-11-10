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
            return competitorList.Select(comp => CompDto(comp)).ToList();
        }

        private static CompetitorViewModel CompDto(Competitor comp)
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

        public CompetitorViewModel FindById(int id)
        {
            var competitor = db.Competitors.Find(id);
            return competitor != null ? CompDto(competitor) : null;
        }

        public CompetitorViewModel Create(CompetitorViewModel competitor)
        {
            var comp = fromComp(competitor);
            db.Competitors.Add(comp);
            db.SaveChanges();

            comp.CompetitorId = competitor.CompetitorId;
            return CompDto(comp);
        }

        private static Competitor fromComp(CompetitorViewModel competitor)
        {
            var comp = new Competitor
            {
                CompetitorId = competitor.CompetitorId,
                CompName = competitor.CompName,
                Market = competitor.Market,
                CompUrl = competitor.CompUrl,
                BasedIn = competitor.BasedIn
            };
            return comp;
        }

        public CompetitorViewModel Save(CompetitorViewModel competitor)
        {
            var comp = fromComp(competitor);
            db.Entry(comp).State = EntityState.Modified;
            db.SaveChanges();

            return CompDto(comp);
        }

        public void Delete(int id)
        {
            Competitor competitor = db.Competitors.Find(id);
            db.Competitors.Remove(competitor);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}