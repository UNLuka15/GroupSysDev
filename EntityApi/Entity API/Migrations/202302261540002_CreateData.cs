namespace EntityAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exhibits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Museum_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Museums", t => t.Museum_Id)
                .Index(t => t.Museum_Id);
            
            CreateTable(
                "dbo.Museums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateEntered = c.DateTime(),
                        UploadedBy = c.String(),
                        Exhibit_Id = c.Int(),
                        Feedback_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exhibits", t => t.Exhibit_Id)
                .ForeignKey("dbo.Feedbacks", t => t.Feedback_Id)
                .Index(t => t.Exhibit_Id)
                .Index(t => t.Feedback_Id);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeedbackLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Field = c.String(),
                        Value = c.String(),
                        DataType = c.String(),
                        Feedback_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Feedbacks", t => t.Feedback_Id)
                .Index(t => t.Feedback_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Experiences", "Feedback_Id", "dbo.Feedbacks");
            DropForeignKey("dbo.FeedbackLines", "Feedback_Id", "dbo.Feedbacks");
            DropForeignKey("dbo.Experiences", "Exhibit_Id", "dbo.Exhibits");
            DropForeignKey("dbo.Exhibits", "Museum_Id", "dbo.Museums");
            DropIndex("dbo.FeedbackLines", new[] { "Feedback_Id" });
            DropIndex("dbo.Experiences", new[] { "Feedback_Id" });
            DropIndex("dbo.Experiences", new[] { "Exhibit_Id" });
            DropIndex("dbo.Exhibits", new[] { "Museum_Id" });
            DropTable("dbo.FeedbackLines");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Experiences");
            DropTable("dbo.Museums");
            DropTable("dbo.Exhibits");
        }
    }
}
