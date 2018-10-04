namespace ExamRoom_R33.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "QuestionMakerID", "dbo.QuestionMakers");
            DropIndex("dbo.Questions", new[] { "QuestionMakerID" });
            AlterColumn("dbo.Questions", "QuestionType", c => c.String(nullable: false));
            AlterColumn("dbo.Questions", "Question1", c => c.String(nullable: false));
            AlterColumn("dbo.Questions", "QuestionMakerID", c => c.Int(nullable: false));
            AlterColumn("dbo.QuestionCategories", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.QuestionMakers", "QuestionMakerName", c => c.String(nullable: false));
            AlterColumn("dbo.Examinees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Examinees", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Examinees", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Examinees", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Examiners", "UserName", c => c.String(nullable: false));
            CreateIndex("dbo.Questions", "QuestionMakerID");
            AddForeignKey("dbo.Questions", "QuestionMakerID", "dbo.QuestionMakers", "QuestionMakerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "QuestionMakerID", "dbo.QuestionMakers");
            DropIndex("dbo.Questions", new[] { "QuestionMakerID" });
            AlterColumn("dbo.Examiners", "UserName", c => c.String());
            AlterColumn("dbo.Examinees", "Email", c => c.String());
            AlterColumn("dbo.Examinees", "Phone", c => c.String());
            AlterColumn("dbo.Examinees", "Address", c => c.String());
            AlterColumn("dbo.Examinees", "Name", c => c.String());
            AlterColumn("dbo.QuestionMakers", "QuestionMakerName", c => c.String());
            AlterColumn("dbo.QuestionCategories", "Category", c => c.String());
            AlterColumn("dbo.Questions", "QuestionMakerID", c => c.Int());
            AlterColumn("dbo.Questions", "Question1", c => c.String());
            AlterColumn("dbo.Questions", "QuestionType", c => c.String());
            CreateIndex("dbo.Questions", "QuestionMakerID");
            AddForeignKey("dbo.Questions", "QuestionMakerID", "dbo.QuestionMakers", "QuestionMakerID");
        }
    }
}
