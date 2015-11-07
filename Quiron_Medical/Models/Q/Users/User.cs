using Quiron_Medical.Models.Geography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiron_Medical.Models.Users
{
    public class User
    {
        public long ID { get; set; }
        [Required()]
        public String Code { get; set; }
        [Required()]
        public String FullName { get; set; }
        [Required()]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Required()]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }        
        public int Age { get; set; }
        [Required()]
        public long CityID { get; set; }
        public long UserRoleID { get; set; }
        
        public virtual City City { get; set; }
        public virtual UserRole Role { get; set; }
    }
}