using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLTHUETRO_BAOOANH.Models;

namespace QLTHUETRO_BAOOANH.Controllers
{
    public class BIENBAN_60131724Controller : Controller
    {
        private QL_THUETRO_BOEntities11 db = new QL_THUETRO_BOEntities11();

        // GET: BIENBAN_60131724
        public ActionResult Index()
        {
            var bIENBANSUCOes = db.BIENBANSUCOes.Include(b => b.KHACHHANG).Include(b => b.NHANVIEN).Include(b => b.PHONGTRO).Include(b => b.SUCO);
            return View(bIENBANSUCOes.ToList());
        }

        // GET: BIENBAN_60131724/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIENBANSUCO bIENBANSUCO = db.BIENBANSUCOes.Find(id);
            if (bIENBANSUCO == null)
            {
                return HttpNotFound();
            }
            return View(bIENBANSUCO);
        }

        // GET: BIENBAN_60131724/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen");
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV");
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "MaPT");
            ViewBag.MaSC = new SelectList(db.SUCOes, "MaSC", "TenSC");
            return View();
        }

        // POST: BIENBAN_60131724/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoBB,NgayLap,LyDo,HinhThucXuLy,MaSC,MaPT,MaNV,MaKH")] BIENBANSUCO bIENBANSUCO)
        {
            if (ModelState.IsValid)
            {
                db.BIENBANSUCOes.Add(bIENBANSUCO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", bIENBANSUCO.MaKH);
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV", bIENBANSUCO.MaNV);
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "MaPT", bIENBANSUCO.MaPT);
            ViewBag.MaSC = new SelectList(db.SUCOes, "MaSC", "TenSC", bIENBANSUCO.MaSC);
            return View(bIENBANSUCO);
        }

        // GET: BIENBAN_60131724/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIENBANSUCO bIENBANSUCO = db.BIENBANSUCOes.Find(id);
            if (bIENBANSUCO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", bIENBANSUCO.MaKH);
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV", bIENBANSUCO.MaNV);
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "MaPT", bIENBANSUCO.MaPT);
            ViewBag.MaSC = new SelectList(db.SUCOes, "MaSC", "TenSC", bIENBANSUCO.MaSC);
            return View(bIENBANSUCO);
        }

        // POST: BIENBAN_60131724/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoBB,NgayLap,LyDo,HinhThucXuLy,MaSC,MaPT,MaNV,MaKH")] BIENBANSUCO bIENBANSUCO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bIENBANSUCO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", bIENBANSUCO.MaKH);
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV", bIENBANSUCO.MaNV);
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "MaPT", bIENBANSUCO.MaPT);
            ViewBag.MaSC = new SelectList(db.SUCOes, "MaSC", "TenSC", bIENBANSUCO.MaSC);
            return View(bIENBANSUCO);
        }

        // GET: BIENBAN_60131724/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIENBANSUCO bIENBANSUCO = db.BIENBANSUCOes.Find(id);
            if (bIENBANSUCO == null)
            {
                return HttpNotFound();
            }
            return View(bIENBANSUCO);
        }

        // POST: BIENBAN_60131724/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BIENBANSUCO bIENBANSUCO = db.BIENBANSUCOes.Find(id);
            db.BIENBANSUCOes.Remove(bIENBANSUCO);
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
