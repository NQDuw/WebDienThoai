using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebDienThoai.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int IdSanPham { get; set; }
        [ForeignKey("IdSanPham")]
        public virtual SanPham SanPham { set; get; } //khai báo mối kết hợp 1 - nhiều
        public string NoiDung { get; set; }
       
    }
}
