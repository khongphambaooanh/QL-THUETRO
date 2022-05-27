using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLTHUETRO_BAOOANH.Models;
using PagedList;
using PagedList.Mvc;


namespace QLTHUETRO_BAOOANH.Controllers
{
    public class HOPDONGController : Controller
    {
        private QL_THUETRO_BOEntities11 db = new QL_THUETRO_BOEntities11();

        // GET: HOPDONG
        public ActionResult Index(/*int ?page*/)
        {
            //int pageNumber = (page ?? 1);
            //int pageSize = 3;
            //return View(db.HOPDONGs.ToList().OrderBy(n => n.MaHD).ToPagedList(pageNumber, pageSize));

            var hOPDONGs = db.HOPDONGs.Include(h => h.KHACHHANG).Include(h => h.NHANVIEN).Include(h => h.PHONGTRO);
            return View(hOPDONGs.ToList());
        }

        // GET: HOPDONG/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOPDONG hOPDONG = db.HOPDONGs.Find(id);
            if (hOPDONG == null)
            {
                return HttpNotFound();
            }
            return View(hOPDONG);
        }

        // GET: HOPDONG/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen");
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV");
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "MaPT");
            return View();
        }

        // POST: HOPDONG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,NgayTaoHD,TienCoc,GhiChu,MaPT,MaNV,MaKH")] HOPDONG hOPDONG)
        {
            if (ModelState.IsValid)
            {
                db.HOPDONGs.Add(hOPDONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", hOPDONG.MaKH);
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV", hOPDONG.MaNV);
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "MaPT", hOPDONG.MaPT);
            return View(hOPDONG);
        }

        // GET: HOPDONG/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOPDONG hOPDONG = db.HOPDONGs.Find(id);
            if (hOPDONG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", hOPDONG.MaKH);
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV", hOPDONG.MaNV);
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "MaPT", hOPDONG.MaPT);
            return View(hOPDONG);
        }

        // POST: HOPDONG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,NgayTaoHD,TienCoc,GhiChu,MaPT,MaNV,MaKH")] HOPDONG hOPDONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOPDONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", hOPDONG.MaKH);
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV", hOPDONG.MaNV);
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "MaPT", hOPDONG.MaPT);
            return View(hOPDONG);
        }

        // GET: HOPDONG/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOPDONG hOPDONG = db.HOPDONGs.Find(id);
            if (hOPDONG == null)
            {
                return HttpNotFound();
            }
            return View(hOPDONG);
        }

        // POST: HOPDONG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOPDONG hOPDONG = db.HOPDONGs.Find(id);
            db.HOPDONGs.Remove(hOPDONG);
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
