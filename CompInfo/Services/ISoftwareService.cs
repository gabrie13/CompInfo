using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CompInfo.Models;

namespace CompInfo.Services
{
    interface ISoftwareService
    {
        List<SoftwareViewModel> GetAll();
        SoftwareViewModel FindById(int id);
        SoftwareViewModel Create(SoftwareViewModel software);
        SoftwareViewModel Save(SoftwareViewModel software);
        void Delete(int id);
        void Dispose();
    }
}
