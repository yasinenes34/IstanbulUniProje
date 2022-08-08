namespace IstanbulUni.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WebMasters", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WebMasters", "IsActive");
        }
    }
}
