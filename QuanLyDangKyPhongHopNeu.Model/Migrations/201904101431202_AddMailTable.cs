namespace QuanLyDangKyPhongHopNeu.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMailTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenMail = c.String(maxLength: 128),
                        ValueOfMail = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mails");
        }
    }
}
