using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VintageVinyl.DAL;
using VintageVinyl.Models;

namespace VintageVinyl.Controllers
{
    public class CosignorsController : Controller
    {
        private CosignorContext db = new CosignorContext();

        // GET: Cosignors
        public ActionResult Index()
        {
            return View(db.Cosignors.ToList());
        }

        // GET: Cosignors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cosignor cosignor = db.Cosignors.Find(id);
            if (cosignor == null)
            {
                return HttpNotFound();
            }
            return View(cosignor);
        }

        // GET: Cosignors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cosignors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CosignorID,LastName,FirstName,PhoneNumber")] Cosignor cosignor)
        {
            if (ModelState.IsValid)
            {
                db.Cosignors.Add(cosignor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cosignor);
        }

        // GET: Cosignors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cosignor cosignor = db.Cosignors.Find(id);
            if (cosignor == null)
            {
                return HttpNotFound();
            }
            return View(cosignor);
        }

        // POST: Cosignors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CosignorID,LastName,FirstName,PhoneNumber")] Cosignor cosignor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cosignor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cosignor);
        }

        // GET: Cosignors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cosignor cosignor = db.Cosignors.Find(id);
            if (cosignor == null)
            {
                return HttpNotFound();
            }
            return View(cosignor);
        }

        // POST: Cosignors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cosignor cosignor = db.Cosignors.Find(id);
            db.Cosignors.Remove(cosignor);
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
