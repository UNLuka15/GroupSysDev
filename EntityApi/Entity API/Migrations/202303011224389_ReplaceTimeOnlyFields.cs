namespace EntityAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplaceTimeOnlyFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exhibits", "OpeningTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Exhibits", "ClosingTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exhibits", "ClosingTime");
            DropColumn("dbo.Exhibits", "OpeningTime");
        }
    }
}
