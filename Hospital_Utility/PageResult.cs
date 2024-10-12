using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Utility
{
   public class PageResult<T>where T : class
    {
        public PageResult() 
        {
        }
        //public List<T> Data { get; set; }
        //public int TotalItems { get; set; }
        //public int PageNumber { get; set; } = 0;
        //public int PageSize { get; set;} = 0;


        public List<T> Data { get; set; } = new List<T>(); // Initialize list to avoid null reference
        public int TotalItems { get; set; }
        public int PageNumber { get; set; } = 1; // Typically starts from 1
        public int PageSize { get; set; } = 10; // Default page size
    }
}
