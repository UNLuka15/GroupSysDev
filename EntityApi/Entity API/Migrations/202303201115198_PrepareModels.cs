namespace EntityAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrepareModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Actioned = c.Boolean(nullable: false),
                        DateRaised = c.DateTime(nullable: false),
                        Account_Id = c.Int(),
                        Museum_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .ForeignKey("dbo.Museums", t => t.Museum_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Museum_Id);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reference = c.String(),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Role = c.Int(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        LockedUntil = c.DateTime(),
                        Created = c.DateTime(),
                        Language = c.String(),
                        EmailReport_Id = c.Int(),
                        Museum_Id = c.Int(),
                        Security_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmailReports", t => t.EmailReport_Id)
                .ForeignKey("dbo.Museums", t => t.Museum_Id)
                .ForeignKey("dbo.Logins", t => t.Security_Id)
                .Index(t => t.EmailReport_Id)
                .Index(t => t.Museum_Id)
                .Index(t => t.Security_Id);
            
            CreateTable(
                "dbo.EmailReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailFrequency = c.DateTime(),
                        LastSent = c.DateTime(),
                        NextDue = c.DateTime(),
                        Report_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reports", t => t.Report_Id)
                .Index(t => t.Report_Id);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ByExhibit = c.Boolean(nullable: false),
                        ByDate = c.Boolean(nullable: false),
                        ByFeedbackType = c.Boolean(nullable: false),
                        ByKeywords = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ExhibitCodeFilters = c.String(),
                        FeedbackTypeFilters = c.String(),
                        Keywords = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Exhibits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reference = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        OpeningTime = c.DateTime(),
                        ClosingTime = c.DateTime(),
                        Museum_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Museums", t => t.Museum_Id, cascadeDelete: true)
                .Index(t => t.Museum_Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        PreviousPassword = c.String(),
                        PasswordChanged = c.DateTime(nullable: false),
                        LastLoggedIn = c.DateTime(),
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
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Provider = c.String(),
                        Date = c.DateTime(),
                        Content_Id = c.Int(),
                        Museum_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Feedbacks", t => t.Content_Id)
                .ForeignKey("dbo.Museums", t => t.Museum_Id)
                .Index(t => t.Content_Id)
                .Index(t => t.Museum_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Museum_Id", "dbo.Museums");
            DropForeignKey("dbo.Reviews", "Content_Id", "dbo.Feedbacks");
            DropForeignKey("dbo.Experiences", "Feedback_Id", "dbo.Feedbacks");
            DropForeignKey("dbo.FeedbackLines", "Feedback_Id", "dbo.Feedbacks");
            DropForeignKey("dbo.Experiences", "Exhibit_Id", "dbo.Exhibits");
            DropForeignKey("dbo.AccountRequests", "Museum_Id", "dbo.Museums");
            DropForeignKey("dbo.AccountRequests", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "Security_Id", "dbo.Logins");
            DropForeignKey("dbo.Accounts", "Museum_Id", "dbo.Museums");
            DropForeignKey("dbo.Exhibits", "Museum_Id", "dbo.Museums");
            DropForeignKey("dbo.Accounts", "EmailReport_Id", "dbo.EmailReports");
            DropForeignKey("dbo.EmailReports", "Report_Id", "dbo.Reports");
            DropIndex("dbo.Reviews", new[] { "Museum_Id" });
            DropIndex("dbo.Reviews", new[] { "Content_Id" });
            DropIndex("dbo.FeedbackLines", new[] { "Feedback_Id" });
            DropIndex("dbo.Experiences", new[] { "Feedback_Id" });
            DropIndex("dbo.Experiences", new[] { "Exhibit_Id" });
            DropIndex("dbo.Exhibits", new[] { "Museum_Id" });
            DropIndex("dbo.EmailReports", new[] { "Report_Id" });
            DropIndex("dbo.Accounts", new[] { "Security_Id" });
            DropIndex("dbo.Accounts", new[] { "Museum_Id" });
            DropIndex("dbo.Accounts", new[] { "EmailReport_Id" });
            DropIndex("dbo.AccountRequests", new[] { "Museum_Id" });
            DropIndex("dbo.AccountRequests", new[] { "Account_Id" });
            DropTable("dbo.Reviews");
            DropTable("dbo.FeedbackLines");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Experiences");
            DropTable("dbo.Logins");
            DropTable("dbo.Exhibits");
            DropTable("dbo.Museums");
            DropTable("dbo.Reports");
            DropTable("dbo.EmailReports");
            DropTable("dbo.Accounts");
            DropTable("dbo.AccountRequests");
        }
    }
}
