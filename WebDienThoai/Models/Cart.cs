using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDienThoai.Models
{

    // lớp biểu diễn một phần tử của giỏ hàng
    public class CartItem
    {
        public SanPham SanPham { get; set; }
        public int Quantity { get; set; }
    }
    // lớp biểu diễn giỏ hàng
    public class Cart
    {
        private List<CartItem> _items;
        public Cart()
        {
            _items = new List<CartItem>();
        }
        public List<CartItem> Items { get { return _items; } }
        // ---------các phương  thức xử lý trên giỏ hàng------------
        // phương thức thêm sản phẩm
        public void Add(SanPham p, int qty)
        {
            var item = _items.FirstOrDefault(x => x.SanPham.Id == p.Id);
            if (item == null) //nếu chưa có
            {
                _items.Add(new CartItem { SanPham = p, Quantity = qty });
            }
            else
            {
                item.Quantity += qty;
            }
        }
        // phương thức cập nhậ số lượng sản phẩm
        public void Update(int sanPhamId, int qty)
        {
            var item = _items.FirstOrDefault(x => x.SanPham.Id == sanPhamId);
            if (item != null)
            {
                if (qty > 0)
                {
                    item.Quantity = qty;
                }
                else
                {
                    _items.Remove(item);
                }
            }
        }
        // xóa sản phẩm
        public void Remove(int sanPhamId)
        {
            var item = _items.FirstOrDefault(x => x.SanPham.Id == sanPhamId);
            if (item != null)
            {
                _items.Remove(item);
            }
        }
        // phương thức tính tổng thành tiền
        //public double Total()
        //{
        //     double total = _items.Sum(x => x.Quantity * x.Product.Price);
        //     return total;   
        //}
        public double Total
        {
            get
            {
                double total = _items.Sum(x => x.Quantity * x.SanPham.donGia);
                return total;
            }
        }
        // tính tổng số lượng sản phẩm
        public double Quantity
        {
            get
            {
                double total = _items.Sum(x => x.Quantity);
                return total;
            }
        }

    }
}
