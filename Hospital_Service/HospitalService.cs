using Hospital_Model;
using Hospital_Repository.Interface;
using Hospital_Utility;
using Hospital_ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital_Service
{
    public class HospitalService : IHospital
    {
        private readonly IUnitofWork _unitofWork;

        public HospitalService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public void DeleteHospitalInfo(int id)
        {
            var model = _unitofWork.GenericRepository<Hospital>().GetbyId(id);
            _unitofWork.GenericRepository<Hospital>().delete(model);
            _unitofWork.Save();
        }

        public PageResult<HospitalViewModel> GetAll(int PageNumber, int PageSize)
        {
            List<HospitalViewModel> vmList;
            int totalCount;

            try
            {
                int excludeRecords = (PageSize * PageNumber) - PageSize;
                var modelList = _unitofWork.GenericRepository<Hospital>().GetAll().ToList();

                totalCount = modelList.Count; // Get total count once
                vmList = ConvertModelToViewModelList(modelList.Skip(excludeRecords).Take(PageSize).ToList());
            }
            catch (Exception)
            {
                throw; // Consider logging the exception here
            }

            return new PageResult<HospitalViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize
            };
        }

        public HospitalViewModel GetHospitalById(int HospitalId)
        {
            var model = _unitofWork.GenericRepository<Hospital>().GetbyId(HospitalId);
            var vm = new HospitalViewModel(model);
            return vm;
        }

        public void InsertHospitaleInfo(HospitalViewModel hospitalView)
        {
            var model = new HospitalViewModel().ConvertViewModel(hospitalView);
            //_unitofWork.GenericRepository<HospitalViewModel>().add(model);
            _unitofWork.Save();
        }
        public void UpdateHospitalInfo(HospitalViewModel hospitalView)
        {
            var model = new HospitalViewModel().ConvertViewModel(hospitalView);
            var modelById=  _unitofWork.GenericRepository<HospitalViewModel>().GetbyId(model.Id);
            modelById.Name=hospitalView.Name;
            modelById.City=hospitalView.City;
            modelById.Pincode=hospitalView.Pincode;
            modelById.Country=hospitalView.Country;
            _unitofWork.GenericRepository<HospitalViewModel>().update(modelById);
            _unitofWork.Save();
        }

        private List<HospitalViewModel> ConvertModelToViewModelList(List<Hospital> modelList)
        {
            return modelList.Select(x => new HospitalViewModel(x)).ToList();
        }
    }
}
