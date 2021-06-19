using PagedList;
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
    public class CTHDNhapsController : Controller
    {
        private QLQAoEntities db = new QLQAoEntities();

        // GET: CTHDNhaps
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.codeSort = String.IsNullOrEmpty(sortOrder) ? "asc" : "";
            ViewBag.nameSort = sortOrder == "desc_name" ? "asc_name" : "desc_name";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var cthdNhaps = db.CTHDNhaps.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                cthdNhaps = cthdNhaps.Where(t => t.MaCTHDNhap .Contains(searchString));
            }
            ViewBag.searchString = searchString;
            switch (sortOrder)
            {
                case "asc":
                    cthdNhaps = cthdNhaps.OrderByDescending(t => t.MaCTHDNhap );
                    break;
                case "asc_name":
                    cthdNhaps = cthdNhaps.OrderBy(t => t.MaHDNhap);
                    break;
                case "desc_name":
                    cthdNhaps = cthdNhaps.OrderByDescending(t => t.MaCTHDNhap);
                    break;
                default:
                    cthdNhaps = cthdNhaps.OrderBy(t => t.MaHDNhap);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(cthdNhaps.ToPagedList(pageNumber, pageSize));
        }

        // GET: CTHDNhaps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHDNhap cTHDNhap = db.CTHDNhaps.Find(id);
            if (cTHDNhap == null)
            {
                return HttpNotFound();
            }
            return View(cTHDNhap);
        }

        // GET: CTHDNhaps/Create
        public ActionResult Create()
        {
            ViewBag.MaHDNhap = new SelectList(db.HDNhaps, "MaHDNhap", "MaThuongHieu");
            ViewBag.MaHang = new SelectList(db.ThongTinHangs, "MaHang", "TenHang");
            return View();
        }

        // POST: CTHDNhaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTHDNhap,MaHDNhap,MaHang,SoLuong,DonGia,ThanhTien")] CTHDNhap cTHDNhap)
        {
            if (ModelState.IsValid)
            {
                db.CTHDNhaps.Add(cTHDNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHDNhap = new SelectList(db.HDNhaps, "MaHDNhap", "MaThuongHieu", cTHDNhap.MaHDNhap);
            ViewBag.MaHang = new SelectList(db.ThongTinHangs, "MaHang", "TenHang", cTHDNhap.MaHang);
            return View(cTHDNhap);
        }

        // GET: CTHDNhaps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHDNhap cTHDNhap = db.CTHDNhaps.Find(id);
            if (cTHDNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHDNhap = new SelectList(db.HDNhaps, "MaHDNhap", "MaThuongHieu", cTHDNhap.MaHDNhap);
            ViewBag.MaHang = new SelectList(db.ThongTinHangs, "MaHang", "TenHang", cTHDNhap.MaHang);
            return View(cTHDNhap);
        }

        // POST: CTHDNhaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTHDNhap,MaHDNhap,MaHang,SoLuong,DonGia,ThanhTien")] CTHDNhap cTHDNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTHDNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHDNhap = new SelectList(db.HDNhaps, "MaHDNhap", "MaThuongHieu", cTHDNhap.MaHDNhap);
            ViewBag.MaHang = new SelectList(db.ThongTinHangs, "MaHang", "TenHang", cTHDNhap.MaHang);
            return View(cTHDNhap);
        }

        // GET: CTHDNhaps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHDNhap cTHDNhap = db.CTHDNhaps.Find(id);
            if (cTHDNhap == null)
            {
                return HttpNotFound();
            }
            return View(cTHDNhap);
        }

        // POST: CTHDNhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CTHDNhap cTHDNhap = db.CTHDNhaps.Find(id);
            db.CTHDNhaps.Remove(cTHDNhap);
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
