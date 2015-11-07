namespace Quiron_Medical.Migrations
{
    using Quiron_Medical.Models;
    using Quiron_Medical.Models.Geography;
    using Quiron_Medical.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Quiron_Medical.Models.DAL.QuironContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Quiron_Medical.Models.DAL.QuironContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var centreTypes = new List<MedicalCentreType>
            {
                new MedicalCentreType { Name="Hospital" },
                new MedicalCentreType { Name= "Clínica" },
                new MedicalCentreType { Name= "Ambulatorio" },
                new MedicalCentreType { Name= "Atención Primaria" }
            };
            centreTypes.ForEach(t => context.MedicalCentreTypes.AddOrUpdate(t));
            context.SaveChanges();

            var specialties = new List<Specialty> 
            {
                new Specialty { Name= "Ninguna" },
                new Specialty { Name= "Internista" },
                new Specialty { Name= "Cardiología" },
                new Specialty { Name= "Pediatría" },
                new Specialty { Name= "Otorrino" },
                new Specialty { Name= "Endocrino" },                
                new Specialty { Name= "Urología" },
                new Specialty { Name= "Ginecología" },
                new Specialty { Name= "Gastroenterología" },
                new Specialty { Name= "Odontología" },
                new Specialty { Name= "Psicología" },
                new Specialty { Name= "Psiquiatría" },
                new Specialty { Name= "Oftalmología" },
                new Specialty { Name= "Traumatología" },
                new Specialty { Name= "Homeópata" },
                new Specialty { Name= "Integral" },
                new Specialty { Name= "Cirugía General" }
            };

            specialties.ForEach(s => context.Specialties.AddOrUpdate(s));
            context.SaveChanges();

            context.Countries.AddOrUpdate(new Country
            {
                Name = "Venezuela",
                PhoneCode = "58",
                Abbreviation = "VZLA",
                States = new List<State>
                {
                   new State { 
                       Name = "Carabobo",
                       Cities = new List<City> 
                       {
                           new City { Name="Valencia", PhoneCode="241" },
                           new City { Name="Naguanagua", PhoneCode="241" },
                           new City { Name="Guacara", PhoneCode="245" },
                           new City { Name="San Diego", PhoneCode="241" },
                           new City { Name="Puerto Cabello", PhoneCode="242" },
                           new City { Name="Tocuyito", PhoneCode="241" },
                           new City { Name="Bejuma", PhoneCode="249" },
                           new City { Name="Los Guayos", PhoneCode="241" },
                           new City { Name="Canoabo", PhoneCode="249" },
                           new City { Name="Montalbán", PhoneCode="249" },
                           new City { Name="Morón", PhoneCode="242" },
                           new City { Name="Mariara", PhoneCode="243" },
                           new City { Name="San Joaquin", PhoneCode="245" },
                           new City { Name="Güigüe", PhoneCode="245" }
                       }
                   },
                   new State 
                   {
                       Name = "Aragua",
                       Cities = new List<City>
                       {
                           new City { Name="Maracay", PhoneCode="243" },
                           new City { Name="Cagua", PhoneCode="244" },
                           new City { Name="Turmero", PhoneCode="244" }
                       }
                   },
                   new State 
                   {
                       Name = "Lara",
                       Cities = new List<City>
                       {
                           new City { Name = "Barquisimeto", PhoneCode= "251" },
                           new City { Name = "Cabudare", PhoneCode= "251" },
                           new City { Name = "Duaca", PhoneCode= "253" },
                           new City { Name = "Quíbor", PhoneCode= "253" },
                           new City { Name = "Carora", PhoneCode= "252" }
                       }
                   },
                   new State 
                   {
                       Name = "Distrito Capital",
                       Cities = new List<City>
                       {
                           new City { Name = "Caracas", PhoneCode= "212" }
                       }
                   },
                   new State 
                   {
                       Name = "Miranda",
                       Cities = new List<City>
                       {
                           new City { Name = "Los Teques", PhoneCode= "212" },
                           new City { Name = "Charallave", PhoneCode= "283" }
                       }
                   },
                   new State 
                   {
                       Name = "Bolívar",
                       Cities = new List<City>
                       {
                           new City { Name = "Ciudad Bolívar", PhoneCode= "285" },
                           new City { Name = "Puerto Ordaz", PhoneCode= "286" },
                           new City { Name = "San Félix", PhoneCode= "286" },
                           new City { Name = "Upata", PhoneCode= "288" }
                       }
                   }
                }
            });
            context.SaveChanges();

            var roles = new List<UserRole> 
            {
                new UserRole{ Name="admin", Description="Administrador del Sistema" },
                new UserRole{ Name="user", Description="Usuario Básico" },
                new UserRole{ Name="doctor", Description="Médico" },
                new UserRole{ Name="medical_centre", Description="Centro Médico" }
                
            };
            roles.ForEach(r => context.UserRoles.AddOrUpdate(r));
            context.SaveChanges();

            context.Users.AddOrUpdate(new User
            {
                UserRoleID = 1,
                Code = "admin",
                Password = "admin",
                FullName = "Administrador del Sistema Quirón",
                CityID = 1,
                BirthDate = DateTime.Now.AddYears(-25),
                Email = "admin@quiron.test",
                Age = 25
            });
            context.SaveChanges();

        }
    }
}
