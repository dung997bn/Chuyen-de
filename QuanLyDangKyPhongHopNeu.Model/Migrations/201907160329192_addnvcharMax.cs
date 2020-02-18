namespace QuanLyDangKyPhongHopNeu.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnvcharMax : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LichDangKy", "TieuDe", c => c.String(maxLength: 256));
            AlterColumn("dbo.LichDangKy", "ThanhPhan", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LichDangKy", "ThanhPhan", c => c.String(maxLength: 256));
            AlterColumn("dbo.LichDangKy", "TieuDe", c => c.String(maxLength: 128));
        }
    }
}
