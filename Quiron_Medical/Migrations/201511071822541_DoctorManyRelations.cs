namespace Quiron_Medical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorManyRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConsultingRoom", "Doctor_ID", "dbo.Doctor");
            DropIndex("dbo.ConsultingRoom", new[] { "Doctor_ID" });
            CreateTable(
                "dbo.DoctorConsultingRoom",
                c => new
                    {
                        DoctorID = c.Long(nullable: false),
                        ConsultingRoomID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.DoctorID, t.ConsultingRoomID })
                .ForeignKey("dbo.Doctor", t => t.DoctorID, cascadeDelete: false)
                .ForeignKey("dbo.ConsultingRoom", t => t.ConsultingRoomID, cascadeDelete: false)
                .Index(t => t.DoctorID)
                .Index(t => t.ConsultingRoomID);
            
            CreateTable(
                "dbo.DoctorSpecialty",
                c => new
                    {
                        DoctorID = c.Long(nullable: false),
                        SpecialtyID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.DoctorID, t.SpecialtyID })
                .ForeignKey("dbo.Doctor", t => t.DoctorID, cascadeDelete: false)
                .ForeignKey("dbo.Specialty", t => t.SpecialtyID, cascadeDelete: false)
                .Index(t => t.DoctorID)
                .Index(t => t.SpecialtyID);
            
            DropColumn("dbo.ConsultingRoom", "Doctor_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ConsultingRoom", "Doctor_ID", c => c.Long());
            DropForeignKey("dbo.DoctorSpecialty", "SpecialtyID", "dbo.Specialty");
            DropForeignKey("dbo.DoctorSpecialty", "DoctorID", "dbo.Doctor");
            DropForeignKey("dbo.DoctorConsultingRoom", "ConsultingRoomID", "dbo.ConsultingRoom");
            DropForeignKey("dbo.DoctorConsultingRoom", "DoctorID", "dbo.Doctor");
            DropIndex("dbo.DoctorSpecialty", new[] { "SpecialtyID" });
            DropIndex("dbo.DoctorSpecialty", new[] { "DoctorID" });
            DropIndex("dbo.DoctorConsultingRoom", new[] { "ConsultingRoomID" });
            DropIndex("dbo.DoctorConsultingRoom", new[] { "DoctorID" });
            DropTable("dbo.DoctorSpecialty");
            DropTable("dbo.DoctorConsultingRoom");
            //CreateIndex("dbo.ConsultingRoom", "Doctor_ID");
            //AddForeignKey("dbo.ConsultingRoom", "Doctor_ID", "dbo.Doctor", "ID");
        }
    }
}
