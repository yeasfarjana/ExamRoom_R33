namespace ExamRoom_R33.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Audit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExamAudits",
                c => new
                    {
                        ExamAuditID = c.Int(nullable: false, identity: true),
                        TableName = c.String(),
                        ModifiedBy = c.String(),
                        Action = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExamAuditID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExamAudits");
        }
    }
}
