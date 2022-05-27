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
using System.Threading.Tasks;

namespace QLTHUETRO_BAOOANH.Controllers
{
    public class PHONGTRO_60131724Controller : Controller
    {
        private QL_THUETRO_BOEntities11 db = new QL_THUETRO_BOEntities11();

        // GET: PHONGTRO_60131724
        private List<PHONGTRO> Layphongmoi(int count)
        {
            //sắp xếp phòng mới nhất
            return db.PHONGTROes.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        public async Task<ActionResult> danhsach(int? page)
        {
            List<PHONGTRO> ds = await db.PHONGTROes.Where(phong => phong.TrangThai == "Còn trống").ToListAsync();

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            //var phongmoi = Layphongmoi(30);
            return View(ds.ToPagedList(pageNumber, pageSize));  //hiển thị cập nhật mới nhất

            //return View(db.PHONGTROes.ToList()); //hiển thị tất cả các phòng
        }
        public ActionResult Loaiphong()   //phòng theo loại
        {
            var loaiphong = from lp in db.LOAIPHONGTROes select lp;
            return PartialView(loaiphong);
        }
        public async Task<ActionResult> SPtheoloaiphong(string id)
        {
            List<PHONGTRO> ph = await db.PHONGTROes.Where(phong => phong.TrangThai == "Còn trống" && phong.MaLPT == id ).ToListAsync();
            //var sPtheoloaiphong = from sp in db.PHONGTROes where sp.MaLPT == id select sp;
            return View(ph);
        }

        //tìm kiếm phòng
        public async Task<ActionResult> KQTimKiem(string sTuKhoa)
        {
            List<PHONGTRO> ds = await db.PHONGTROes.Where(phong => phong.TrangThai == "Còn trống" && phong.TiecIch.Contains(sTuKhoa)).ToListAsync();
            //var listSP = db.PHONGTROes.Where(n => n.TiecIch.Contains(sTuKhoa));
            return View(ds.OrderBy(n => n.TiecIch));
        }


        public ActionResult Index()
        {
            var pHONGTROes = db.PHONGTROes.Include(p => p.LOAIPHONGTRO);
            return View(pHONGTROes.ToList());
        }

        // GET: PHONGTRO_60131724/Details/5
        public ActionResult Details(string id)
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


        string suaanh()
        {
            var maMax = db.PHONGTROes.ToList().Select(n => n.MaPT).Max();
            int maPT = int.Parse(maMax.Substring(2)) + 1;
            string PT = String.Concat("0000", maPT.ToString());
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
            //Lấy thông tin từ input type=file 
            string postedFileName = System.IO.Path.GetFileName(imgMH.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/images/" + postedFileName);
            imgMH.SaveAs(path);

            if (ModelState.IsValid)
            {
                //pHONGTRO.MaPT = suaanh();
                pHONGTRO.AnhPT = postedFileName;

                db.PHONGTROes.Add(pHONGTRO);
                db.SaveChanges();
                return RedirectToAction("phongtro", "Admin_60131724");
            }

            ViewBag.MaLPT = new SelectList(db.LOAIPHONGTROes, "MaLPT", "TenLPT", pHONGTRO.MaLPT);
            return View(pHONGTRO);
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
