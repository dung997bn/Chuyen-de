namespace QuanLyDangKyPhongHopNeu.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LichDangKy", "NoiDungCuocHop", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LichDangKy", "NoiDungCuocHop", c => c.String(maxLength: 256));
        }
    }
}
