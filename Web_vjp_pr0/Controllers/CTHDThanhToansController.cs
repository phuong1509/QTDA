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
    public class CTHDThanhToansController : Controller
    {
        private QLQAoEntities db = new QLQAoEntities();

        // GET: CTHDThanhToans
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
            var cthdThanhToans = db.CTHDThanhToans.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                cthdThanhToans = cthdThanhToans.Where(t => t.MaCTHDThanhToan.Contains(searchString));
            }
            ViewBag.searchString = searchString;
            switch (sortOrder)
            {
                case "asc":
                    cthdThanhToans = cthdThanhToans.OrderByDescending(t => t.MaCTHDThanhToan);
                    break;
                case "asc_name":
                    cthdThanhToans = cthdThanhToans.OrderBy(t => t.MaHD);
                    break;
                case "desc_name":
                    cthdThanhToans = cthdThanhToans.OrderByDescending(t => t.MaCTHDThanhToan);
                    break;
                default:
                    cthdThanhToans = cthdThanhToans.OrderBy(t => t.MaHD);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(cthdThanhToans.ToPagedList(pageNumber, pageSize));
        }

        // GET: CTHDThanhToans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHDThanhToan cTHDThanhToan = db.CTHDThanhToans.Find(id);
            if (cTHDThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(cTHDThanhToan);
        }

        // GET: CTHDThanhToans/Create
        public ActionResult Create()
        {
            ViewBag.MaHD = new SelectList(db.HDThanhToans, "MaHD", "MaKH");
            ViewBag.MaHang = new SelectList(db.ThongTinHangs, "MaHang", "TenHang");
            return View();
        }

        // POST: CTHDThanhToans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTHDThanhToan,MaHD,MaHang,SL,DonGia,ThanhTien")] CTHDThanhToan cTHDThanhToan)
        {
            if (ModelState.IsValid)
            {
                db.CTHDThanhToans.Add(cTHDThanhToan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHD = new SelectList(db.HDThanhToans, "MaHD", "MaKH", cTHDThanhToan.MaHD);
            ViewBag.MaHang = new SelectList(db.ThongTinHangs, "MaHang", "TenHang", cTHDThanhToan.MaHang);
            return View(cTHDThanhToan);
        }

        // GET: CTHDThanhToans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHDThanhToan cTHDThanhToan = db.CTHDThanhToans.Find(id);
            if (cTHDThanhToan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHD = new SelectList(db.HDThanhToans, "MaHD", "MaKH", cTHDThanhToan.MaHD);
            ViewBag.MaHang = new SelectList(db.ThongTinHangs, "MaHang", "TenHang", cTHDThanhToan.MaHang);
            return View(cTHDThanhToan);
        }

        // POST: CTHDThanhToans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTHDThanhToan,MaHD,MaHang,SL,DonGia,ThanhTien")] CTHDThanhToan cTHDThanhToan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTHDThanhToan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHD = new SelectList(db.HDThanhToans, "MaHD", "MaKH", cTHDThanhToan.MaHD);
            ViewBag.MaHang = new SelectList(db.ThongTinHangs, "MaHang", "TenHang", cTHDThanhToan.MaHang);
            return View(cTHDThanhToan);
        }

        // GET: CTHDThanhToans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHDThanhToan cTHDThanhToan = db.CTHDThanhToans.Find(id);
            if (cTHDThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(cTHDThanhToan);
        }

        // POST: CTHDThanhToans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CTHDThanhToan cTHDThanhToan = db.CTHDThanhToans.Find(id);
            db.CTHDThanhToans.Remove(cTHDThanhToan);
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
