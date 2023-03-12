namespace EntityAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MuseumExhibitList : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exhibits", "Museum_Id", "dbo.Museums");
            DropIndex("dbo.Exhibits", new[] { "Museum_Id" });
            AlterColumn("dbo.Exhibits", "Museum_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Exhibits", "Museum_Id");
            AddForeignKey("dbo.Exhibits", "Museum_Id", "dbo.Museums", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exhibits", "Museum_Id", "dbo.Museums");
            DropIndex("dbo.Exhibits", new[] { "Museum_Id" });
            AlterColumn("dbo.Exhibits", "Museum_Id", c => c.Int());
            CreateIndex("dbo.Exhibits", "Museum_Id");
            AddForeignKey("dbo.Exhibits", "Museum_Id", "dbo.Museums", "Id");
        }
    }
}
