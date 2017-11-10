using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CompInfo.Models;
using CompInfo.Services;

namespace CompInfo.Controllers
{
    public class SoftwareController : Controller
    {
        private CompInfoDB db = new CompInfoDB();
        private readonly ISoftwareService _softwareService = new SoftwareService();

        // GET: Software
        public ActionResult Index()
        {
            return View(_softwareService.GetAll());
        }

        // GET: Software/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoftwareViewModel software = _softwareService.FindById(id.Value);
            if (software == null)
            {
                return HttpNotFound();
            }
            return View(software);
        }

        // GET: Software/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Software/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoftwareId,Product,ProdDesc,AdvOverBeijer,AdditionalSpecs")] SoftwareViewModel software)
        {
            if (ModelState.IsValid)
            {
                _softwareService.Create(software);
                return RedirectToAction("Index");
            }

            return View(software);
        }

        // GET: Software/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoftwareViewModel software = _softwareService.FindById(id.Value);
            if (software == null)
            {
                return HttpNotFound();
            }
            return View(software);
        }

        // POST: Software/Edit/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoftwareId,Product,ProdDesc,AdvOverBeijer,AdditionalSpecs")] SoftwareViewModel software)
        {
            if (ModelState.IsValid)
            {
                _softwareService.Save(software);
                return RedirectToAction("Index");
            }
            return View(software);
        }

        // GET: Software/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoftwareViewModel software = _softwareService.FindById(id.Value);
            if (software == null)
            {
                return HttpNotFound();
            }
            return View(software);
        }

        // POST: Software/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _softwareService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
