//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLTHUETRO_BAOOANH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HOPDONG
    {
        public string MaHD { get; set; }
        public Nullable<System.DateTime> NgayTaoHD { get; set; }
        public Nullable<decimal> TienCoc { get; set; }
        public string GhiChu { get; set; }
        public string MaPT { get; set; }
        public string MaNV { get; set; }
        public string MaKH { get; set; }
    
        public virtual KHACHHANG KHACHHANG { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
        public virtual PHONGTRO PHONGTRO { get; set; }
    }
}
