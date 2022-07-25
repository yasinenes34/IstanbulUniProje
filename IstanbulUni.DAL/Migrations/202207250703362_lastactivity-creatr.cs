namespace IstanbulUni.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastactivitycreatr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "lastActivity", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "lastActivity");
        }
    }
}
