namespace QuanLyDangKyPhongHopNeu.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GioDangKy",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenGio = c.String(maxLength: 128, unicode: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KhuNha",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenKhuNha = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LichDangKy",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(maxLength: 128),
                        IDPhong = c.Int(nullable: false),
                        ThoiGianBatDau = c.Int(nullable: false),
                        ThoiGianKetThuc = c.Int(nullable: false),
                        NgayDangKy = c.DateTime(nullable: false),
                        TenNguoiDangKy = c.String(maxLength: 128),
                        Email = c.String(maxLength: 128),
                        SoDienThoai = c.String(maxLength: 128, unicode: false),
                        TinhTrang = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Phong", t => t.IDPhong, cascadeDelete: true)
                .Index(t => t.IDPhong);
            
            CreateTable(
                "dbo.Phong",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenPhong = c.String(maxLength: 128),
                        IDKhuNha = c.Int(),
                        IDLoaiPhong = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LichThietBi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDLichDangKy = c.Int(),
                        IDThietBi = c.Int(),
                        SoLuongThue = c.Int(),
                        TinhTrang = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LoaiPhong",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenLoaiPhong = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ThietBi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenThietBi = c.String(maxLength: 128),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        HoTen = c.String(maxLength: 128),
                        DiaChi = c.String(maxLength: 128),
                        SDT = c.String(maxLength: 128, unicode: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.LichDangKy", "IDPhong", "dbo.Phong");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.LichDangKy", new[] { "IDPhong" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ThietBi");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LoaiPhong");
            DropTable("dbo.LichThietBi");
            DropTable("dbo.Phong");
            DropTable("dbo.LichDangKy");
            DropTable("dbo.KhuNha");
            DropTable("dbo.GioDangKy");
        }
    }
}
