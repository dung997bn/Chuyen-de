namespace QuanLyDangKyPhongHopNeu.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gf : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Phong", "IDKhuNha");
            CreateIndex("dbo.Phong", "IDLoaiPhong");
            AddForeignKey("dbo.Phong", "IDKhuNha", "dbo.KhuNha", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Phong", "IDLoaiPhong", "dbo.LoaiPhong", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phong", "IDLoaiPhong", "dbo.LoaiPhong");
            DropForeignKey("dbo.Phong", "IDKhuNha", "dbo.KhuNha");
            DropIndex("dbo.Phong", new[] { "IDLoaiPhong" });
            DropIndex("dbo.Phong", new[] { "IDKhuNha" });
        }
    }
}
