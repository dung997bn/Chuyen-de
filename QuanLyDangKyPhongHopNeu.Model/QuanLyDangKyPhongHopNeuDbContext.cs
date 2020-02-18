using Microsoft.AspNet.Identity.EntityFramework;
using QuanLyDangKyPhongHopNeu.Model.Models;
using System.Data.Entity;

namespace QuanLyDangKyPhongHopNeu.Model
{
    public class QuanLyDangKyPhongHopNeuDbContext : IdentityDbContext<ApplicationUser>
    {
        public QuanLyDangKyPhongHopNeuDbContext() : base("QLDKPHConnection")
        {

        }

        public DbSet<KhuNha> KhuNhas { set; get; }
        public DbSet<LichDangKy> LichDangKies { set; get; }
         
        public DbSet<Mail> Mails { set; get; }
        public DbSet<LichThietBi> LichThietBis { set; get; }
        public DbSet<LoaiPhong> LoaiPhongs { set; get; }
        public DbSet<Phong> Phongs { set; get; }
        public DbSet<ThietBi> ThietBis { set; get; }
        public DbSet<LanhDao> LanhDaos { set; get; }
        public static QuanLyDangKyPhongHopNeuDbContext Create()
        {
            return new QuanLyDangKyPhongHopNeuDbContext();
        }
    }
}
