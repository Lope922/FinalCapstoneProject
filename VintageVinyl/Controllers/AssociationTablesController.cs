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
    public class AssociationTablesController : Controller
    {
        private CosignorContext db = new CosignorContext();

        // GET: AssociationTables
        public ActionResult Index()
        {
           
            var inventory = db.Inventory.Include(a => a.Albums);
            var peeps = db.Inventory.Include(b => b.Cosignors);
            //return View(inventory.ToList()); // peeps.ToList());
            return View(peeps.ToList()); // peeps.ToList());
        }

        // GET: AssociationTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociationTable associationTable = db.Inventory.Find(id);
            if (associationTable == null)
            {
                return HttpNotFound();
            }
            return View(associationTable);
        }

        // GET: AssociationTables/Create
        public ActionResult Create()
        {
            //todo check up on this here 
            ViewBag.CosignorID = new SelectList(db.Cosignors, "FirstName","CosignorID");
       //     ViewBag.AlbumID = new SelectList(db.Albums, "AlbumID", "Artist");
            return View();
        }

        // POST: AssociationTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemNum,CosignerID,AlbumID,Price,DateSold")] AssociationTable associationTable)
        {
            if (ModelState.IsValid)
            {
                db.Inventory.Add(associationTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumID", "Artist", associationTable.AlbumID);
            return View(associationTable);
        }

        // GET: AssociationTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociationTable associationTable = db.Inventory.Find(id);
            if (associationTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumID", "Artist", associationTable.AlbumID);
            return View(associationTable);
        }

        // POST: AssociationTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemNum,CosignerID,AlbumID,Price,DateSold")] AssociationTable associationTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(associationTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumID", "Artist", associationTable.AlbumID);
            return View(associationTable);
        }

        // GET: AssociationTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociationTable associationTable = db.Inventory.Find(id);
            if (associationTable == null)
            {
                return HttpNotFound();
            }
            return View(associationTable);
        }

        // POST: AssociationTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssociationTable associationTable = db.Inventory.Find(id);
            db.Inventory.Remove(associationTable);
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
