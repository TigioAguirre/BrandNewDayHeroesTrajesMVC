using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BrandNewDayHeroesMvc.Models;

namespace BrandNewDayHeroesMvc.Controllers
{
    public class TrajesController : Controller
    {
        private BrandNewDayDbContext db = new BrandNewDayDbContext();

        // GET: Trajes
        public ActionResult Index()
        {
            return View(db.Trajes.ToList());
        }

        // GET: Trajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traje traje = db.Trajes.Find(id);
            if (traje == null)
            {
                return HttpNotFound();
            }
            return View(traje);
        }

        // GET: Trajes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrajeId,Nombre")] Traje traje)
        {
            if (ModelState.IsValid)
            {
                db.Trajes.Add(traje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(traje);
        }

        // GET: Trajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traje traje = db.Trajes.Find(id);
            if (traje == null)
            {
                return HttpNotFound();
            }
            return View(traje);
        }

        // POST: Trajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrajeId,Nombre")] Traje traje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(traje);
        }

        // GET: Trajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traje traje = db.Trajes.Find(id);
            if (traje == null)
            {
                return HttpNotFound();
            }
            return View(traje);
        }

        // POST: Trajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Traje traje = db.Trajes.Find(id);
            db.Trajes.Remove(traje);
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
