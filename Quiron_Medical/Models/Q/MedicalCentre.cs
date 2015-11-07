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
        [Display(Name="Nombre")]
        public String Name { get; set; }
        [Display(Name = "Dirección")]
        public String Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono Principal")]
        public String MainPhoneNumber { get; set; }
        //public List<String> Phones { get; set; }
        [DataType(DataType.PostalCode)]
        [Display(Name = "Código Postal")]
        public String PostalCode { get; set; }
        public long CityID { get; set; }
        public long MedicalCentreTypeID { get; set; }

        [Display(Name = "Ciudad")]
        public virtual Geography.City City { get; set; }
        [Display(Name = "Tipo")]
        public virtual MedicalCentreType Type { get; set; }

        
    }
}