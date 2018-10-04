namespace ExamRoom_R33.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tests", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Tests", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tests", "Description", c => c.String());
            AlterColumn("dbo.Tests", "Name", c => c.String());
        }
    }
}
