namespace IstanbulUni.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WebMasters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DomainName = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Number = c.Int(nullable: false),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WebMasters");
            DropTable("dbo.Users");
        }
    }
}
