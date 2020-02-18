namespace QuanLyDangKyPhongHopNeu.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LichDangKy", "ThoiGianBatDau", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LichDangKy", "ThoiGianKetThuc", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LichDangKy", "ThoiGianKetThuc", c => c.Int(nullable: false));
            AlterColumn("dbo.LichDangKy", "ThoiGianBatDau", c => c.Int(nullable: false));
        }
    }
}
