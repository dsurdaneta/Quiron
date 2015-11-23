namespace Quiron_Medical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixtTry20151108 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.City", new[] { "StateID" });
            DropIndex("dbo.State", new[] { "CountryID" });
            //CreateIndex("dbo.City", new[] { "Name", "StateID" }, unique: true, name: "UK_City");
            CreateIndex("dbo.Specialty", "Name", unique: true);
            //CreateIndex("dbo.MedicalCentreType", "Name", unique: true);
            //CreateIndex("dbo.Country", "Name", unique: true);
            //CreateIndex("dbo.State", new[] { "Name", "CountryID" }, unique: true, name: "UK_State");
            //CreateIndex("dbo.User", "Code", unique: true);
            //CreateIndex("dbo.User", "Email", unique: true);
            //CreateIndex("dbo.UserRole", "Name", unique: true);
        }
        
        public override void Down()
        {
            //DropIndex("dbo.UserRole", new[] { "Name" });
            //DropIndex("dbo.User", new[] { "Email" });
            //DropIndex("dbo.User", new[] { "Code" });
            //DropIndex("dbo.State", "UK_State");
            DropIndex("dbo.Country", new[] { "Name" });
            //DropIndex("dbo.MedicalCentreType", new[] { "Name" });
            DropIndex("dbo.Specialty", new[] { "Name" });
            //DropIndex("dbo.City", "UK_City");
            CreateIndex("dbo.State", "CountryID");
            CreateIndex("dbo.City", "StateID");
        }
    }
}
