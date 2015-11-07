﻿using Quiron_Medical.Models.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models.Geography
{
    public class State
    {
        #region Properties
        public long ID { get; set; }
        [Display(Name="Estado")]
        [Required()]
        public String Name { get; set; }
        [Display(Name = "PaisID")]
        [Required()]
        public long CountryID { get; set; }
        
        public virtual List<City> Cities { get; set; }
        //public virtual Country Country { get; set; }
        #endregion

        #region Construction
        public State() { }
        #endregion

        #region Methods
        public List<State> GetStatesByCountryID(long countryID)
        {
            List<State> states = new List<State>();
            QuironContext context = new QuironContext();
            states = context.States.Where(x => x.CountryID == countryID).ToList();
            return states;
        }
        #endregion
    }
}