namespace QuanLyDangKyPhongHopNeu.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LichThietBi", "NguoiThue", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LichThietBi", "NguoiThue");
        }
    }
}
