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
    public class UsersController : Controller
    {
        private ForsetDbEntities db = new ForsetDbEntities();

        
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

       
        public ActionResult SignUP()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUP([Bind(Include = "UserId,UserName,UserEmail,UserPassword,UserDepartment")] User user)
        {
            if (ModelState.IsValid)
            {

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult LogIn(User c)
        {
            var cust = db.Users.Where(x => x.UserEmail == c.UserEmail && x.UserPassword == c.UserPassword).Count();
            var id = db.Users.Where(x => x.UserEmail == c.UserEmail && x.UserPassword == c.UserPassword).Select(v => v.UserId).FirstOrDefault();
            var idd = db.Users.FirstOrDefault(x => x.UserEmail == c.UserEmail && x.UserPassword == c.UserPassword);
            Session["CID"] = id;
            Session["CIDD"] = idd;
            if (cust > 0)
            {
                Session["ID"] = cust;
                //Response.Write("<script>alert('Invalid Username/Password'); </script>");
                return RedirectToAction("UserDash", "Users");
            }
            else
            {

                return View();
            }
        }

        public ActionResult Logout()
        {


            Session["ID"] = null;
            return RedirectToAction("Index", "Home");

        }
        public ActionResult UserDash()
        {

            return View(); 
        }
        
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
