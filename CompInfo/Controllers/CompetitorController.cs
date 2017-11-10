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
    public class CompetitorController : Controller
    {
        private CompInfoDB db = new CompInfoDB();
        private readonly ICompetitorService _compService = new CompetitorService();

        // GET: Competitor
        public ActionResult Index()
        {
            return View(_compService.GetAll());
        }

        // GET: Competitor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetitorViewModel competitor = _compService.FindById(id.Value);
            if (competitor == null)
            {
                return HttpNotFound();
            }
            return View(competitor);
        }

        // GET: Competitor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Competitor/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetitorId,CompName,Market,BasedIn,CompUrl")] CompetitorViewModel competitor)
        {
            if (ModelState.IsValid)
            {
                _compService.Create(competitor);
                return RedirectToAction("Index");
            }

            return View(competitor);
        }

        // GET: Competitor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetitorViewModel competitor = _compService.FindById(id.Value);
            if (competitor == null)
            {
                return HttpNotFound();
            }
            return View(competitor);
        }

        // POST: Competitor/Edit/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetitorId,CompName,Market,BasedIn,CompUrl")] CompetitorViewModel competitor)
        {
            if (ModelState.IsValid)
            {
                _compService.Save(competitor);
                return RedirectToAction("Index");
            }
            return View(competitor);
        }

        // GET: Competitor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetitorViewModel competitor = _compService.FindById(id.Value);
            if (competitor == null)
            {
                return HttpNotFound();
            }
            return View(competitor);
        }

        // POST: Competitor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _compService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _compService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
