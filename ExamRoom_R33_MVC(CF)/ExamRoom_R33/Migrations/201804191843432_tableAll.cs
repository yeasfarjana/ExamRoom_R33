namespace ExamRoom_R33.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableAll : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Choices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Label = c.String(),
                        Points = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionCategoryId = c.Int(),
                        QuestionType = c.String(),
                        Question1 = c.String(),
                        ExaminerID = c.Int(),
                        Points = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        QuestionMaker_QuestionMakerID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionCategories", t => t.QuestionCategoryId)
                .ForeignKey("dbo.QuestionMakers", t => t.QuestionMaker_QuestionMakerID)
                .Index(t => t.QuestionCategoryId)
                .Index(t => t.QuestionMaker_QuestionMakerID);
            
            CreateTable(
                "dbo.QuestionCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestXQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        QuestionNumber = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.QuestionXDurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationId = c.Int(nullable: false),
                        TextXQuestionId = c.Int(nullable: false),
                        RequesTime = c.Time(nullable: false, precision: 7),
                        LeaveTime = c.Time(nullable: false, precision: 7),
                        AnsweredTime = c.Time(nullable: false, precision: 7),
                        TestXQuestion_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Registrations", t => t.RegistrationId, cascadeDelete: true)
                .ForeignKey("dbo.TestXQuestions", t => t.TestXQuestion_Id)
                .Index(t => t.RegistrationId)
                .Index(t => t.TestXQuestion_Id);
            
            CreateTable(
                "dbo.TestXPapers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationId = c.Int(nullable: false),
                        TextXQuestionId = c.Int(nullable: false),
                        ChoiceId = c.Int(nullable: false),
                        Answer = c.String(),
                        MarkScored = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TestXQuestion_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Choices", t => t.ChoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Registrations", t => t.RegistrationId, cascadeDelete: true)
                .ForeignKey("dbo.TestXQuestions", t => t.TestXQuestion_Id)
                .Index(t => t.RegistrationId)
                .Index(t => t.ChoiceId)
                .Index(t => t.TestXQuestion_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionXDurations", "TestXQuestion_Id", "dbo.TestXQuestions");
            DropForeignKey("dbo.TestXPapers", "TestXQuestion_Id", "dbo.TestXQuestions");
            DropForeignKey("dbo.TestXPapers", "RegistrationId", "dbo.Registrations");
            DropForeignKey("dbo.TestXPapers", "ChoiceId", "dbo.Choices");
            DropForeignKey("dbo.TestXQuestions", "TestId", "dbo.Tests");
            DropForeignKey("dbo.QuestionXDurations", "RegistrationId", "dbo.Registrations");
            DropForeignKey("dbo.TestXQuestions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "QuestionMaker_QuestionMakerID", "dbo.QuestionMakers");
            DropForeignKey("dbo.Questions", "QuestionCategoryId", "dbo.QuestionCategories");
            DropForeignKey("dbo.Choices", "QuestionId", "dbo.Questions");
            DropIndex("dbo.TestXPapers", new[] { "TestXQuestion_Id" });
            DropIndex("dbo.TestXPapers", new[] { "ChoiceId" });
            DropIndex("dbo.TestXPapers", new[] { "RegistrationId" });
            DropIndex("dbo.QuestionXDurations", new[] { "TestXQuestion_Id" });
            DropIndex("dbo.QuestionXDurations", new[] { "RegistrationId" });
            DropIndex("dbo.TestXQuestions", new[] { "QuestionId" });
            DropIndex("dbo.TestXQuestions", new[] { "TestId" });
            DropIndex("dbo.Questions", new[] { "QuestionMaker_QuestionMakerID" });
            DropIndex("dbo.Questions", new[] { "QuestionCategoryId" });
            DropIndex("dbo.Choices", new[] { "QuestionId" });
            DropTable("dbo.TestXPapers");
            DropTable("dbo.QuestionXDurations");
            DropTable("dbo.TestXQuestions");
            DropTable("dbo.QuestionCategories");
            DropTable("dbo.Questions");
            DropTable("dbo.Choices");
        }
    }
}
