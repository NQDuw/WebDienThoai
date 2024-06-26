using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebDienThoai.Models
{
    public class LoaiSanPham
    {

        public int Id { get; set; }
        public int TheLoaiId { get; set; }

        [ForeignKey("TheLoaiId")]
        public virtual TheLoai TheLoai { set; get; } //khai báo mối kết hợp 1 - nhiều

        [Required(ErrorMessage = "Chưa nhập dữ liệu"), StringLength(200)]
        public string Ten { get; set; }

    }
}
