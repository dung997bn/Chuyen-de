namespace QuanLyDangKyPhongHopNeu.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLanhDaoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LanhDao",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HoTen = c.String(maxLength: 128),
                        ChucVu = c.String(maxLength: 128),
                        Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.LichDangKy", "ThanhPhan", c => c.String(maxLength: 256));
            AddColumn("dbo.LichDangKy", "IdLanhDao", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LichDangKy", "IdLanhDao");
            DropColumn("dbo.LichDangKy", "ThanhPhan");
            DropTable("dbo.LanhDao");
        }
    }
}
