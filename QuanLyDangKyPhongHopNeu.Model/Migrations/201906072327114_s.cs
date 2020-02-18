namespace QuanLyDangKyPhongHopNeu.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phong", "KhuNha_ID", c => c.Int());
            AddColumn("dbo.Phong", "LoaiPhong_ID", c => c.Int());
            CreateIndex("dbo.Phong", "KhuNha_ID");
            CreateIndex("dbo.Phong", "LoaiPhong_ID");
            AddForeignKey("dbo.Phong", "KhuNha_ID", "dbo.KhuNha", "ID");
            AddForeignKey("dbo.Phong", "LoaiPhong_ID", "dbo.LoaiPhong", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phong", "LoaiPhong_ID", "dbo.LoaiPhong");
            DropForeignKey("dbo.Phong", "KhuNha_ID", "dbo.KhuNha");
            DropIndex("dbo.Phong", new[] { "LoaiPhong_ID" });
            DropIndex("dbo.Phong", new[] { "KhuNha_ID" });
            DropColumn("dbo.Phong", "LoaiPhong_ID");
            DropColumn("dbo.Phong", "KhuNha_ID");
        }
    }
}
