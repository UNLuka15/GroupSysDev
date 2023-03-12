namespace EntityAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Exhibit : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Exhibits", new[] { "Museum_Id" });
            AlterColumn("dbo.Exhibits", "Museum_Id", c => c.Int());
            CreateIndex("dbo.Exhibits", "Museum_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Exhibits", new[] { "Museum_Id" });
            AlterColumn("dbo.Exhibits", "Museum_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Exhibits", "Museum_Id");
        }
    }
}
