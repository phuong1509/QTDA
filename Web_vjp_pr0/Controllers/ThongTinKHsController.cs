using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_vjp_pr0.Models;

namespace Web_vjp_pr0.Controllers
{
    public class ThongTinKHsController : Controller
    {
        private QLQAoEntities db = new QLQAoEntities();

        // GET: ThongTinKHs
        public ActionResult Index()
        {
            return View(db.ThongTinKHs.ToList());
        }

        // GET: ThongTinKHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinKH thongTinKH = db.ThongTinKHs.Find(id);
            if (thongTinKH == null)
            {
                return HttpNotFound();
            }
            return View(thongTinKH);
        }

        // GET: ThongTinKHs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThongTinKHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(String MaKH,String TenKH,String DiaChi,String SDT,String Email, String MatKhau)
        {
            ThongTinKH thongTinKH = new ThongTinKH();
            if (ModelState.IsValid)
            {
                thongTinKH.MaKH = MaKH;
                thongTinKH.TenKH = TenKH;
                thongTinKH.DiaChi = DiaChi;
                thongTinKH.SDT = 0;
                if(SDT != "")
                    thongTinKH.SDT = Int32.Parse(SDT);
                thongTinKH.Email = Email;
                thongTinKH.MatKhau = MatKhau;
                Console.WriteLine(thongTinKH.MaKH);
                db.ThongTinKHs.Add(thongTinKH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thongTinKH);
        }

        // GET: ThongTinKHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinKH thongTinKH = db.ThongTinKHs.Find(id);
            if (thongTinKH == null)
            {
                return HttpNotFound();
            }
            return View(thongTinKH);
        }

        // POST: ThongTinKHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,TenKH,DiaChi,SDT,Email")] ThongTinKH thongTinKH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongTinKH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thongTinKH);
        }

        // GET: ThongTinKHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinKH thongTinKH = db.ThongTinKHs.Find(id);
            if (thongTinKH == null)
            {
                return HttpNotFound();
            }
            return View(thongTinKH);
        }

        // POST: ThongTinKHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ThongTinKH thongTinKH = db.ThongTinKHs.Find(id);
            db.ThongTinKHs.Remove(thongTinKH);
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
