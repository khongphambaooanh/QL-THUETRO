using QLTHUETRO_BAOOANH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QLTHUETRO_BAOOANH.Controllers
{
    public class DatPhongController : Controller
    {
        private QL_THUETRO_BOEntities11 db = new QL_THUETRO_BOEntities11();
        // GET: DatPhong
        public ActionResult datphong(string maPT)
        { 
            Session.Add("MaPT", maPT);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> xacnhandatphong([Bind(Include = "HoTen,NgaySinh,GioiTinh,DiachiKH,DienThoaiKH,CMND,Email,MaPT")] KHACHHANG khachhang)
        {
            
                khachhang.MaKH = generateID();
                khachhang.MaPT = (string)Session["MaPT"];
                List<KHACHHANG> list = db.KHACHHANGs.ToList();
                db.KHACHHANGs.Add(khachhang);

                DATPHONG datphong = new DATPHONG();
                datphong.MaKH = khachhang.MaKH;
                datphong.MaPT = (string)Session["MaPT"];
                datphong.NgayDat = DateTime.Now;

                db.DATPHONGs.Add(datphong);

                await db.SaveChangesAsync();
                return RedirectToAction("datphongthanhcong");
            
           
        }
        public ActionResult datphongthanhcong()
        {
            return View();
        }
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }

    }
}