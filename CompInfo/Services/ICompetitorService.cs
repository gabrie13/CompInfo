using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CompInfo.Models;

namespace CompInfo.Services
{
    interface ICompetitorService
    {
        List<CompetitorViewModel> GetAll();
        CompetitorViewModel FindById(int id);
        CompetitorViewModel Create(CompetitorViewModel competitor);
        CompetitorViewModel Save(CompetitorViewModel competitor);
        void Delete(int id);
        void Dispose();

    }
}
