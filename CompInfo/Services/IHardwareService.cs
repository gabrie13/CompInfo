using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CompInfo.Models;

namespace CompInfo.Services
{
    interface IHardwareService
    {
        List<HardwareViewModel> GetAll();
        HardwareViewModel FindById(int id);
        HardwareViewModel Create(HardwareViewModel hardware);
        HardwareViewModel Save(HardwareViewModel hardware);
        void Delete(int id);
        void Dispose();
    }
}
