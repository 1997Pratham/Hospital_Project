using Hospital_Utility;
using Hospital_ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Service
{
    public interface IHospital
    {
        PageResult<HospitalViewModel> GetAll(int PageNumber, int PageSize);
        HospitalViewModel GetHospitalById(int HospitalId);
        void UpdateHospitalInfo(HospitalViewModel hospitalView);
        void InsertHospitaleInfo(HospitalViewModel hospitalView);
        void DeleteHospitalInfo(int id);

    }
}
