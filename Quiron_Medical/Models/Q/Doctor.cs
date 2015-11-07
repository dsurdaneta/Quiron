using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models
{
    public class Doctor
    {
        public long ID { get; set; }
        public String FullName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public String MainPhoneNumber { get; set; }
        [DataType(DataType.PhoneNumber)]
        public String MainCellphoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        public long MainCityID { get; set; }

        public virtual List<DoctorSpecialty> Specialties { get; set; }
        public virtual Geography.City MainCity { get; set; }
        public virtual List<ConsultingRoom> ConsultingRooms { get; set; }

        public Doctor()
        {
            ID = 0;
            FullName = "";
            MainCellphoneNumber = "";
            MainCityID = 0;
            MainPhoneNumber = "";
            Email = "";

            MainCity = new Geography.City();
            Specialties = new List<Specialty>();
            ConsultingRooms = new List<ConsultingRoom>();
        }
    }
}