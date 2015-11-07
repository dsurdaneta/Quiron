using Quiron_Medical.Models.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models
{
    public class MedicalCentre
    {
        #region Properties
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
        #endregion

        #region Construction
        public MedicalCentre() { }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public List<MedicalCentre> GetCentresByType(long typeID)
        {
            QuironContext context = new QuironContext();
            return context.MedicalCentres.Where(x => x.MedicalCentreTypeID == typeID).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public List<MedicalCentre> GetCentresByCity(long cityID)
        {
            QuironContext context = new QuironContext();
            return context.MedicalCentres.Where(x => x.CityID == cityID).ToList();
        }
        #endregion

    }
}