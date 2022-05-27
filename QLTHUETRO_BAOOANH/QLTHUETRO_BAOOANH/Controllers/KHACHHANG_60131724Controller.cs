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
    public class KHACHHANG_60131724Controller : Controller
    {
        private QL_THUETRO_BOEntities11 db = new QL_THUETRO_BOEntities11();

        // GET: KHACHHANG_60131724
        public ActionResult Index(int ?page)
        {
            var kHACHHANGs = db.KHACHHANGs.Include(k => k.PHONGTRO);
            int pageNumber = (page ?? 1);
            int pageSize = 3;
            return View(db.KHACHHANGs.ToList().OrderBy(n => n.MaKH).ToPagedList(pageNumber, pageSize));

        }
        //tìm kiếm phòng
        public ActionResult TimKiemKH(string sTuKhoa)
        {
            var listKH = db.KHACHHANGs.Where(n => n.HoTen.Contains(sTuKhoa));
            return View(listKH.OrderBy(n => n.HoTen));
        }

        // GET: KHACHHANG_60131724/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }



        string suaanh()
        {
            var maMax = db.KHACHHANGs.ToList().Select(n => n.MaKH).Max();
            int maKH = int.Parse(maMax.Substring(2)) + 1;
            string KH = String.Concat("0", maKH.ToString());
            return "KH" + KH.Substring(maKH.ToString().Length - 1);
        }
        // GET: KHACHHANG_60131724/Create
        public ActionResult Create()
        {
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "MaPT");
            return View();
        }

        // POST: KHACHHANG_60131724/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,HoTen,NgaySinh,GioiTinh,DiachiKH,DienThoaiKH,CMND,Email,AnhKH,MaPT")] KHACHHANG kHACHHANG)
        {
            //System.Web.HttpPostedFileBase Avatar;
            var imgMH = Request.Files["AnhKH"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgMH.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/images/" + postedFileName);
            imgMH.SaveAs(path);

            if (ModelState.IsValid)
            {
                //kHACHHANG.MaKH = suaanh();
                kHACHHANG.AnhKH = postedFileName;

                db.KHACHHANGs.Add(kHACHHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "MaPT", kHACHHANG.MaPT);
            return View(kHACHHANG);
        }

        // GET: KHACHHANG_60131724/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "MaPT", kHACHHANG.MaPT);
            return View(kHACHHANG);
        }

        // POST: KHACHHANG_60131724/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,HoTen,NgaySinh,GioiTinh,DiachiKH,DienThoaiKH,CMND,Email,AnhKH,MaPT")] KHACHHANG kHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHACHHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPT = new SelectList(db.PHONGTROes, "MaPT", "MaPT", kHACHHANG.MaPT);
            return View(kHACHHANG);
        }

        // GET: KHACHHANG_60131724/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // POST: KHACHHANG_60131724/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            db.KHACHHANGs.Remove(kHACHHANG);
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
