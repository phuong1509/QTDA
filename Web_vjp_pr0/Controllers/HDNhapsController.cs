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
    public class HDNhapsController : Controller
    {
        private QLQAoEntities db = new QLQAoEntities();

        // GET: HDNhaps
        public ActionResult Index()
        {
            var hDNhaps = db.HDNhaps.Include(h => h.NhanVien);
            return View(hDNhaps.ToList());
        }

        // GET: HDNhaps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDNhap hDNhap = db.HDNhaps.Find(id);
            if (hDNhap == null)
            {
                return HttpNotFound();
            }
            return View(hDNhap);
        }

        // GET: HDNhaps/Create
        public ActionResult Create()
        {
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien");
            return View();
        }

        // POST: HDNhaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHDNhap,MaThuongHieu,TongTien,GhiChu,MaNhanVien,NgayNhap")] HDNhap hDNhap)
        {
            if (ModelState.IsValid)
            {
                db.HDNhaps.Add(hDNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", hDNhap.MaNhanVien);
            return View(hDNhap);
        }

        // GET: HDNhaps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDNhap hDNhap = db.HDNhaps.Find(id);
            if (hDNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", hDNhap.MaNhanVien);
            return View(hDNhap);
        }

        // POST: HDNhaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHDNhap,MaThuongHieu,TongTien,GhiChu,MaNhanVien,NgayNhap")] HDNhap hDNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hDNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", hDNhap.MaNhanVien);
            return View(hDNhap);
        }

        // GET: HDNhaps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDNhap hDNhap = db.HDNhaps.Find(id);
            if (hDNhap == null)
            {
                return HttpNotFound();
            }
            return View(hDNhap);
        }

        // POST: HDNhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HDNhap hDNhap = db.HDNhaps.Find(id);
            db.HDNhaps.Remove(hDNhap);
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
