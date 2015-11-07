namespace Quiron_Medical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PhoneCode = c.String(maxLength: 5),
                        StateID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.State", t => t.StateID, cascadeDelete: true)
                .Index(t => t.StateID);

            CreateTable(
                "dbo.ConsultingRoom",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Number = c.String(nullable: false),
                        Description = c.String(),
                        Address = c.String(),
                        MainPhoneNumber = c.String(nullable: false),
                        MedicalCentreID = c.Long(nullable: false),
                        //Doctor_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MedicalCentre", t => t.MedicalCentreID, cascadeDelete: true)
                //.ForeignKey("dbo.Doctor", t => t.Doctor_ID)
                .Index(t => t.MedicalCentreID);
                //.Index(t => t.Doctor_ID);
            
            CreateTable(
                "dbo.MedicalCentre",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        MainPhoneNumber = c.String(),
                        PostalCode = c.String(),
                        CityID = c.Long(nullable: false),
                        MedicalCentreTypeID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.City", t => t.CityID, cascadeDelete: true)
                .ForeignKey("dbo.MedicalCentreType", t => t.MedicalCentreTypeID, cascadeDelete: true)
                .Index(t => t.CityID)
                .Index(t => t.MedicalCentreTypeID);
            
            CreateTable(
                "dbo.MedicalCentreType",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PhoneCode = c.String(maxLength: 5),
                        Abbreviation = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CountryID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Country", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Doctor",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        FullName = c.String(),
                        MainPhoneNumber = c.String(),
                        MainCellphoneNumber = c.String(),
                        Email = c.String(),
                        MainCityID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.City", t => t.MainCityID, cascadeDelete: true)
                .Index(t => t.MainCityID);
            
            CreateTable(
                "dbo.Specialty",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        CityID = c.Long(nullable: false),
                        UserRoleID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.City", t => t.CityID, cascadeDelete: true)
                .ForeignKey("dbo.UserRole", t => t.UserRoleID, cascadeDelete: true)
                .Index(t => t.CityID)
                .Index(t => t.UserRoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "UserRoleID", "dbo.UserRole");
            DropForeignKey("dbo.User", "CityID", "dbo.City");
            DropForeignKey("dbo.Doctor", "MainCityID", "dbo.City");
            DropForeignKey("dbo.ConsultingRoom", "Doctor_ID", "dbo.Doctor");
            DropForeignKey("dbo.State", "CountryID", "dbo.Country");
            DropForeignKey("dbo.City", "StateID", "dbo.State");
            DropForeignKey("dbo.ConsultingRoom", "MedicalCentreID", "dbo.MedicalCentre");
            DropForeignKey("dbo.MedicalCentre", "MedicalCentreTypeID", "dbo.MedicalCentreType");
            DropForeignKey("dbo.MedicalCentre", "CityID", "dbo.City");
            DropIndex("dbo.User", new[] { "UserRoleID" });
            DropIndex("dbo.User", new[] { "CityID" });
            DropIndex("dbo.Doctor", new[] { "MainCityID" });
            DropIndex("dbo.State", new[] { "CountryID" });
            DropIndex("dbo.MedicalCentre", new[] { "MedicalCentreTypeID" });
            DropIndex("dbo.MedicalCentre", new[] { "CityID" });
            DropIndex("dbo.ConsultingRoom", new[] { "Doctor_ID" });
            DropIndex("dbo.ConsultingRoom", new[] { "MedicalCentreID" });
            DropIndex("dbo.City", new[] { "StateID" });
            DropTable("dbo.User");
            DropTable("dbo.UserRole");
            DropTable("dbo.Specialty");
            DropTable("dbo.Doctor");
            DropTable("dbo.State");
            DropTable("dbo.Country");
            DropTable("dbo.MedicalCentreType");
            DropTable("dbo.MedicalCentre");
            DropTable("dbo.ConsultingRoom");
            DropTable("dbo.City");
        }
    }
}
