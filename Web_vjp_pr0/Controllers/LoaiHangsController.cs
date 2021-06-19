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
    public class LoaiHangsController : Controller
    {
        private QLQAoEntities db = new QLQAoEntities();

        // GET: LoaiHangs
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
            var loaiHangs = db.LoaiHangs.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                loaiHangs = loaiHangs.Where(t => t.TenLoaiHang.Contains(searchString));
            }
            ViewBag.searchString = searchString;
            switch (sortOrder)
            {
                case "asc":
                    loaiHangs = loaiHangs.OrderByDescending(t => t.MaLoaiHang);
                    break;
                case "asc_name":
                    loaiHangs = loaiHangs.OrderBy(t => t.TenLoaiHang);
                    break;
                case "desc_name":
                    loaiHangs = loaiHangs.OrderByDescending(t => t.TenLoaiHang);
                    break;
                default:
                    loaiHangs = loaiHangs.OrderBy(t => t.MaLoaiHang);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(loaiHangs.ToPagedList(pageNumber, pageSize));
        }

        // GET: LoaiHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHang loaiHang = db.LoaiHangs.Find(id);
            if (loaiHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiHang);
        }

        // GET: LoaiHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiHang,TenLoaiHang")] LoaiHang loaiHang)
        {
            if (ModelState.IsValid)
            {
                db.LoaiHangs.Add(loaiHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiHang);
        }

        // GET: LoaiHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHang loaiHang = db.LoaiHangs.Find(id);
            if (loaiHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiHang);
        }

        // POST: LoaiHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiHang,TenLoaiHang")] LoaiHang loaiHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiHang);
        }

        // GET: LoaiHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHang loaiHang = db.LoaiHangs.Find(id);
            if (loaiHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiHang);
        }

        // POST: LoaiHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiHang loaiHang = db.LoaiHangs.Find(id);
            db.LoaiHangs.Remove(loaiHang);
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
