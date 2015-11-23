using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models.Users
{
    public class UserRole
    {
        public long ID { get; set; }
        [Required()]
        [StringLength(450)]
        [Index(IsUnique = true)]
        [Display(Name="Rol")]
        public String Name { get; set; }
        [Display(Name = "Descripción")]
        public String Description { get; set; }
    }
}