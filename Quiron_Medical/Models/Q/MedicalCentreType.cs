using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models
{
    public class MedicalCentreType
    {
        #region Properties
        public long ID { get; set; }
        [Display(Name="Tipo")]
        [Required()]
        [Index(IsUnique = true)]
        public String Name { get; set; }
        [Display(Name = "Descripción")]
        public String Description { get; set; }
        #endregion

        #region Construction
        public MedicalCentreType() { }
        #endregion

        #region Methods
        #endregion
    }
}