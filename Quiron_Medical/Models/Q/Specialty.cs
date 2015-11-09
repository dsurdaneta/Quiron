using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models
{
    public class Specialty
    {
        #region Properties
        public long ID { get; set; }
        [StringLength(100)]
        [Required()]
        [Index(IsUnique = true)]
        [Display(Name = "Especialización")]
        public String Name { get; set; }
        [Display(Name = "Descripción")]
        public String Description { get; set; }

        public virtual List<Doctor> Doctors { get; set; }
        #endregion

        #region Construction
        public Specialty() { }
        #endregion

        #region Methods
        #endregion        
    }
}