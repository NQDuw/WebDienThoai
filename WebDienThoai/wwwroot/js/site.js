$(document).ready(function () {
    showQuantiyCart();
});

$(".addtocart").click(function (evt) {
    evt.preventDefault();
    let id = $(this).attr("data-sanPhamId");
    $.ajax({
        url: "/customer/cart/addtocartapi",
        data: { "sanPhamId": id },
        success: function (data) {
            //thong bao ket qua
            Swal.fire({
                title: "Thêm Vào Giỏ Hàng Thành Công",
                text: "You clicked the button!",
                icon: "success"
            });
            //hien thi so luong san pham trong gio trong _FrontEnd.cshtml
            showQuantiyCart();
        }
    });
})
let showQuantiyCart = () => {
    $.ajax({
        url: "/customer/cart/GetQuantityOfCart",
        success: function (data) {
            //hien thi so luong san pham trong gio trong _FrontEnd.cshtml
            $(".showcart").text(data.qty);
        }
    });
}