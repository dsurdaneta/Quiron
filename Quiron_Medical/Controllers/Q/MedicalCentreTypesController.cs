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
    public class MedicalCentreTypesController : Controller
    {
        private QuironContext db = new QuironContext();

        // GET: MedicalCentreTypes
        public ActionResult Index()
        {
            return View(db.MedicalCentreTypes.ToList());
        }

        // GET: MedicalCentreTypes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalCentreType medicalCentreType = db.MedicalCentreTypes.Find(id);
            if (medicalCentreType == null)
            {
                return HttpNotFound();
            }
            return View(medicalCentreType);
        }

        // GET: MedicalCentreTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalCentreTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] MedicalCentreType medicalCentreType)
        {
            if (ModelState.IsValid)
            {
                db.MedicalCentreTypes.Add(medicalCentreType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicalCentreType);
        }

        // GET: MedicalCentreTypes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalCentreType medicalCentreType = db.MedicalCentreTypes.Find(id);
            if (medicalCentreType == null)
            {
                return HttpNotFound();
            }
            return View(medicalCentreType);
        }

        // POST: MedicalCentreTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] MedicalCentreType medicalCentreType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalCentreType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicalCentreType);
        }

        // GET: MedicalCentreTypes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalCentreType medicalCentreType = db.MedicalCentreTypes.Find(id);
            if (medicalCentreType == null)
            {
                return HttpNotFound();
            }
            return View(medicalCentreType);
        }

        // POST: MedicalCentreTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MedicalCentreType medicalCentreType = db.MedicalCentreTypes.Find(id);
            db.MedicalCentreTypes.Remove(medicalCentreType);
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
