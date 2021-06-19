using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Web_vjp_pr0.Models;

namespace Web_vjp_pr0.Controllers
{
    public class AcountsController : Controller
    {
        private QLQAoEntities db = new QLQAoEntities();

        // GET: Acounts
        public ActionResult Index()
        {
            if (Session["tk"] == null)
            {
                return RedirectToAction("Login", "Acounts");
            }
            return View(db.Acounts.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string taiKhoan, string matKhau)
        {
            if (ModelState.IsValid)
            {
                var mk = GetMD5(matKhau);
                var data = db.Acounts.Where(s => s.TaiKhoan.Equals(taiKhoan) && s.MatKhau.Equals(mk)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["tk"] = data.FirstOrDefault().TaiKhoan;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return View();
                }
            }
            return View();
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
 
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
                
            }
            return byte2String;
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }


        //private object GetMD5(object password)
        //{
        //    throw new NotImplementedException();
        //}


        // GET: Acounts/Details/5
        public ActionResult Details(string id)
        {
            if (Session["tk"] == null)
            {
                return RedirectToAction("Login", "Acounts");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acount acount = db.Acounts.Find(id);
            if (acount == null)
            {
                return HttpNotFound();
            }
            return View(acount);
        }

        // GET: Acounts/Create
        public ActionResult Register()
        {
            if (Session["tk"] == null)
            {
                return RedirectToAction("Login", "Acounts");
            }
            return View();
        }

        // POST: Acounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "TaiKhoan,MatKhau")] Acount acount)
        {
            if (Session["tk"] == null)
            {
                return RedirectToAction("Login", "Acounts");
            }
            var check = db.Acounts.FirstOrDefault(s => s.TaiKhoan == acount.TaiKhoan);
            if (check == null)
            {
                acount.MatKhau = GetMD5(acount.MatKhau);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Acounts.Add(acount);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.error = "Tài khoản đã tồn tại.";
                return View(acount);
            }
        }

        // GET: Acounts/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["tk"] == null)
            {
                return RedirectToAction("Login", "Acounts");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acount acount = db.Acounts.Find(id);
            if (acount == null)
            {
                return HttpNotFound();
            }
            return View(acount);
        }

        // POST: Acounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaiKhoan,MatKhau")] Acount acount)
        {
            if (Session["tk"] == null)
            {
                return RedirectToAction("Login", "Acounts");
            }
            if (ModelState.IsValid)
            {
                acount.MatKhau = GetMD5(acount.MatKhau);
                db.Entry(acount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acount);
        }

        // GET: Acounts/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["tk"] == null)
            {
                return RedirectToAction("Login", "Acounts");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acount acount = db.Acounts.Find(id);
            if (acount == null)
            {
                return HttpNotFound();
            }
            return View(acount);
        }

        // POST: Acounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (Session["tk"] == null)
            {
                return RedirectToAction("Login", "Acounts");
            }
            Acount acount = db.Acounts.Find(id);
            db.Acounts.Remove(acount);
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
