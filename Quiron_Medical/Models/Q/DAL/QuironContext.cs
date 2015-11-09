using Quiron_Medical.Models;
using Quiron_Medical.Models.Geography;
using Quiron_Medical.Models.Users;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Quiron_Medical.Models.DAL
{
    public class QuironContext : DbContext
    {
        public QuironContext()
            : base("QuironContext")
        {
            //DropCreateDatabaseAlways<QuironContext>();
        }

        /*Datos geograficos*/
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        
        public DbSet<ConsultingRoom> ConsultingRooms { get; set; }
        public DbSet<MedicalCentre> MedicalCentres { get; set; }
        public DbSet<MedicalCentreType> MedicalCentreTypes { get; set; }

        /*Usuarios*/
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<UserRatesDoctor> UserRatesDoctors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            /*Many-to-many DoctorSpecialty*/
            modelBuilder.Entity<Doctor>()
                .HasMany<Specialty>(s => s.Specialties)
                .WithMany(d => d.Doctors)
                .Map(ds => 
                    {
                        ds.MapLeftKey("DoctorID");
                        ds.MapRightKey("SpecialtyID");
                        ds.ToTable("DoctorSpecialty");
                    });

            /*Many-to-many DoctorConsultingRoom*/
            modelBuilder.Entity<Doctor>()
                .HasMany<ConsultingRoom>(cr => cr.ConsultingRooms)
                .WithMany(d => d.Doctors)
                .Map(dcr =>
                {
                    dcr.MapLeftKey("DoctorID");
                    dcr.MapRightKey("ConsultingRoomID");
                    dcr.ToTable("DoctorConsultingRoom");
                });
        }
    }
}