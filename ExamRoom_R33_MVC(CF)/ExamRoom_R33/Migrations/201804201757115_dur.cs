namespace ExamRoom_R33.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dur : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionXDurations", "RegistrationId", "dbo.Registrations");
            DropForeignKey("dbo.QuestionXDurations", "TestXQuestion_Id", "dbo.TestXQuestions");
            DropIndex("dbo.QuestionXDurations", new[] { "RegistrationId" });
            DropIndex("dbo.QuestionXDurations", new[] { "TestXQuestion_Id" });
            DropTable("dbo.QuestionXDurations");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.QuestionXDurations", "TestXQuestion_Id");
            CreateIndex("dbo.QuestionXDurations", "RegistrationId");
            AddForeignKey("dbo.QuestionXDurations", "TestXQuestion_Id", "dbo.TestXQuestions", "Id");
            AddForeignKey("dbo.QuestionXDurations", "RegistrationId", "dbo.Registrations", "Id", cascadeDelete: true);
        }
    }
}
