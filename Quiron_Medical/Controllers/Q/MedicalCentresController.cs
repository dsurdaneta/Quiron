using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quiron_Medical.Models;
using Quiron_Medical.Models.DAL;

namespace Quiron_Medical.Controllers
{
    public class MedicalCentresController : Controller
    {
        private QuironContext db = new QuironContext();

        // GET: MedicalCentres
        public ActionResult Index()
        {
            var medicalCentres = db.MedicalCentres.Include(m => m.City).Include(m => m.Type);
            return View(medicalCentres.ToList());
        }

        // GET: MedicalCentres/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalCentre medicalCentre = db.MedicalCentres.Find(id);
            if (medicalCentre == null)
            {
                return HttpNotFound();
            }
            return View(medicalCentre);
        }

        // GET: MedicalCentres/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name");
            ViewBag.MedicalCentreTypeID = new SelectList(db.MedicalCentreTypes, "ID", "Name");
            return View();
        }

        // POST: MedicalCentres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,MainPhoneNumber,PostalCode,CityID,MedicalCentreTypeID")] MedicalCentre medicalCentre)
        {
            if (ModelState.IsValid)
            {
                db.MedicalCentres.Add(medicalCentre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", medicalCentre.CityID);
            ViewBag.MedicalCentreTypeID = new SelectList(db.MedicalCentreTypes, "ID", "Name", medicalCentre.MedicalCentreTypeID);
            return View(medicalCentre);
        }

        // GET: MedicalCentres/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalCentre medicalCentre = db.MedicalCentres.Find(id);
            if (medicalCentre == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", medicalCentre.CityID);
            ViewBag.MedicalCentreTypeID = new SelectList(db.MedicalCentreTypes, "ID", "Name", medicalCentre.MedicalCentreTypeID);
            return View(medicalCentre);
        }

        // POST: MedicalCentres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,MainPhoneNumber,PostalCode,CityID,MedicalCentreTypeID")] MedicalCentre medicalCentre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalCentre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", medicalCentre.CityID);
            ViewBag.MedicalCentreTypeID = new SelectList(db.MedicalCentreTypes, "ID", "Name", medicalCentre.MedicalCentreTypeID);
            return View(medicalCentre);
        }

        // GET: MedicalCentres/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalCentre medicalCentre = db.MedicalCentres.Find(id);
            if (medicalCentre == null)
            {
                return HttpNotFound();
            }
            return View(medicalCentre);
        }

        // POST: MedicalCentres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MedicalCentre medicalCentre = db.MedicalCentres.Find(id);
            db.MedicalCentres.Remove(medicalCentre);
            db.SaveChanges();
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
