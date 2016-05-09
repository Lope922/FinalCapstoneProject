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
    public class InventoryController : Controller
    {

		
        private CosignorContext db = new CosignorContext();

        // GET: Inventory
		// todo handle any errors that may be thrown due to unability to reach the servery 
		public ActionResult Index()
		{
			//todo fix this issue here I believe the issue is with the connection string causing this error 
			var inventory = db.Inventory.Include(a => a.Albums).Include(a => a.Cosignors);

			return View(inventory.ToList());
		}

		public ActionResult Test()
		{
			
			using (var context = new CosignorContext())
			{
				//
			//	one query to get the fk object properties from cosignors and albums class. using a lambda expression to process the LINQ query , 
				// this can also be accomplished using sql queries , that in the end also process as lamda expressions. 
				
				var variable1 = context.Inventory.Include(a => a.Albums).Include(a => a.Cosignors).ToList();	
				
				
				// fix this sql query then turn it into a proper linq query


				var sortedInventory = context.Inventory.SqlQuery("Select ItemNum, CosignorID, AlbumID, Price, DateSold from AssociationTables where DateSold IS Null Order by CosignorID");

				ViewBag.FkTable = variable1; 

				ViewBag.InvSorted = sortedInventory ; 
				// todo look up how to return a view two different objects. 
				//View data is as Dictionary passed to as view
				//return ViewData(sortedInventory, variable1); 
				return (View(ViewBag));
				//return View(sortedInventory); 
			}
		}

		


        // GET: Inventory/Details/5
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

        // GET: Inventory/Create
        public ActionResult Create()
        {
            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumID", "Artist");
            ViewBag.CosignorID = new SelectList(db.Cosignors, "CosignorID", "FirstName");
            return View();
        }

        // POST: Inventory/Create
		// binding properties to prevent overposting attacks. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemNum,CosignorID,AlbumID,Price,DateSold")] AssociationTable associationTable)
        {
            if (ModelState.IsValid)
            {
                db.Inventory.Add(associationTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumID", "Artist", associationTable.AlbumID);
            ViewBag.CosignorID = new SelectList(db.Cosignors, "CosignorID", "FirstName", associationTable.CosignorID);
            return View(associationTable);
        }

        // GET: Inventory/Edit/5
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
            ViewBag.CosignorID = new SelectList(db.Cosignors, "CosignorID", "FirstName", associationTable.CosignorID);
            return View(associationTable);
        }

        // POST: Inventory/Edit/5
       // binding properties to prevent overposting attacks. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemNum,CosignorID,AlbumID,Price,DateSold")] AssociationTable associationTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(associationTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumID", "Artist", associationTable.AlbumID);
            ViewBag.CosignorID = new SelectList(db.Cosignors, "CosignorID", "FirstName", associationTable.CosignorID);
            return View(associationTable);
        }

        // GET: Inventory/Delete/5
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

        // POST: Inventory/Delete/5
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
