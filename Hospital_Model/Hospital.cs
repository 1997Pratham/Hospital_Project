﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Model
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string City {  get; set; }
        public string Pincode { get; set; }
        public string Country {  get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Contact>Contacts { get; set; }
    }

    
}