namespace ExamRoom_R33.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class choice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Choices", "Label", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Choices", "Label", c => c.String());
        }
    }
}
