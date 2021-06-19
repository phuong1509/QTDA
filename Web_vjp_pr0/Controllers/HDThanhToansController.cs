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
    public class HDThanhToansController : Controller
    {
        private QLQAoEntities db = new QLQAoEntities();

        // GET: HDThanhToans
        public ActionResult Index()
        {
            var hDThanhToans = db.HDThanhToans.Include(h => h.ThongTinKH);
            return View(hDThanhToans.ToList());
        }

        // GET: HDThanhToans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDThanhToan hDThanhToan = db.HDThanhToans.Find(id);
            if (hDThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(hDThanhToan);
        }

        // GET: HDThanhToans/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.ThongTinKHs, "MaKH", "TenKH");
            return View();
        }

        // POST: HDThanhToans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,MaHD,CTHD")] HDThanhToan hDThanhToan)
        {
            if (ModelState.IsValid)
            {
                db.HDThanhToans.Add(hDThanhToan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.ThongTinKHs, "MaKH", "TenKH", hDThanhToan.MaKH);
            return View(hDThanhToan);
        }

        // GET: HDThanhToans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDThanhToan hDThanhToan = db.HDThanhToans.Find(id);
            if (hDThanhToan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.ThongTinKHs, "MaKH", "TenKH", hDThanhToan.MaKH);
            return View(hDThanhToan);
        }

        // POST: HDThanhToans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,MaHD,CTHD")] HDThanhToan hDThanhToan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hDThanhToan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.ThongTinKHs, "MaKH", "TenKH", hDThanhToan.MaKH);
            return View(hDThanhToan);
        }

        // GET: HDThanhToans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDThanhToan hDThanhToan = db.HDThanhToans.Find(id);
            if (hDThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(hDThanhToan);
        }

        // POST: HDThanhToans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HDThanhToan hDThanhToan = db.HDThanhToans.Find(id);
            db.HDThanhToans.Remove(hDThanhToan);
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
