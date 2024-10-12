using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Model
{
    public class Supplier
    {
        public int ID { get; set; }
        public string Company { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ICollection<MedicineReport> MedicineReport { get; set; }
       
    }
}
