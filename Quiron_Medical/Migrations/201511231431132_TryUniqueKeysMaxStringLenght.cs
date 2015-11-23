namespace Quiron_Medical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryUniqueKeysMaxStringLenght : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.City", "UK_City");
            DropIndex("dbo.MedicalCentreType", new[] { "Name" });
            DropIndex("dbo.Country", new[] { "Name" });
            DropIndex("dbo.State", "UK_State");
            DropIndex("dbo.User", new[] { "Code" });
            DropIndex("dbo.User", new[] { "Email" });
            DropIndex("dbo.UserRole", new[] { "Name" });
            AlterColumn("dbo.City", "Name", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.MedicalCentreType", "Name", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.Country", "Name", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.State", "Name", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.User", "Code", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.UserRole", "Name", c => c.String(nullable: false, maxLength: 450));
            CreateIndex("dbo.City", "StateID");
            CreateIndex("dbo.MedicalCentreType", "Name", unique: true);
            CreateIndex("dbo.State", "CountryID");
            CreateIndex("dbo.User", "Email", unique: true);
            CreateIndex("dbo.UserRole", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserRole", new[] { "Name" });
            DropIndex("dbo.User", new[] { "Email" });
            DropIndex("dbo.State", new[] { "CountryID" });
            DropIndex("dbo.MedicalCentreType", new[] { "Name" });
            DropIndex("dbo.City", new[] { "StateID" });
            AlterColumn("dbo.UserRole", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.State", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Country", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.MedicalCentreType", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.City", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.UserRole", "Name", unique: true);
            CreateIndex("dbo.User", "Email", unique: true);
            CreateIndex("dbo.User", "Code", unique: true);
            CreateIndex("dbo.State", new[] { "Name", "CountryID" }, unique: true, name: "UK_State");
            CreateIndex("dbo.Country", "Name", unique: true);
            CreateIndex("dbo.MedicalCentreType", "Name", unique: true);
            CreateIndex("dbo.City", new[] { "Name", "StateID" }, unique: true, name: "UK_City");
        }
    }
}
