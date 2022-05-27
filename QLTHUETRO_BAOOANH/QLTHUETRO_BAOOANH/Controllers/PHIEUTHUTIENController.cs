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
    public class PHIEUTHUTIENController : Controller
    {
        private QL_THUETRO_BOEntities11 db = new QL_THUETRO_BOEntities11();

        // GET: PHIEUTHUTIEN
        public ActionResult Index(int ?page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 4;
            return View(db.PHIEUTHUTIENs.ToList().OrderBy(n => n.SoPhieu).ToPagedList(pageNumber, pageSize));

            //var pHIEUTHUTIENs = db.PHIEUTHUTIENs.Include(p => p.KHACHHANG).Include(p => p.NHANVIEN).Include(p => p.PHONGTRO);
            //return View(pHIEUTHUTIENs.ToList());
        }

        // GET: PHIEUTHUTIEN/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTHUTIEN pHIEUTHUTIEN = db.PHIEUTHUTIENs.Find(id);
            if (pHIEUTHUTIEN == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUTHUTIEN);
        }

        // GET: PHIEUTHUTIEN/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen");
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV");
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "MaPT");
            return View();
        }

        // POST: PHIEUTHUTIEN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoPhieu,NgayThu,ThangCanThu,TienThue,TienDien,TienNuoc,TrangThai,MaKH,MaNV,MaPT")] PHIEUTHUTIEN pHIEUTHUTIEN)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUTHUTIENs.Add(pHIEUTHUTIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", pHIEUTHUTIEN.MaKH);
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV", pHIEUTHUTIEN.MaNV);
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "MaPT", pHIEUTHUTIEN.MaPT);
            return View(pHIEUTHUTIEN);
        }

        // GET: PHIEUTHUTIEN/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTHUTIEN pHIEUTHUTIEN = db.PHIEUTHUTIENs.Find(id);
            if (pHIEUTHUTIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", pHIEUTHUTIEN.MaKH);
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV", pHIEUTHUTIEN.MaNV);
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "MaPT", pHIEUTHUTIEN.MaPT);
            return View(pHIEUTHUTIEN);
        }

        // POST: PHIEUTHUTIEN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoPhieu,NgayThu,ThangCanThu,TienThue,TienDien,TienNuoc,TrangThai,MaKH,MaNV,MaPT")] PHIEUTHUTIEN pHIEUTHUTIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUTHUTIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", pHIEUTHUTIEN.MaKH);
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV", pHIEUTHUTIEN.MaNV);
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "MaPT", pHIEUTHUTIEN.MaPT);
            return View(pHIEUTHUTIEN);
        }

        // GET: PHIEUTHUTIEN/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTHUTIEN pHIEUTHUTIEN = db.PHIEUTHUTIENs.Find(id);
            if (pHIEUTHUTIEN == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUTHUTIEN);
        }

        // POST: PHIEUTHUTIEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUTHUTIEN pHIEUTHUTIEN = db.PHIEUTHUTIENs.Find(id);
            db.PHIEUTHUTIENs.Remove(pHIEUTHUTIEN);
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
