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
    public class DATPHONG_60131724Controller : Controller
    {
        private QL_THUETRO_BOEntities11 db = new QL_THUETRO_BOEntities11();

        // GET: DATPHONG_60131724
        public ActionResult CheckOut()
        {
            
            return View("CheckOut");
        }

        // GET: DATPHONG_60131724/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATPHONG dATPHONG = db.DATPHONGs.Find(id);
            if (dATPHONG == null)
            {
                return HttpNotFound();
            }
            return View(dATPHONG);
        }

        // GET: DATPHONG_60131724/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen");
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "DienTich");
            return View();
        }

        // POST: DATPHONG_60131724/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDP,NgayDat,MaPT,MaKH")] DATPHONG dATPHONG)
        {
            if (ModelState.IsValid)
            {
                db.DATPHONGs.Add(dATPHONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", dATPHONG.MaKH);
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "DienTich", dATPHONG.MaPT);
            return View(dATPHONG);
        }

        // GET: DATPHONG_60131724/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATPHONG dATPHONG = db.DATPHONGs.Find(id);
            if (dATPHONG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", dATPHONG.MaKH);
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "DienTich", dATPHONG.MaPT);
            return View(dATPHONG);
        }

        // POST: DATPHONG_60131724/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDP,NgayDat,MaPT,MaKH")] DATPHONG dATPHONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dATPHONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", dATPHONG.MaKH);
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "DienTich", dATPHONG.MaPT);
            return View(dATPHONG);
        }

        // GET: DATPHONG_60131724/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATPHONG dATPHONG = db.DATPHONGs.Find(id);
            if (dATPHONG == null)
            {
                return HttpNotFound();
            }
            return View(dATPHONG);
        }

        // POST: DATPHONG_60131724/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DATPHONG dATPHONG = db.DATPHONGs.Find(id);
            db.DATPHONGs.Remove(dATPHONG);
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
