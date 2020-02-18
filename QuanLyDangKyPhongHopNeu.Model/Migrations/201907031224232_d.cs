namespace QuanLyDangKyPhongHopNeu.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LichDangKy", "DonViCongTac", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LichDangKy", "DonViCongTac");
        }
    }
}
