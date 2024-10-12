using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Repository.Interface
{
    public interface IUnitofWork
    {
        IGenericRepository<T>GenericRepository<T>()where T : class;
        void Save(); 
    }
}
