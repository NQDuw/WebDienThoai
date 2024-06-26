using Microsoft.EntityFrameworkCore.Migrations;

namespace WebDienThoai.Migrations
{
    public partial class KhoiTao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slide",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Hinh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slide", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheLoai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TinTuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TomTat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hinh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinTuc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheLoaiId = table.Column<int>(type: "int", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiSanPham_TheLoai_TheLoaiId",
                        column: x => x.TheLoaiId,
                        principalTable: "TheLoai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiSanPhamId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    donGia = table.Column<int>(type: "int", nullable: false),
                    NoiBat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPham_LoaiSanPham_LoaiSanPhamId",
                        column: x => x.LoaiSanPhamId,
                        principalTable: "LoaiSanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSanPham = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_SanPham_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Slide",
                columns: new[] { "Id", "Hinh", "Ten" },
                values: new object[,]
                {
                    { 1, "banner-tgdd-800x300.jpg", "banner thế giới di động" },
                    { 2, "sl-iphone-14-promax.jpg", "iphone 14 promax" },
                    { 3, "thietkehaithanh-banner-1-1.jpg", "Huawei 10" }
                });

            migrationBuilder.InsertData(
                table: "TheLoai",
                columns: new[] { "Id", "Ten" },
                values: new object[,]
                {
                    { 1, "Điện thoại" },
                    { 2, "Điện thoại" },
                    { 3, "Điện thoại" },
                    { 4, "Điện thoại" },
                    { 5, "Điện thoại" },
                    { 6, "Điện thoại" },
                    { 7, "Điện thoại" }
                });

            migrationBuilder.InsertData(
                table: "LoaiSanPham",
                columns: new[] { "Id", "Ten", "TheLoaiId" },
                values: new object[,]
                {
                    { 1, "Iphone", 1 },
                    { 21, "Logitech", 4 },
                    { 20, "E-DRA", 4 },
                    { 19, "Dareu", 4 },
                    { 18, "Apple", 4 },
                    { 17, "AKKO", 4 },
                    { 16, "Gamming", 3 },
                    { 15, "Wireless", 3 },
                    { 14, "Sony", 3 },
                    { 13, "Acer", 2 },
                    { 22, "Gamming", 5 },
                    { 12, "Lenovo", 2 },
                    { 10, "Asus", 2 },
                    { 9, "MacBook", 2 },
                    { 8, "Dell", 2 },
                    { 7, "Vivo", 1 },
                    { 6, "Xiaomi", 1 },
                    { 5, "Nokia", 1 },
                    { 4, "Realme", 1 },
                    { 3, "Oppo", 1 },
                    { 2, "SamSung", 1 },
                    { 11, "HP", 2 },
                    { 23, "Không Dây", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_IdSanPham",
                table: "Comment",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSanPham_TheLoaiId",
                table: "LoaiSanPham",
                column: "TheLoaiId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_LoaiSanPhamId",
                table: "SanPham",
                column: "LoaiSanPhamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Slide");

            migrationBuilder.DropTable(
                name: "TinTuc");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "LoaiSanPham");

            migrationBuilder.DropTable(
                name: "TheLoai");
        }
    }
}
