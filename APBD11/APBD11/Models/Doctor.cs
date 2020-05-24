using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD11.Models
{
    public class Doctor
    {
        public Doctor()
        {
            Prescription = new HashSet<Prescription>();
        }

        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}
