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
    public class HeroesController : Controller
    {
        private BrandNewDayDbContext db = new BrandNewDayDbContext();

        // GET: Heroes
        public ActionResult Index()
        {
            return View(db.Heroes.ToList());
        }

        // GET: Heroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heroe heroe = db.Heroes.Find(id);
            if (heroe == null)
            {
                return HttpNotFound();
            }
            return View(heroe);
        }

        // GET: Heroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Heroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HeroeId,NombreHeroe,Alias")] Heroe heroe)
        {
            if (ModelState.IsValid)
            {
                db.Heroes.Add(heroe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(heroe);
        }

        // GET: Heroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heroe heroe = db.Heroes.Find(id);
            if (heroe == null)
            {
                return HttpNotFound();
            }
            return View(heroe);
        }

        // POST: Heroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HeroeId,NombreHeroe,Alias")] Heroe heroe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heroe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heroe);
        }

        // GET: Heroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heroe heroe = db.Heroes.Find(id);
            if (heroe == null)
            {
                return HttpNotFound();
            }
            return View(heroe);
        }

        // POST: Heroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Heroe heroe = db.Heroes.Find(id);
            db.Heroes.Remove(heroe);
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
