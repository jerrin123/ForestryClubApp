using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ForestryClubApp.Models;

namespace ForestryClubApp.Controllers
{
    public class House_TableController : Controller
    {
        private ForsetDbEntities db = new ForsetDbEntities();

      
        public ActionResult Index()
        {
            var house_Table = db.House_Table.Include(h => h.Category);
            return View(house_Table.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House_Table house_Table = db.House_Table.Find(id);
            if (house_Table == null)
            {
                return HttpNotFound();
            }
            return View(house_Table);
        }

        // GET: House_Table/Create
        public ActionResult Create()
        {
            ViewBag.cat_fid = new SelectList(db.Categories, "Catergory_id", "Category_name");
            return View();
        }

        // POST: House_Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "House_id,House_Name,House_Leader,Batch,cat_fid")] House_Table house_Table)
        {
            if (ModelState.IsValid)
            {
                db.House_Table.Add(house_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cat_fid = new SelectList(db.Categories, "Catergory_id", "Category_name", house_Table.cat_fid);
            return View(house_Table);
        }

        // GET: House_Table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House_Table house_Table = db.House_Table.Find(id);
            if (house_Table == null)
            {
                return HttpNotFound();
            }
            ViewBag.cat_fid = new SelectList(db.Categories, "Catergory_id", "Category_name", house_Table.cat_fid);
            return View(house_Table);
        }

        // POST: House_Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "House_id,House_Name,House_Leader,Batch,cat_fid")] House_Table house_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cat_fid = new SelectList(db.Categories, "Catergory_id", "Category_name", house_Table.cat_fid);
            return View(house_Table);
        }

        // GET: House_Table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House_Table house_Table = db.House_Table.Find(id);
            if (house_Table == null)
            {
                return HttpNotFound();
            }
            return View(house_Table);
        }

        // POST: House_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            House_Table house_Table = db.House_Table.Find(id);
            db.House_Table.Remove(house_Table);
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
