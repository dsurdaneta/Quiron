using Quiron_Medical.Models.Geography;
using Quiron_Medical.Models.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models.DAL
{
    public class QuironContextInitializer : DropCreateDatabaseAlways<QuironContext>
    {
        protected override void Seed(QuironContext context)
        {
            var centreTypes = new List<MedicalCentreType>
            {
                new MedicalCentreType { Name="Hospital" },
                new MedicalCentreType { Name= "Clínica" },
                new MedicalCentreType { Name= "Ambulatorio" },
                new MedicalCentreType { Name= "Atención Primaria" }
            };

            centreTypes.ForEach(t => context.MedicalCentreTypes.Add(t));
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

            specialties.ForEach(s => context.Specialties.Add(s));
            context.SaveChanges();

            context.Countries.Add(new Country
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
            roles.ForEach(r => context.UserRoles.Add(r));
            context.SaveChanges();

            context.Users.Add(new User
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

            context.MedicalCentres.Add(new MedicalCentre 
            {
                CityID = 1,
                Address = "Calle falsa 123",
                Name = "Hospital de Prueba",
                MainPhoneNumber = "+58-241-2213574",
                MedicalCentreTypeID = 1,
                PostalCode = "2001"                
            });
            context.SaveChanges();
            //base.Seed(context);
        }
    }
}