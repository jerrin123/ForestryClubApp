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
    public class AdminTablesController : Controller
    {
        private ForsetDbEntities db = new ForsetDbEntities();

       
        public ActionResult Index()
        {
            return View(db.AdminTables.ToList());
        }

       
       

        
        public ActionResult Register()
        {
            return View();
        }

        // POST: AdminTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "AdminId,AdminUsername,AdminEmail,AdminPassword")] AdminTable adminTable)
        {
            if (ModelState.IsValid)
            {
                db.AdminTables.Add(adminTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminTable);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(AdminTable o)
        {
            int res = db.AdminTables.Where(x => x.AdminEmail == o.AdminEmail && x.AdminPassword == o.AdminPassword).Count();
            if (res == 1)
            {
                return RedirectToAction("AdminDash", "AdminTables");

            }
            else
            {
                return View();
            }
        }


      
        public ActionResult AdminDash()
        {
            return View();
        }
        // GET: AdminTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminTable adminTable = db.AdminTables.Find(id);
            if (adminTable == null)
            {
                return HttpNotFound();
            }
            return View(adminTable);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminTable adminTable = db.AdminTables.Find(id);
            if (adminTable == null)
            {
                return HttpNotFound();
            }
            return View(adminTable);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminTable adminTable = db.AdminTables.Find(id);
            db.AdminTables.Remove(adminTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
