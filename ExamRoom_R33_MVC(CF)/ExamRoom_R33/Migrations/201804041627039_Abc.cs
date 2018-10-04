namespace ExamRoom_R33.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Abc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedbacks", "FeedbackScale", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Feedbacks", "FeedbackScale");
        }
    }
}
