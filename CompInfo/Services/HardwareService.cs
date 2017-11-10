using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CompInfo.Models;

namespace CompInfo.Services
{
    public class HardwareService : IHardwareService
    {
        private CompInfoDB db = new CompInfoDB();

        public List<HardwareViewModel> GetAll()
        {
            var hardwareList = db.Hardwares.ToList();
            return hardwareList.Select(hard => HardDto(hard)).ToList();
        }

        private static HardwareViewModel HardDto(Hardware hard)
        {
            return new HardwareViewModel
            {
                HardwareId = hard.HardwareId,
                Product = hard.Product,
                ProdDesc = hard.ProdDesc,
                AdditionalSpecs = hard.AdditionalSpecs,
                AdvOverBeijer = hard.AdvOverBeijer
            };
        }

        public HardwareViewModel FindById(int id)
        {
            var hardware = db.Hardwares.Find(id);
            return hardware != null ? HardDto(hardware) : null;
        }

        public HardwareViewModel Create(HardwareViewModel hardware)
        {
            var hard = FromHard(hardware);
            db.Hardwares.Add(hard);
            db.SaveChanges();

            hard.HardwareId = hardware.HardwareId;
            return HardDto(hard);
        }

        private static Hardware FromHard(HardwareViewModel hardware)
        {
            var hard = new Hardware
            {
              HardwareId = hardware.HardwareId,
              Product = hardware.Product,
              ProdDesc = hardware.ProdDesc,
              AdditionalSpecs = hardware.AdditionalSpecs,
              AdvOverBeijer = hardware.AdvOverBeijer
            };
            return hard;
        }

        public HardwareViewModel Save(HardwareViewModel hardware)
        {
            var hard = FromHard(hardware);
            db.Entry(hard).State = EntityState.Modified;
            db.SaveChanges();
            return HardDto(hard);
        }

        public void Delete(int id)
        {
            Hardware hardware = db.Hardwares.Find(id);
            db.Hardwares.Remove(hardware);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}