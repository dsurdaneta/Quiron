using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models.Geography
{
    public class State
    {
        public long ID { get; set; }
        [Display(Name="Nombre")]
        public String Name { get; set; }
        [Display(Name = "PaisID")]
        public long CountryID { get; set; }
        
        public virtual List<City> Cities { get; set; }
        //public virtual Country Country { get; set; }
    }
}