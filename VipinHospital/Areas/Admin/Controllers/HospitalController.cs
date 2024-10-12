using Hospital_Service;
using Hospital_ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace VipinHospital.Areas.Admin.Controllers
{
    public class HospitalController : Controller
    {
        private IHospital _Hospital;

        public HospitalController(IHospital hospital)
        {
            _Hospital = hospital;
        }

        public IActionResult Index(int PageNumber=1,int PageSize=10)
        {
            return View(_Hospital.GetAll(PageNumber,PageSize));
        }

        [HttpPost]
        public IActionResult Edit(int id)
        {
            var ViewModel = _Hospital.GetHospitalById(id);
            return View(ViewModel);
        }

        [HttpPost]
        public IActionResult Edit(HospitalViewModel vm)
        {
           _Hospital.UpdateHospitalInfo(vm);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Create()
        {   
            return View();
        }

        [HttpPost]
        public IActionResult Create(HospitalViewModel vm)
        {
            _Hospital.InsertHospitaleInfo(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) 
        {
            _Hospital.DeleteHospitalInfo(id);
            return RedirectToAction("Index");

        }

    }
}
