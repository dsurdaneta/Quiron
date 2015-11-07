namespace Quiron_Medical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRatesDoctors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRatesDoctor",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        UserID = c.Long(nullable: false),
                        DoctorID = c.Long(nullable: false),
                        Rating = c.Double(nullable: false),
                        Comment = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doctor", t => t.DoctorID, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: false)
                .Index(t => t.UserID)
                .Index(t => t.DoctorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRatesDoctor", "UserID", "dbo.User");
            DropForeignKey("dbo.UserRatesDoctor", "DoctorID", "dbo.Doctor");
            DropIndex("dbo.UserRatesDoctor", new[] { "DoctorID" });
            DropIndex("dbo.UserRatesDoctor", new[] { "UserID" });
            DropTable("dbo.UserRatesDoctor");
        }
    }
}
