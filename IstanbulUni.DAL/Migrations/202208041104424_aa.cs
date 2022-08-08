namespace IstanbulUni.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Phone = c.String(),
                        lastActivity = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.userID);
            
            CreateTable(
                "dbo.WebMasters",
                c => new
                    {
                        webMasterID = c.Int(nullable: false, identity: true),
                        DomainName = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Department = c.String(),
                        createTime = c.DateTime(nullable: false),
                        userID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.webMasterID)
                .ForeignKey("dbo.Users", t => t.userID, cascadeDelete: true)
                .Index(t => t.userID);
            
            CreateTable(
                "dbo.WebMasterHistories",
                c => new
                    {
                        webMasterHistoryID = c.Int(nullable: false, identity: true),
                        DomainName = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Department = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        createTime = c.DateTime(nullable: false),
                        deleteTime = c.DateTime(nullable: false),
                        serviceTime = c.String(),
                    })
                .PrimaryKey(t => t.webMasterHistoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WebMasters", "userID", "dbo.Users");
            DropIndex("dbo.WebMasters", new[] { "userID" });
            DropTable("dbo.WebMasterHistories");
            DropTable("dbo.WebMasters");
            DropTable("dbo.Users");
        }
    }
}
