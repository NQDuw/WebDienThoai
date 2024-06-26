using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebDienThoai.Models;

namespace WebDienThoai.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ManagerController : Controller
    {
        
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hosting;
        public ManagerController(ApplicationDbContext db, IHostingEnvironment hosting)
        {
            _db = db;
            _hosting = hosting;
        }
        //Hiển thị danh sách sản phẩm
        public IActionResult Index(int? page, string textsearch = "")
        {
            var pageIndex = (int)(page != null ? page : 1);
            var pageSize = 10;
            var sanPhamList = _db.SanPham.Include(x => x.LoaiSanPham).Where(p => p.TieuDe.ToLower().Contains(textsearch.ToLower())).ToList();
            //Thống kê số trang
            //var pageSum =(int) Math.Ceiling((Decimal)productList.Count / pagesize);
            var pageSum = sanPhamList.Count() / pageSize + (sanPhamList.Count() % pageSize > 0 ? 1 : 0);
            // Truyền dữ liệu cho View
            ViewBag.pageSum = pageSum;
            ViewBag.pageIndex = pageIndex;
            return View(sanPhamList.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList())
            ;
        }
        //Hiển thị form thêm sản phẩm mới
        public IActionResult Add()
        {
            //truyền danh sách thể loại cho View để sinh ra điều khiển DropDownList
            ViewBag.LoaiSanPhamList = _db.LoaiSanPham.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Ten
            });
            return View();
        }

        //Xử lý thêm sản phẩm
        [HttpPost]
public IActionResult Add(SanPham sanPhams, IFormFile Hinh)
        {
            if (ModelState.IsValid) //kiem tra hop le
            {
                if (Hinh != null)
                {
                    //xu ly upload và lưu ảnh đại diện
                    sanPhams.Hinh = SaveImage(Hinh);
                }
                //thêm product vào table Product
                _db.SanPham.Add(sanPhams);
                _db.SaveChanges();
                TempData["success"] = "Thêm Thành Công";
                return RedirectToAction("Index");
            }
            ViewBag.LoaiSanPhamList = _db.LoaiSanPham.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Ten
            });
            return View();
        }
        //Hiển thị form cập nhật sản phẩm
        public IActionResult Update(int id)
        {
            var sanPhams = _db.SanPham.Find(id);
            if (sanPhams == null)
            {
                return NotFound();
            }
            //truyền danh sách thể loại cho View để sinh ra điều khiển DropDownList
            ViewBag.LoaiSanPhamList = _db.LoaiSanPham.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Ten
            });
            return View(sanPhams);
        }
        //Xử lý cập nhật sản phẩm
        [HttpPost]
        public IActionResult Update(SanPham sanPhams, IFormFile Hinh)
        {
            if (ModelState.IsValid) //kiem tra hop le
            {
                var existingProduct = _db.SanPham.Find(sanPhams.Id);
                if (Hinh != null)
                {
                    //xu ly upload và lưu ảnh đại diện mới
                    sanPhams.Hinh = SaveImage(Hinh);

                    //xóa ảnh cũ (nếu có)

                    if (!string.IsNullOrEmpty(existingProduct.Hinh))
                    {
                        var oldFilePath = Path.Combine(_hosting.WebRootPath,
                        existingProduct.Hinh);
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }
                }
                else

                {
                    sanPhams.Hinh = existingProduct.Hinh;
                }
                //cập nhật product vào table Product
                existingProduct.TieuDe = sanPhams.TieuDe;
                existingProduct.LoaiSanPham = sanPhams.LoaiSanPham;
                existingProduct.donGia = sanPhams.donGia;
                existingProduct.NoiBat = sanPhams.NoiBat;
                existingProduct.NoiDung = sanPhams.NoiDung;
                existingProduct.Hinh = sanPhams.Hinh;
                _db.SaveChanges();
                TempData["success"] = "Sửa Thành Công";
                return RedirectToAction("Index");
            }
            ViewBag.LoaiSanPhamList = _db.LoaiSanPham.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Ten
            });
            return View();
        }
        private string SaveImage(IFormFile image)
        {
            //đặt lại tên file cần lưu
            var filename = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            //lay duong dan luu tru wwwroot tren server
            var path = Path.Combine(_hosting.WebRootPath, @"images/manager/sanpham");
            var saveFile = Path.Combine(path, filename);
            using (var filestream = new FileStream(saveFile, FileMode.Create))
            {
                image.CopyTo(filestream);
            }
            return  filename;
        }
        //Hiển thị form xác nhận xóa sản phẩm
        public IActionResult Delete(int id)
        {
            var sanphams = _db.SanPham.Find(id);
            if (sanphams == null)
            {
                return NotFound();
            }
            return View(sanphams);
        }
        //Xử lý xóa sản phẩm
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var sanphams = _db.SanPham.Find(id);
            if (sanphams == null)
            {
                return NotFound();
            }
            // xoá hình cũ của sản phẩm
            if (!String.IsNullOrEmpty(sanphams.Hinh))
            {
                var oldFilePath = Path.Combine(_hosting.WebRootPath, sanphams.Hinh);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);

                }
            }
            // xoa san pham khoi CSDL
            _db.SanPham.Remove(sanphams);
            _db.SaveChanges();
            TempData["success"] = "Xóa Thành Công";
            //chuyen den action index
            return RedirectToAction("Index");
        }
    }
  }
