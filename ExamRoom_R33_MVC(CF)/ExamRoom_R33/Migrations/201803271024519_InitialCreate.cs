namespace ExamRoom_R33.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InstituteAdmins",
                c => new
                    {
                        InstituteAdminID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.InstituteAdminID);
            
            CreateTable(
                "dbo.Examiners",
                c => new
                    {
                        ExaminerID = c.Int(nullable: false, identity: true),
                        InstituteAdminID = c.Int(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ExaminerID)
                .ForeignKey("dbo.InstituteAdmins", t => t.InstituteAdminID, cascadeDelete: true)
                .Index(t => t.InstituteAdminID);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ExamID = c.Int(nullable: false, identity: true),
                        ExaminerID = c.Int(nullable: false),
                        ExamName = c.String(),
                    })
                .PrimaryKey(t => t.ExamID)
                .ForeignKey("dbo.Examiners", t => t.ExaminerID, cascadeDelete: true)
                .Index(t => t.ExaminerID);
            
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
                .PrimaryKey(t => t.OngoingExamID)
                .ForeignKey("dbo.Exams", t => t.ExamID, cascadeDelete: true)
                .ForeignKey("dbo.Examinees", t => t.ExamineeID, cascadeDelete: true)
                .Index(t => t.ExamineeID)
                .Index(t => t.ExamID);
            
            CreateTable(
                "dbo.Examinees",
                c => new
                    {
                        ExamineeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ExamineeID);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultID = c.Int(nullable: false, identity: true),
                        ExamineeID = c.Int(nullable: false),
                        ExamID = c.Int(nullable: false),
                        Results = c.String(),
                    })
                .PrimaryKey(t => t.ResultID)
                .ForeignKey("dbo.Exams", t => t.ExamID, cascadeDelete: true)
                .ForeignKey("dbo.Examinees", t => t.ExamineeID, cascadeDelete: true)
                .Index(t => t.ExamineeID)
                .Index(t => t.ExamID);
            
            CreateTable(
                "dbo.QuestionSets",
                c => new
                    {
                        QuestionSetID = c.Int(nullable: false, identity: true),
                        ExamID = c.Int(nullable: false),
                        SetName = c.String(),
                        Questions = c.String(),
                    })
                .PrimaryKey(t => t.QuestionSetID)
                .ForeignKey("dbo.Exams", t => t.ExamID, cascadeDelete: true)
                .Index(t => t.ExamID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Examiners", "InstituteAdminID", "dbo.InstituteAdmins");
            DropForeignKey("dbo.QuestionSets", "ExamID", "dbo.Exams");
            DropForeignKey("dbo.Results", "ExamineeID", "dbo.Examinees");
            DropForeignKey("dbo.Results", "ExamID", "dbo.Exams");
            DropForeignKey("dbo.OngoingExams", "ExamineeID", "dbo.Examinees");
            DropForeignKey("dbo.OngoingExams", "ExamID", "dbo.Exams");
            DropForeignKey("dbo.Exams", "ExaminerID", "dbo.Examiners");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.QuestionSets", new[] { "ExamID" });
            DropIndex("dbo.Results", new[] { "ExamID" });
            DropIndex("dbo.Results", new[] { "ExamineeID" });
            DropIndex("dbo.OngoingExams", new[] { "ExamID" });
            DropIndex("dbo.OngoingExams", new[] { "ExamineeID" });
            DropIndex("dbo.Exams", new[] { "ExaminerID" });
            DropIndex("dbo.Examiners", new[] { "InstituteAdminID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.QuestionSets");
            DropTable("dbo.Results");
            DropTable("dbo.Examinees");
            DropTable("dbo.OngoingExams");
            DropTable("dbo.Exams");
            DropTable("dbo.Examiners");
            DropTable("dbo.InstituteAdmins");
        }
    }
}
