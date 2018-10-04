namespace ExamRoom_R33.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestXXPaper : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestXXPapers",
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
            DropForeignKey("dbo.TestXXPapers", "TestXQuestion_Id", "dbo.TestXQuestions");
            DropForeignKey("dbo.TestXXPapers", "RegistrationId", "dbo.Registrations");
            DropForeignKey("dbo.TestXXPapers", "ChoiceId", "dbo.Choices");
            DropIndex("dbo.TestXXPapers", new[] { "TestXQuestion_Id" });
            DropIndex("dbo.TestXXPapers", new[] { "ChoiceId" });
            DropIndex("dbo.TestXXPapers", new[] { "RegistrationId" });
            DropTable("dbo.TestXXPapers");
        }
    }
}
