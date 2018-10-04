namespace ExamRoom_R33.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Qus : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Questions", name: "QuestionMaker_QuestionMakerID", newName: "QuestionMakerID");
            RenameIndex(table: "dbo.Questions", name: "IX_QuestionMaker_QuestionMakerID", newName: "IX_QuestionMakerID");
            DropColumn("dbo.Questions", "ExaminerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "ExaminerID", c => c.Int());
            RenameIndex(table: "dbo.Questions", name: "IX_QuestionMakerID", newName: "IX_QuestionMaker_QuestionMakerID");
            RenameColumn(table: "dbo.Questions", name: "QuestionMakerID", newName: "QuestionMaker_QuestionMakerID");
        }
    }
}
