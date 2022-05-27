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
    public class Admin_60131724Controller : Controller
    {
        private QL_THUETRO_BOEntities11 db = new QL_THUETRO_BOEntities11();

        // GET: Admin_60131724
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(FormCollection collection)
        {
            var tendn = collection["username"];
            var matkhau = collection["password"];
            if (string.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Vui lòng điền username!";
            }
            else if (string.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Password không được bỏ trống!";
            }
            else
            {
                //gán giá trị và lấy session
                Admin admin = db.Admins.SingleOrDefault(n => n.UserAdmin == tendn && n.PassAdmin == matkhau);
                if (admin != null)
                {
                    ViewBag.thongbao = "Bạn đã đăng nhập thành công";
                    Session["TaiKhoan"] = admin;
                    return RedirectToAction("Index", "Admin_60131724");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng, vui lòng nhập lại!";
            }
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult phongtro(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 2;
            return View(db.PHONGTROes.ToList().OrderBy(n => n.MaPT).ToPagedList(pageNumber, pageSize));
        }




        // GET: Admin_60131724/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }


        string suaanh()
        {
            var maMax = db.PHONGTROes.ToList().Select(n => n.MaPT).Max();
            int maPT = int.Parse(maMax.Substring(2)) + 1;
            string PT = String.Concat("0", maPT.ToString());
            return "PT" + PT.Substring(maPT.ToString().Length - 1);
        }

        // GET: PHONGTRO_60131724/Create
        public ActionResult Create()
        {
            ViewBag.MaLPT = new SelectList(db.LOAIPHONGTROes, "MaLPT", "TenLPT");
            return View();
        }

        // POST: PHONGTRO_60131724/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPT,DienTich,TiecIch,DonGia,TrangThai,NgayCapNhat,AnhPT,MaLPT")] PHONGTRO pHONGTRO)
        {
            //System.Web.HttpPostedFileBase Avatar;
            var imgMH = Request.Files["AnhPT"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgMH.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/images/" + postedFileName);
            imgMH.SaveAs(path); 

            if (ModelState.IsValid)
            {
                pHONGTRO.MaPT = suaanh();
                pHONGTRO.AnhPT = postedFileName;

                db.PHONGTROes.Add(pHONGTRO);
                db.SaveChanges();
                return RedirectToAction("phongtro");
            }

            ViewBag.MaLPT = new SelectList(db.LOAIPHONGTROes, "MaLPT", "TenLPT", pHONGTRO.MaLPT);
            return View(pHONGTRO);
        }

        // GET: PHONGTRO_60131724/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONGTRO pHONGTRO = db.PHONGTROes.Find(id);
            if (pHONGTRO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLPT = new SelectList(db.LOAIPHONGTROes, "MaLPT", "TenLPT", pHONGTRO.MaLPT);
            return View(pHONGTRO);
        }

        // POST: PHONGTRO_60131724/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPT,DienTich,TiecIch,DonGia,TrangThai,NgayCapNhat,AnhPT,MaLPT")] PHONGTRO pHONGTRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHONGTRO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("phongtro");
            }
            ViewBag.MaLPT = new SelectList(db.LOAIPHONGTROes, "MaLPT", "TenLPT", pHONGTRO.MaLPT);
            return View(pHONGTRO);
        }

        // GET: PHONGTRO_60131724/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONGTRO pHONGTRO = db.PHONGTROes.Find(id);
            if (pHONGTRO == null)
            {
                return HttpNotFound();
            }
            return View(pHONGTRO);
        }

        // POST: PHONGTRO_60131724/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHONGTRO pHONGTRO = db.PHONGTROes.Find(id);
            db.PHONGTROes.Remove(pHONGTRO);
            db.SaveChanges();
            return RedirectToAction("phongtro", "Admin_60131724");
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
