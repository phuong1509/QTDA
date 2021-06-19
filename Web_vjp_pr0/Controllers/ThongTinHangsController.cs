using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_vjp_pr0.Models;
using PagedList;

namespace Web_vjp_pr0.Controllers
{
    public class ThongTinHangsController : Controller
    {
        private QLQAoEntities db = new QLQAoEntities();

        // GET: ThongTinHangs
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
            var thongTinHangs = db.ThongTinHangs.Include(t => t.LoaiHang).Include(t => t.Size).Include(t => t.ThuongHieu);
            if (!String.IsNullOrEmpty(searchString))
            {
                thongTinHangs = thongTinHangs.Where(t => t.MaHang.Contains(searchString));
            }
            ViewBag.searchString = searchString;
            switch (sortOrder)
            {
                case "asc":
                    thongTinHangs = thongTinHangs.OrderByDescending(t => t.MaHang);
                    break;
                case "asc_name":
                    thongTinHangs = thongTinHangs.OrderBy(t => t.TenHang);
                    break;
                case "desc_name":
                    thongTinHangs = thongTinHangs.OrderByDescending(t => t.TenHang);
                    break;
                default:
                    thongTinHangs = thongTinHangs.OrderBy(t => t.MaHang);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(thongTinHangs.ToPagedList(pageNumber, pageSize));
        }

        // GET: ThongTinHangs/Details/5
        public ActionResult Details(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinHang thongTinHang = db.ThongTinHangs.Find(id);
            if (thongTinHang == null)
            {
                return HttpNotFound();
            }
            return View(thongTinHang);
        }

        // GET: ThongTinHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiHang = new SelectList(db.LoaiHangs, "MaLoaiHang", "TenLoaiHang");
            ViewBag.MaSize = new SelectList(db.Sizes, "MaSize", "MaSize");
            ViewBag.MaThuongHieu = new SelectList(db.ThuongHieux, "MaThuongHieu", "TenThuongHieu");
            return View();
        }

        // POST: ThongTinHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase anh, ThongTinHang thongTinHang)
        {
            if (anh != null)
            {
                string path = Path.Combine(Server.MapPath("~/Anh"), Path.GetFileName(anh.FileName));
                anh.SaveAs(path);
                thongTinHang.Anh = anh.FileName;
            }
            if (ModelState.IsValid)
            {
                db.ThongTinHangs.Add(thongTinHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiHang = new SelectList(db.LoaiHangs, "MaLoaiHang", "TenLoaiHang", thongTinHang.MaLoaiHang);
            ViewBag.MaSize = new SelectList(db.Sizes, "MaSize", "MaSize", thongTinHang.MaSize);
            ViewBag.MaThuongHieu = new SelectList(db.ThuongHieux, "MaThuongHieu", "TenThuongHieu", thongTinHang.MaThuongHieu);
            return View(thongTinHang);
        }

        // GET: ThongTinHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinHang thongTinHang = db.ThongTinHangs.Find(id);
            if (thongTinHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiHang = new SelectList(db.LoaiHangs, "MaLoaiHang", "TenLoaiHang", thongTinHang.MaLoaiHang);
            ViewBag.MaSize = new SelectList(db.Sizes, "MaSize", "MaSize", thongTinHang.MaSize);
            ViewBag.MaThuongHieu = new SelectList(db.ThuongHieux, "MaThuongHieu", "TenThuongHieu", thongTinHang.MaThuongHieu);
            return View(thongTinHang);
        }

        // POST: ThongTinHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHang,TenHang,MaLoaiHang,MaSize,DonGia,MaThuongHieu,Anh,SoLuong")] ThongTinHang thongTinHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongTinHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiHang = new SelectList(db.LoaiHangs, "MaLoaiHang", "TenLoaiHang", thongTinHang.MaLoaiHang);
            ViewBag.MaSize = new SelectList(db.Sizes, "MaSize", "MaSize", thongTinHang.MaSize);
            ViewBag.MaThuongHieu = new SelectList(db.ThuongHieux, "MaThuongHieu", "TenThuongHieu", thongTinHang.MaThuongHieu);
            return View(thongTinHang);
        }

        // GET: ThongTinHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinHang thongTinHang = db.ThongTinHangs.Find(id);
            if (thongTinHang == null)
            {
                return HttpNotFound();
            }
            return View(thongTinHang);
        }

        // POST: ThongTinHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThongTinHang thongTinHang = db.ThongTinHangs.Find(id);
            db.ThongTinHangs.Remove(thongTinHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetSearchValue(string search)
        {
            List<ThongTinHang> allsearch = db.ThongTinHangs.Where(x => x.TenHang.Contains(search)).ToList();
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
