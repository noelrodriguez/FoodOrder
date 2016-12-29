using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodOrder.Data_Access;
using FoodOrder.Models;

namespace FoodOrder.Controllers
{
    public class MenuItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MenuItem
        public ActionResult Index()
        {
            var menuItem = db.MenuItem.Include(m => m.Subcategory);
            return View(menuItem.ToList());
        }

        // GET: MenuItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItem.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        // GET: MenuItem/Create
        public ActionResult Create()
        {
            ViewBag.SubcategoryId = new SelectList(db.Subcategory, "Id", "Name");
            return View();
        }

        // POST: MenuItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubcategoryId,Name,Price,Description,Size")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                db.MenuItem.Add(menuItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubcategoryId = new SelectList(db.Subcategory, "Id", "Name", menuItem.SubcategoryId);
            return View(menuItem);
        }

        // GET: MenuItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItem.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubcategoryId = new SelectList(db.Subcategory, "Id", "Name", menuItem.SubcategoryId);
            return View(menuItem);
        }

        // POST: MenuItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubcategoryId,Name,Price,Description,Size")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubcategoryId = new SelectList(db.Subcategory, "Id", "Name", menuItem.SubcategoryId);
            return View(menuItem);
        }

        // GET: MenuItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItem.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        // POST: MenuItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuItem menuItem = db.MenuItem.Find(id);
            db.MenuItem.Remove(menuItem);
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
