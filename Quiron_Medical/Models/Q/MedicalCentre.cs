using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models
{
    public class MedicalCentre
    {
        public long ID { get; set; }
        public String Name { get; set; }
        public virtual MedicalCentreType Type { get; set; }
        public String Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public String MainPhoneNumber { get; set; }
        //public List<String> Phones { get; set; }
        [DataType(DataType.PostalCode)]
        public String PostalCode { get; set; }

        public virtual Geography.City City { get; set; }
    }
}