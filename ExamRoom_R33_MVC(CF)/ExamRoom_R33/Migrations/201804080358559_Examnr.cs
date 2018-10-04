namespace ExamRoom_R33.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Examnr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Examinees", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Examinees", "PhoneNumber");
        }
    }
}
