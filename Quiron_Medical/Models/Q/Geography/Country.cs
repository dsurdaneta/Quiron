﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models.Geography
{
    public class Country
    {
        #region Properties
        public long ID { get; set; }
        [Required()]
        [StringLength(450)]
        [Display(Name="Pais")]
        //[Index(IsUnique = true)]
        public String Name { get; set; }
        [StringLength(5)]
        [Display(Name = "Código Telefónico")]
        public String PhoneCode { get; set; }
        [Display(Name = "Abreviado")]
        public String Abbreviation { get; set; }

        public virtual List<State> States { get; set; }
        #endregion

        #region Construction
        public Country() { }
        #endregion

        #region Methods
        #endregion
    }
}