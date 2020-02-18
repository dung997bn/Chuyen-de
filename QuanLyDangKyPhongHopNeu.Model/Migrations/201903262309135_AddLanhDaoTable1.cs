namespace QuanLyDangKyPhongHopNeu.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLanhDaoTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LichDangKy", "NoiDungCuocHop", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LichDangKy", "NoiDungCuocHop");
        }
    }
}
