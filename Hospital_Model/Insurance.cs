﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Model
{
    public class Insurance
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; }
        public string StarDate { get; set; }
        public string EndDate { get; set; }
        public ICollection<Bill> Bill { get; set; }

    }
}
