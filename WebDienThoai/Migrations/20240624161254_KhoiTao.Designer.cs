﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebDienThoai.Models;

namespace WebDienThoai.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240624161254_KhoiTao")]
    partial class KhoiTao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebDienThoai.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdSanPham")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdSanPham");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("WebDienThoai.Models.LoaiSanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("TheLoaiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TheLoaiId");

                    b.ToTable("LoaiSanPham");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ten = "Iphone",
                            TheLoaiId = 1
                        },
                        new
                        {
                            Id = 2,
                            Ten = "SamSung",
                            TheLoaiId = 1
                        },
                        new
                        {
                            Id = 3,
                            Ten = "Oppo",
                            TheLoaiId = 1
                        },
                        new
                        {
                            Id = 4,
                            Ten = "Realme",
                            TheLoaiId = 1
                        },
                        new
                        {
                            Id = 5,
                            Ten = "Nokia",
                            TheLoaiId = 1
                        },
                        new
                        {
                            Id = 6,
                            Ten = "Xiaomi",
                            TheLoaiId = 1
                        },
                        new
                        {
                            Id = 7,
                            Ten = "Vivo",
                            TheLoaiId = 1
                        },
                        new
                        {
                            Id = 8,
                            Ten = "Dell",
                            TheLoaiId = 2
                        },
                        new
                        {
                            Id = 9,
                            Ten = "MacBook",
                            TheLoaiId = 2
                        },
                        new
                        {
                            Id = 10,
                            Ten = "Asus",
                            TheLoaiId = 2
                        },
                        new
                        {
                            Id = 11,
                            Ten = "HP",
                            TheLoaiId = 2
                        },
                        new
                        {
                            Id = 12,
                            Ten = "Lenovo",
                            TheLoaiId = 2
                        },
                        new
                        {
                            Id = 13,
                            Ten = "Acer",
                            TheLoaiId = 2
                        },
                        new
                        {
                            Id = 14,
                            Ten = "Sony",
                            TheLoaiId = 3
                        },
                        new
                        {
                            Id = 15,
                            Ten = "Wireless",
                            TheLoaiId = 3
                        },
                        new
                        {
                            Id = 16,
                            Ten = "Gamming",
                            TheLoaiId = 3
                        },
                        new
                        {
                            Id = 17,
                            Ten = "AKKO",
                            TheLoaiId = 4
                        },
                        new
                        {
                            Id = 18,
                            Ten = "Apple",
                            TheLoaiId = 4
                        },
                        new
                        {
                            Id = 19,
                            Ten = "Dareu",
                            TheLoaiId = 4
                        },
                        new
                        {
                            Id = 20,
                            Ten = "E-DRA",
                            TheLoaiId = 4
                        },
                        new
                        {
                            Id = 21,
                            Ten = "Logitech",
                            TheLoaiId = 4
                        },
                        new
                        {
                            Id = 22,
                            Ten = "Gamming",
                            TheLoaiId = 5
                        },
                        new
                        {
                            Id = 23,
                            Ten = "Không Dây",
                            TheLoaiId = 5
                        });
                });

            modelBuilder.Entity("WebDienThoai.Models.SanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Hinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiSanPhamId")
                        .HasColumnType("int");

                    b.Property<int>("NoiBat")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieuDe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("donGia")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoaiSanPhamId");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("WebDienThoai.Models.Slide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Hinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Slide");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Hinh = "banner-tgdd-800x300.jpg",
                            Ten = "banner thế giới di động"
                        },
                        new
                        {
                            Id = 2,
                            Hinh = "sl-iphone-14-promax.jpg",
                            Ten = "iphone 14 promax"
                        },
                        new
                        {
                            Id = 3,
                            Hinh = "thietkehaithanh-banner-1-1.jpg",
                            Ten = "Huawei 10"
                        });
                });

            modelBuilder.Entity("WebDienThoai.Models.TheLoai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("TheLoai");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ten = "Điện thoại"
                        },
                        new
                        {
                            Id = 2,
                            Ten = "Điện thoại"
                        },
                        new
                        {
                            Id = 3,
                            Ten = "Điện thoại"
                        },
                        new
                        {
                            Id = 4,
                            Ten = "Điện thoại"
                        },
                        new
                        {
                            Id = 5,
                            Ten = "Điện thoại"
                        },
                        new
                        {
                            Id = 6,
                            Ten = "Điện thoại"
                        },
                        new
                        {
                            Id = 7,
                            Ten = "Điện thoại"
                        });
                });

            modelBuilder.Entity("WebDienThoai.Models.TinTuc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Hinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieuDe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TomTat")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TinTuc");
                });

            modelBuilder.Entity("WebDienThoai.Models.Comment", b =>
                {
                    b.HasOne("WebDienThoai.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebDienThoai.Models.LoaiSanPham", b =>
                {
                    b.HasOne("WebDienThoai.Models.TheLoai", "TheLoai")
                        .WithMany()
                        .HasForeignKey("TheLoaiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TheLoai");
                });

            modelBuilder.Entity("WebDienThoai.Models.SanPham", b =>
                {
                    b.HasOne("WebDienThoai.Models.LoaiSanPham", "LoaiSanPham")
                        .WithMany()
                        .HasForeignKey("LoaiSanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiSanPham");
                });
#pragma warning restore 612, 618
        }
    }
}