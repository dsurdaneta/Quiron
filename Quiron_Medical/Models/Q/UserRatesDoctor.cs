using Quiron_Medical.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models
{
    public class UserRatesDoctor
    {
        #region Properties
        public long ID { get; set; }
        [Required()]
        [Display(Name = "UsuarioID")]
        public long UserID { get; set; }
        [Required()]
        public long DoctorID { get; set; }
        [Required()]
        [Display(Name="Valoración")]
        public Double Rating { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Comentario")]
        public String Comment { get; set; }
        [Required()]
        [DataType(DataType.DateTime)]
        [Display(Name="Fecha")]
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
        public virtual Doctor Doctor { get; set; }
        #endregion

    }
}