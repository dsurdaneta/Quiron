using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Especialización")]
        public String Name { get; set; }
        [Display(Name = "Descripción")]
        public String Description { get; set; }
        #endregion

        #region Construction
        public Specialty() { }
        #endregion

        #region Methods
        #endregion
    }
}