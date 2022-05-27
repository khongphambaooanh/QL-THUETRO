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
    public class NHANVIEN_60131724Controller : Controller
    {
        private QL_THUETRO_BOEntities11 db = new QL_THUETRO_BOEntities11();

        // GET: NHANVIEN_60131724
        public ActionResult Index()
        {
            if (Session["HoTen"] == null || Session["HoTen"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "TaiKhoan_60131724");
            }
            else
                return View(db.NHANVIENs.ToList());
        }

        //public ActionResult Index()
        //{
        //    return View(db.NHANVIENs.ToList());
        //}


        // GET: NHANVIEN_60131724/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }


        
        // GET: NHANVIEN_60131724/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NHANVIEN_60131724/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,HoTenNV,NgaySinhNV,GioiTinhNV,DiaChiNV,SdtNV,SoCMND,AnhNV")] NHANVIEN nHANVIEN)
        {
            //System.Web.HttpPostedFileBase Avatar;
            var imgMH = Request.Files["AnhNV"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgMH.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/images/" + postedFileName);
            imgMH.SaveAs(path);

            if (ModelState.IsValid)
            {
                nHANVIEN.MaNV = suaanh();
                nHANVIEN.AnhNV = postedFileName;

                db.NHANVIENs.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nHANVIEN);
        }

        // GET: NHANVIEN_60131724/Edit/5
        string suaanh()
        {
            var maMax = db.NHANVIENs.ToList().Select(n => n.MaNV).Max();
            int maNV = int.Parse(maMax.Substring(2)) + 1;
            string NV = String.Concat("0000", maNV.ToString());
            return "NV" + NV.Substring(maNV.ToString().Length - 1);
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIEN_60131724/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,HoTenNV,NgaySinhNV,GioiTinhNV,DiaChiNV,SdtNV,SoCMND,AnhNV")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nHANVIEN);
        }

        // GET: NHANVIEN_60131724/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIEN_60131724/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(nHANVIEN);
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
