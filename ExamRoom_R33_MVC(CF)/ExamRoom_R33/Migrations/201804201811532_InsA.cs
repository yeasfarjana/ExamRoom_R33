namespace ExamRoom_R33.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsA : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InstituteAdmins", "InsAdminName", c => c.String(nullable: false));
            AlterColumn("dbo.InstituteAdmins", "InstituteName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InstituteAdmins", "InstituteName", c => c.String());
            AlterColumn("dbo.InstituteAdmins", "InsAdminName", c => c.String());
        }
    }
}
