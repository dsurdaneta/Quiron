using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models
{
    public class DoctorSpecialty
    {
        #region Properties
        public long DoctorID { get; set; }
        public long SpecialtyID { get; set; }

        //public Doctor Doctor { get; set; }
        //public Specialty Specialty { get; set; }
        public virtual List<Doctor> Doctors { get; set; }
        public virtual List<Specialty> Specialties { get; set; }
        #endregion

        #region Construction
        public DoctorSpecialty() { }
        #endregion
    }
}