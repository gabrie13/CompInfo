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
    public class HardwareController : Controller
    {
        private CompInfoDB db = new CompInfoDB();
        private readonly IHardwareService _hardwareService = new HardwareService();

        // GET: Hardware
        public ActionResult Index()
        {
            return View(_hardwareService.GetAll());
        }

        // GET: Hardware/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HardwareViewModel hardware = _hardwareService.FindById(id.Value);
            if (hardware == null)
            {
                return HttpNotFound();
            }
            return View(hardware);
        }

        // GET: Hardware/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hardware/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HardwareId,Product,ProdDesc,AdvOverBeijer,AdditionalSpecs")] HardwareViewModel hardware)
        {
            if (ModelState.IsValid)
            {
                _hardwareService.Create(hardware);
                return RedirectToAction("Index");
            }

            return View(hardware);
        }

        // GET: Hardware/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HardwareViewModel hardware = _hardwareService.FindById(id.Value);
            if (hardware == null)
            {
                return HttpNotFound();
            }
            return View(hardware);
        }

        // POST: Hardware/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HardwareId,Product,ProdDesc,AdvOverBeijer,AdditionalSpecs")] HardwareViewModel hardware)
        {
            if (ModelState.IsValid)
            {
                _hardwareService.Save(hardware);
                return RedirectToAction("Index");
            }
            return View(hardware);
        }

        // GET: Hardware/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HardwareViewModel hardware = _hardwareService.FindById(id.Value);
            if (hardware == null)
            {
                return HttpNotFound();
            }
            return View(hardware);
        }

        // POST: Hardware/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _hardwareService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _hardwareService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
