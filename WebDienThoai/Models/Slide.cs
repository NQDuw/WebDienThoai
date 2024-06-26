using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebDienThoai.Models
{
    public class Slide
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Chưa nhập dữ liệu"), StringLength(200)]
        public string Ten { get; set; }
        public string Hinh { get; set; }
    }
}
