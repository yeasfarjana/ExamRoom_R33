namespace ExamRoom_R33.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exams", "ExaminerID", "dbo.Examiners");
            DropForeignKey("dbo.OngoingExams", "ExamID", "dbo.Exams");
            DropForeignKey("dbo.QuestionSets", "ExamID", "dbo.Exams");
            DropForeignKey("dbo.Results", "ExamID", "dbo.Exams");
            DropForeignKey("dbo.Results", "ExamineeID", "dbo.Examinees");
            DropForeignKey("dbo.OngoingExams", "ExamineeID", "dbo.Examinees");
            DropIndex("dbo.OngoingExams", new[] { "ExamineeID" });
            DropIndex("dbo.OngoingExams", new[] { "ExamID" });
            DropIndex("dbo.Exams", new[] { "ExaminerID" });
            DropIndex("dbo.QuestionSets", new[] { "ExamID" });
            DropIndex("dbo.Results", new[] { "ExamineeID" });
            DropIndex("dbo.Results", new[] { "ExamID" });
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamineeId = c.Int(),
                        TestId = c.Int(),
                        RegistrationDate = c.DateTime(nullable: false),
                        Token = c.Guid(nullable: false),
                        TokenExpireTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Examinees", t => t.ExamineeId)
                .ForeignKey("dbo.Tests", t => t.TestId)
                .Index(t => t.ExamineeId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        DurationInMinute = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionMakers",
                c => new
                    {
                        QuestionMakerID = c.Int(nullable: false, identity: true),
                        QuestionMakerName = c.String(),
                    })
                .PrimaryKey(t => t.QuestionMakerID);
            
            AddColumn("dbo.Examinees", "Name", c => c.String());
            AddColumn("dbo.Examinees", "EntryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Examinees", "Phone", c => c.String());
            DropColumn("dbo.Examinees", "FirstName");
            DropColumn("dbo.Examinees", "LastName");
            DropColumn("dbo.Examinees", "PhoneNumber");
            DropColumn("dbo.Examiners", "Password");
            DropTable("dbo.OngoingExams");
            DropTable("dbo.Exams");
            DropTable("dbo.QuestionSets");
            DropTable("dbo.Results");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultID = c.Int(nullable: false, identity: true),
                        ExamineeID = c.Int(nullable: false),
                        ExamID = c.Int(nullable: false),
                        Results = c.String(),
                    })
                .PrimaryKey(t => t.ResultID);
            
            CreateTable(
                "dbo.QuestionSets",
                c => new
                    {
                        QuestionSetID = c.Int(nullable: false, identity: true),
                        ExamID = c.Int(nullable: false),
                        SetName = c.String(),
                        Questions = c.String(),
                    })
                .PrimaryKey(t => t.QuestionSetID);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ExamID = c.Int(nullable: false, identity: true),
                        ExaminerID = c.Int(nullable: false),
                        ExamName = c.String(),
                    })
                .PrimaryKey(t => t.ExamID);
            
            CreateTable(
                "dbo.OngoingExams",
                c => new
                    {
                        OngoingExamID = c.Int(nullable: false, identity: true),
                        ExamineeID = c.Int(nullable: false),
                        ExamID = c.Int(nullable: false),
                        ExamDate = c.DateTime(nullable: false),
                        ExamTime = c.String(),
                    })
                .PrimaryKey(t => t.OngoingExamID);
            
            AddColumn("dbo.Examiners", "Password", c => c.String());
            AddColumn("dbo.Examinees", "PhoneNumber", c => c.String());
            AddColumn("dbo.Examinees", "LastName", c => c.String());
            AddColumn("dbo.Examinees", "FirstName", c => c.String());
            DropForeignKey("dbo.Registrations", "TestId", "dbo.Tests");
            DropForeignKey("dbo.Registrations", "ExamineeId", "dbo.Examinees");
            DropIndex("dbo.Registrations", new[] { "TestId" });
            DropIndex("dbo.Registrations", new[] { "ExamineeId" });
            DropColumn("dbo.Examinees", "Phone");
            DropColumn("dbo.Examinees", "EntryDate");
            DropColumn("dbo.Examinees", "Name");
            DropTable("dbo.QuestionMakers");
            DropTable("dbo.Tests");
            DropTable("dbo.Registrations");
            CreateIndex("dbo.Results", "ExamID");
            CreateIndex("dbo.Results", "ExamineeID");
            CreateIndex("dbo.QuestionSets", "ExamID");
            CreateIndex("dbo.Exams", "ExaminerID");
            CreateIndex("dbo.OngoingExams", "ExamID");
            CreateIndex("dbo.OngoingExams", "ExamineeID");
            AddForeignKey("dbo.OngoingExams", "ExamineeID", "dbo.Examinees", "ExamineeID", cascadeDelete: true);
            AddForeignKey("dbo.Results", "ExamineeID", "dbo.Examinees", "ExamineeID", cascadeDelete: true);
            AddForeignKey("dbo.Results", "ExamID", "dbo.Exams", "ExamID", cascadeDelete: true);
            AddForeignKey("dbo.QuestionSets", "ExamID", "dbo.Exams", "ExamID", cascadeDelete: true);
            AddForeignKey("dbo.OngoingExams", "ExamID", "dbo.Exams", "ExamID", cascadeDelete: true);
            AddForeignKey("dbo.Exams", "ExaminerID", "dbo.Examiners", "ExaminerID", cascadeDelete: true);
        }
    }
}
