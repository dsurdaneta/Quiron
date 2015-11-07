using Quiron_Medical.Models.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models
{
    public class ConsultingRoom
    {
        #region Properties
        public long ID { get; set; }
        [Display(Name="Número")]
        [Required()]
        public String Number { get; set; }
        [Display(Name = "Descripción")]
        public String Description { get; set; }
        [Display(Name = "Dirección")]
        public String Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Número de Teléfono")]
        [Required()]
        public String MainPhoneNumber { get; set; }
        //public List<String> Phones { get; set; }

        [Required()]
        public long MedicalCentreID { get; set; }
        public virtual MedicalCentre MedicalCentre { get; set; }
        #endregion

        #region Construction
        public ConsultingRoom() { }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="centreID"></param>
        /// <returns></returns>
        public List<ConsultingRoom> GetByMedicalCentre(long centreID)
        {
            QuironContext context = new QuironContext();
            return context.ConsultingRooms.Where(x => x.MedicalCentreID == centreID).ToList();
        }
        #endregion
    }
}