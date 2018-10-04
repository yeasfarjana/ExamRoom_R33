namespace ExamRoom_R33.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsAd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InstituteAdmins", "InsAdminName", c => c.String());
            AddColumn("dbo.InstituteAdmins", "InstituteName", c => c.String());
            DropColumn("dbo.InstituteAdmins", "UserName");
            DropColumn("dbo.InstituteAdmins", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InstituteAdmins", "Password", c => c.String());
            AddColumn("dbo.InstituteAdmins", "UserName", c => c.String());
            DropColumn("dbo.InstituteAdmins", "InstituteName");
            DropColumn("dbo.InstituteAdmins", "InsAdminName");
        }
    }
}
