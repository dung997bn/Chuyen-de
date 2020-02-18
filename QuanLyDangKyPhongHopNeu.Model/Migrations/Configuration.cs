namespace QuanLyDangKyPhongHopNeu.Model.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using QuanLyDangKyPhongHopNeu.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuanLyDangKyPhongHopNeu.Model.QuanLyDangKyPhongHopNeuDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(QuanLyDangKyPhongHopNeu.Model.QuanLyDangKyPhongHopNeuDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (context.Users.Count() == 0)
            {
                TaoMoiUser(context);
            }
            if (context.KhuNhas.Count() == 0)
            {
                TaoMoiKhuNha(context);

            }
            if (context.LoaiPhongs.Count() == 0)
            {
                TaoMoiLoaiPhong(context);
            }
            if (context.Phongs.Count() == 0)
            {
                TaoMoiPhong(context);
            }
            
            if (context.LichDangKies.Count() == 0)
            {
                TaoMoiLichDangKy(context);
            }
            if (context.ThietBis.Count() == 0)
            {
                TaoMoiThietBi(context);
            }
        }
        protected void TaoMoiLichDangKy(QuanLyDangKyPhongHopNeuDbContext context)
        {
            var date = DateTime.Today;
            List<LichDangKy> list = new List<LichDangKy>()
            {
                new LichDangKy{TieuDe ="Tiêu đề 1",IDPhong=1,ThoiGianBatDau=date.AddHours(7.5),ThoiGianKetThuc=date.AddHours(8.5),NgayDangKy=DateTime.Now,TenNguoiDangKy="Nguyen Xuan Dung",Email="11150961@st.neu.edu.vn",SoDienThoai="0912946879",TinhTrang="Đang chờ xử lý"},
                new LichDangKy{TieuDe ="Tiêu đề 2",IDPhong=5,ThoiGianBatDau=date.AddHours(9.5),ThoiGianKetThuc=date.AddHours(13),NgayDangKy=DateTime.Now,TenNguoiDangKy="Phan Van Khai",Email="11152208@st.neu.edu.vn",SoDienThoai="0165468489",TinhTrang="Đang chờ xử lý"}
            };
            context.LichDangKies.AddRange(list);
            context.SaveChanges();
        }
        protected void TaoMoiThietBi(QuanLyDangKyPhongHopNeuDbContext context)
        {
            List<ThietBi> list = new List<ThietBi>()
            {
                new ThietBi{TenThietBi="Máy chiếu",SoLuong=100},
                new ThietBi{TenThietBi="Micro",SoLuong=100},
                new ThietBi{TenThietBi="Video confering",SoLuong=100}
            };
            context.ThietBis.AddRange(list);
            context.SaveChanges();
            
        }
        protected void TaoMoiLoaiPhong(QuanLyDangKyPhongHopNeuDbContext context)
        {
            List<LoaiPhong> list = new List<LoaiPhong>()
            {
                new LoaiPhong{ TenLoaiPhong="Đặc biệt"},
                new LoaiPhong{ TenLoaiPhong="Loại thường"}
            };
            context.LoaiPhongs.AddRange(list);
            context.SaveChanges();
        }
        protected void TaoMoiKhuNha(QuanLyDangKyPhongHopNeuDbContext context)
        {
            List<KhuNha> list = new List<KhuNha>()
            {
                new KhuNha{TenKhuNha="Khu A"},
                new KhuNha{TenKhuNha="Khu B"},
                new KhuNha{TenKhuNha="Khu C"},
                new KhuNha{TenKhuNha="Khu D"},
                new KhuNha{TenKhuNha="Khu A2"}
            };
            context.KhuNhas.AddRange(list);
            context.SaveChanges();
        }
        protected void TaoMoiPhong(QuanLyDangKyPhongHopNeuDbContext context)
        {
            List<Phong> list = new List<Phong>()
            {
                new Phong{TenPhong="A101",IDKhuNha=1,IDLoaiPhong=2},
                new Phong{TenPhong="A102",IDKhuNha=1,IDLoaiPhong=2},
                new Phong{TenPhong="A103",IDKhuNha=1,IDLoaiPhong=2},
                new Phong{TenPhong="B101",IDKhuNha=2,IDLoaiPhong=1},
                new Phong{TenPhong="B102",IDKhuNha=2,IDLoaiPhong=1},
                new Phong{TenPhong="C103",IDKhuNha=3,IDLoaiPhong=1},
                new Phong{TenPhong="C105",IDKhuNha=3,IDLoaiPhong=1},
                new Phong{TenPhong="D106",IDKhuNha=4,IDLoaiPhong=1},
                new Phong{TenPhong="D104",IDKhuNha=4,IDLoaiPhong=2},
                new Phong{TenPhong="A2-201",IDKhuNha=5,IDLoaiPhong=1}
            };
            context.Phongs.AddRange(list);
            context.SaveChanges();
        }
        protected void TaoMoiUser(QuanLyDangKyPhongHopNeuDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new QuanLyDangKyPhongHopNeuDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new QuanLyDangKyPhongHopNeuDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "dung997bn",
                Email = "phaichisophan@gmail.com",
                EmailConfirmed = true,
                DiaChi = "Bắc Ninh",
                HoTen = "Nguyễn Xuân Dũng"
            };

            manager.Create(user, "123654$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("tedu.international@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
    }
}
