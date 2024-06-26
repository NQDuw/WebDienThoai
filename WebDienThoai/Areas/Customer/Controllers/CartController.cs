using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDienThoai.Models;
using WebDienThoai.Helpers;

namespace WebBanHang.Areas.customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CartController( ApplicationDbContext db)
        {
            _db = db;
        }
        // hiển thị giỏ hàng
        public IActionResult Index()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("CART");
            if (cart == null)
            {
                cart = new Cart();
            }
            return View(cart);
        }
        public IActionResult AddToCart(int sanPhamId)
        {
            var sanPhams = _db.SanPham.FirstOrDefault(x => x.Id == sanPhamId);
            if (sanPhams != null)
            {
                Cart cart = HttpContext.Session.GetJson<Cart>("CART");
                if (cart == null)
                {
                    cart = new Cart();
                }
                cart.Add(sanPhams, 1);
                HttpContext.Session.SetJson("CART", cart);
                //return Json(new { msg = "success", qty = cart.Quantity });
                TempData["success"] = "Đã Thêm Vào Giỏ Hàng";
                return RedirectToAction("Index", "home");
            }
            return Json(new { msg = "error" });

        }
        public IActionResult Update(int sanPhamId,int qty)
        {
            var sanPhams = _db.SanPham.FirstOrDefault(x => x.Id == sanPhamId);
            if (sanPhams != null)
            {
                Cart cart = HttpContext.Session.GetJson<Cart>("CART");
                if (cart != null)
                {
                    cart.Update(sanPhamId, qty);// cap nhat lai so luong
                    HttpContext.Session.SetJson("CART", cart);// luu cart vao session
                    return RedirectToAction("Index");
                }
            }
            return Json(new { msg = "error" });
        }
        public IActionResult remove(int sanPhamId)
        {
            var sanPhams = _db.SanPham.FirstOrDefault(x => x.Id == sanPhamId);
            if (sanPhams != null)
            {
                Cart cart = HttpContext.Session.GetJson<Cart>("CART");
                if (cart != null)
                {
                    cart.Remove(sanPhamId);// xoa san pham khoi gio
                    HttpContext.Session.SetJson("CART", cart);// luu cart vao session
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        #region API
        public IActionResult AddToCartAPI(int sanPhamId)
        {
            var sanPhams = _db.SanPham.FirstOrDefault(x => x.Id == sanPhamId);
            if (sanPhams != null)
            {
                Cart cart = HttpContext.Session.GetJson<Cart>("CART");
                if (cart == null)
                {
                    cart = new Cart();
                }
                cart.Add(sanPhams, 1);
                HttpContext.Session.SetJson("CART", cart);
                 return Json(new { msg = "Đã Thêm Vào Giỏ Hàng" , qty=cart.Quantity});
            }
            return Json(new { msg = "error" });

        }
        public IActionResult GetQuanTiTyOfCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("CART");
            if (cart != null)
            {
                return Json(new { qty = cart.Quantity });
            }
            return Json(new { qty = 0 });
        }
        #endregion
    }
}
