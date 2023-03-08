namespace EntityAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateExhibitFilter : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exhibits", "Report_Id", "dbo.Reports");
            DropIndex("dbo.Exhibits", new[] { "Report_Id" });
            AddColumn("dbo.Reports", "ExhibitCodeFilters", c => c.String());
            DropColumn("dbo.Exhibits", "Report_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exhibits", "Report_Id", c => c.Int());
            DropColumn("dbo.Reports", "ExhibitCodeFilters");
            CreateIndex("dbo.Exhibits", "Report_Id");
            AddForeignKey("dbo.Exhibits", "Report_Id", "dbo.Reports", "Id");
        }
    }
}
