using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models.Users
{
    public class UserRole
    {
        public long ID { get; set; }
        [Required()]
        public String Name { get; set; }
        public String Description { get; set; }
    }
}