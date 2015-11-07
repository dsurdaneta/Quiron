using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models
{
    public class ConsultingRoom
    {
        public long ID { get; set; }
        public String Number { get; set; }
        public String Description { get; set; }
        public String Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public String MainPhoneNumber { get; set; }
        //public List<String> Phones { get; set; }

        public long MedicalCentreID { get; set; }
        public virtual MedicalCentre MedicalCentre { get; set; }
    }
}