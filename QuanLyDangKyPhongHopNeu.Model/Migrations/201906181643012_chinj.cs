namespace QuanLyDangKyPhongHopNeu.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chinj : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.LichDangKy", "IdLanhDao");
            AddForeignKey("dbo.LichDangKy", "IdLanhDao", "dbo.LanhDao", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LichDangKy", "IdLanhDao", "dbo.LanhDao");
            DropIndex("dbo.LichDangKy", new[] { "IdLanhDao" });
        }
    }
}
