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
    public class AlbumsController : Controller
    {
        private CosignorContext db = new CosignorContext();

        // GET: Albums
        // trying out the search feature 
        public ActionResult Index(string albumNameq, string searchString)
        {
            
            var albumList = new List<string>();

            // retrieves the list of albums from the db 
            var albumsQuery = from d in db.Albums orderby d.AlbumName select d.AlbumName;

            
            albumList.AddRange(albumsQuery.Distinct());
            ViewBag.albumName = new SelectList(albumList);

            var albums = from a in db.Albums
                         select a;
            
            
            if (!String.IsNullOrEmpty(searchString))
            {
            
                //  this only searches for the album. I would eventually like to add the ability to search by album title or artist from combobox selection 
                albums = albums.Where(s => s.Artist.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(albumNameq))
            {
                albums = albums.Where(x => x.AlbumName == albumNameq);
            }
            return View(albums);
            //return View(db.Albums.ToList());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AlbumName,Artist,DateIn,DateOut")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(album);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumID,AlbumName,Artist,DateIn")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
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
