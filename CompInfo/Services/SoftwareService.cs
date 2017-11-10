using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CompInfo.Models;


namespace CompInfo.Services
{
    public class SoftwareService : ISoftwareService
    {
        private CompInfoDB db = new CompInfoDB();

        public List<SoftwareViewModel> GetAll()
        {
            var softwareList = db.Softwares.ToList();
            return softwareList.Select(soft => SoftDto(soft)).ToList();
        }

        private static SoftwareViewModel SoftDto(Software soft)
        {
            return new SoftwareViewModel
            {
              SoftwareId = soft.SoftwareId,
              Product = soft.Product,
              ProdDesc = soft.ProdDesc,
              AdditionalSpecs = soft.AdditionalSpecs,
              AdvOverBeijer = soft.AdvOverBeijer
            };
        }

        public SoftwareViewModel FindById(int id)
        {
            var software = db.Softwares.Find(id);
            return software != null ? SoftDto(software) : null;
        }

        public SoftwareViewModel Create(SoftwareViewModel software)
        {
            var soft = FromSoft(software);
            db.Softwares.Add(soft);
            db.SaveChanges();

            soft.SoftwareId = software.SoftwareId;
            return SoftDto(soft);
        }

        private static Software FromSoft(SoftwareViewModel software)
        {
            var soft = new Software
            {
                SoftwareId      = software.SoftwareId,
                Product         = software.Product,
                ProdDesc        = software.ProdDesc,
                AdditionalSpecs = software.AdditionalSpecs,
                AdvOverBeijer   = software.AdvOverBeijer
            };
            return soft;

        }

        public SoftwareViewModel Save(SoftwareViewModel software)
        {
            var soft = FromSoft(software);
            db.Entry(soft).State = EntityState.Modified;
            db.SaveChanges();

            return SoftDto(soft);
        }

        public void Delete(int id)
        {
            Software software = db.Softwares.Find(id);
            db.Softwares.Remove(software);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}