namespace QuanLyDangKyPhongHopNeu.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LichDangKy", "IdLanhDao", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LichDangKy", "IdLanhDao", c => c.Int());
        }
    }
}
