namespace QuanLyDangKyPhongHopNeu.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class g : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Phong", "KhuNha_ID", "dbo.KhuNha");
            DropForeignKey("dbo.Phong", "LoaiPhong_ID", "dbo.LoaiPhong");
            DropIndex("dbo.Phong", new[] { "KhuNha_ID" });
            DropIndex("dbo.Phong", new[] { "LoaiPhong_ID" });
            AlterColumn("dbo.Phong", "IDKhuNha", c => c.Int(nullable: false));
            AlterColumn("dbo.Phong", "IDLoaiPhong", c => c.Int(nullable: false));
            DropColumn("dbo.Phong", "KhuNha_ID");
            DropColumn("dbo.Phong", "LoaiPhong_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Phong", "LoaiPhong_ID", c => c.Int());
            AddColumn("dbo.Phong", "KhuNha_ID", c => c.Int());
            AlterColumn("dbo.Phong", "IDLoaiPhong", c => c.Int());
            AlterColumn("dbo.Phong", "IDKhuNha", c => c.Int());
            CreateIndex("dbo.Phong", "LoaiPhong_ID");
            CreateIndex("dbo.Phong", "KhuNha_ID");
            AddForeignKey("dbo.Phong", "LoaiPhong_ID", "dbo.LoaiPhong", "ID");
            AddForeignKey("dbo.Phong", "KhuNha_ID", "dbo.KhuNha", "ID");
        }
    }
}
