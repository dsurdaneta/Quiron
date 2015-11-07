using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models.Geography
{
    public class City
    {
        public long ID { get; set; }
        [Display(Name="Nombre")]
        public String Name { get; set; }
        [StringLength(5)]
        [Display(Name = "Código Telefónico")]
        public String PhoneCode { get; set; }

        [Display(Name = "EstadoID")]
        public long StateID { get; set; }
        //public virtual State State { get; set; }
    }
}