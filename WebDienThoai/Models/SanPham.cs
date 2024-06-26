using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebDienThoai.Models
{
    public class SanPham
    {
        public int Id { get; set; }
        public string TieuDe { get; set; }
        public int LoaiSanPhamId { get; set; }
        [ForeignKey("LoaiSanPhamId")]
        public virtual LoaiSanPham LoaiSanPham { set; get; } //khai báo mối kết hợp 1 - nhiều
        public string NoiDung { get; set; }
        public string Hinh { get; set; }
        public int donGia { get; set; }
        public int NoiBat { get; set; }
    }
}
