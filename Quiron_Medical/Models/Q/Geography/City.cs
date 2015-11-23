using Quiron_Medical.Models.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models.Geography
{
    public class City
    {
        #region Properties
        public long ID { get; set; }
        [Required()]
        [StringLength(450)]
        //[Index("UK_City",1,IsUnique = true)]
        [Display(Name = "Ciudad")]
        public String Name { get; set; }
        [StringLength(5)]
        //[Index("UK_City", 2, IsUnique = true)]
        [Display(Name = "Código Telefónico")]
        public String PhoneCode { get; set; }

        [Required()]
        //[Index("UK_City", 2, IsUnique = true)]
        [Display(Name = "EstadoID")]
        public long StateID { get; set; }
        //public virtual State State { get; set; }
        #endregion

        #region Construction
        public City() { }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateID"></param>
        /// <returns></returns>
        public List<City> GetCitiesByStateID(long stateID)
        {
            List<City> cities = new List<City>();
            QuironContext context = new QuironContext();
            cities = context.Cities.Where(x => x.StateID == stateID).ToList();
            return cities;
        }
        #endregion
    }
}