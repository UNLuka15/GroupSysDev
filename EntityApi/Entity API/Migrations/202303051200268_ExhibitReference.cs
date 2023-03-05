namespace EntityAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExhibitReference : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exhibits", "Reference", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exhibits", "Reference");
        }
    }
}
