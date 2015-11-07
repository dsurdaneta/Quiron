using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models
{
    public class MedicalCentreType
    {
        public long ID { get; set; }
        [Display(Name="Nombre")]
        public String Name { get; set; }
        [Display(Name = "Descripción")]
        public String Description { get; set; }
    }
}