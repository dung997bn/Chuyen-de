namespace QuanLyDangKyPhongHopNeu.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dvct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LanhDao", "DonViCongTac", c => c.String());
            DropColumn("dbo.LichDangKy", "DonViCongTac");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LichDangKy", "DonViCongTac", c => c.String());
            DropColumn("dbo.LanhDao", "DonViCongTac");
        }
    }
}
