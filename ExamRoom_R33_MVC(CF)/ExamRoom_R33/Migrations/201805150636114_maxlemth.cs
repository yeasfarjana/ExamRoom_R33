namespace ExamRoom_R33.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maxlemth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Examinees", "Name", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Examinees", "Name", c => c.String(nullable: false));
        }
    }
}
