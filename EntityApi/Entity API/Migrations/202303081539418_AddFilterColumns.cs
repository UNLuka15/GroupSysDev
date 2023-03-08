namespace EntityAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFilterColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "FeedbackTypeFilters", c => c.String());
            AddColumn("dbo.Reports", "Keywords", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "Keywords");
            DropColumn("dbo.Reports", "FeedbackTypeFilters");
        }
    }
}
