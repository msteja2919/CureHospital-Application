using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CureHospitalDALCrossPlatform.Models;
using CureHospitalDALCrossPlatForm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CureHospitalWebService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        HospitalRepository hospitalRepository;

        public HomeController(HospitalRepository repository)
        {
            //Implement the logic here
            this.hospitalRepository = repository;

        }

        #region FetchDoctorIDs - Do not modify the signature
        [HttpGet]
        public JsonResult FetchDoctorIDs(string specializationCode)
        {
            //Implement the logic here
            List<int>list1=new List<int>();
            try
            {
                list1 = hospitalRepository.FetchDoctorIDs(specializationCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                list1 = null;
            }

            return Json(list1);

        }

        #endregion

        #region AddDoctorSpecialization - Do not modify the signature
        [HttpPost]
        public bool AddDoctorSpecialization(int doctorId, string specializationCode, DateTime specializationDate)
        {
           //Implement the logic here
           bool  result = false;
            try
            {
                result = hospitalRepository.AddDoctorSpecialization(doctorId, specializationCode, specializationDate);
            }
            catch (Exception ex) 
            {
                result = false;
            }

           return result;
        }

        #endregion

        #region UpdateSurgeryTime - Do not modify the signature
        [HttpPut]
        public int UpdateSurgeryTime(Surgery surgery)
        {
            //Implement the logic here
            
            int result = 0;
            try
            {
                result = hospitalRepository.UpdateSurgeryTime(surgery.SurgeryId, surgery.EndTime);
            }
            catch (Exception ex)
            {
                result=0;

            }


            return result;
        }

        #endregion
        [HttpDelete]

        #region RemoveSurgeryDetails - Do not modify the signature

        public JsonResult RemoveSurgeryDetails(DateTime surgeryDate)
        {
            //Implement the logic here

            bool status = false;
            try
            {
                status=hospitalRepository.RemoveSurgeryDetails(surgeryDate);
            }
            catch (Exception ex)
            {
                status = false;
            }
            return Json(status);

        }

        #endregion
    }
}