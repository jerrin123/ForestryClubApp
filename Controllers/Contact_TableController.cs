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
    public class Contact_TableController : Controller
    {
        private ForsetDbEntities db = new ForsetDbEntities();

       
        public ActionResult Index()
        {
            return View(db.Contact_Table.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact_Table contact_Table = db.Contact_Table.Find(id);
            if (contact_Table == null)
            {
                return HttpNotFound();
            }
            return View(contact_Table);
        }

        
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Contact_id,Person_Name,Person_Email,Person_Mobile,Department,Batch,Message")] Contact_Table contact_Table)
        {
            if (ModelState.IsValid)
            {
                db.Contact_Table.Add(contact_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact_Table);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact_Table contact_Table = db.Contact_Table.Find(id);
            if (contact_Table == null)
            {
                return HttpNotFound();
            }
            return View(contact_Table);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Contact_id,Person_Name,Person_Email,Person_Mobile,Department,Batch,Message")] Contact_Table contact_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact_Table);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact_Table contact_Table = db.Contact_Table.Find(id);
            if (contact_Table == null)
            {
                return HttpNotFound();
            }
            return View(contact_Table);
        }

    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact_Table contact_Table = db.Contact_Table.Find(id);
            db.Contact_Table.Remove(contact_Table);
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
