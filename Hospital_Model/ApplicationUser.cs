using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string Specialist { get; set; }
        [NotMapped]
        public ICollection<Appointment> Appointments { get; set; }
        public Department Department { get; set; }
        public ICollection<Payroll> Payrolls { get; set; }

    }

    public enum Gender
    {
        Male,Female,Other
    }
}
