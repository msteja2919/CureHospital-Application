using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data;
using CureHospitalDALCrossPlatform.Models;

namespace CureHospitalDALCrossPlatForm
{
    public class HospitalRepository
    {
        #region Uncomment the below line

        CureWellDBContext context;

        #endregion

        #region Constructor - Do not modify the signature

        public HospitalRepository(CureWellDBContext context)
        {
            //To Do: Implement appropriate logic
            this.context = context; 

        }

        #endregion

        #region FetchDoctorIDs - Do not modify the signature

        public List<int> FetchDoctorIDs(string specializationCode)
        {
            //To Do: Implement appropriate logic and change the return statement as per your logic

            List<int> doctorId = new List<int>();
            try
            {
                doctorId = (from v in context.DoctorSpecializations where v.SpecializationCode.Equals(specializationCode) select v.DoctorId).ToList();
            }
            catch (Exception)
            {
                doctorId = null;
            }
            return doctorId;
        }

        #endregion

        #region AddDoctorSpecialization - Do not modify the signature

        public bool AddDoctorSpecialization(int doctorId, string specializationCode, DateTime specializationDate)
        {
            //To Do: Implement appropriate logic and change the return statement as per your logic

            bool retval = false;
            try
            {
                DoctorSpecialization dsObj = new DoctorSpecialization();
                dsObj.DoctorId = doctorId;
                dsObj.SpecializationCode = specializationCode;
                dsObj.SpecializationDate = specializationDate;

                context.DoctorSpecializations.Add(dsObj);
                context.SaveChanges();
                retval = true;
            }
            catch (Exception)            
            {
                retval = false;
            }
            return retval;
        }

        #endregion

        #region UpdateSurgeryTime - Do not modify the signature

        public int UpdateSurgeryTime(int surgeryID, decimal newEndTime)
        {
            //To Do: Implement appropriate logic and change the return statement as per your logic
            int retval = 0;
            try
            {
                var surgeryObj = context.Surgeries.Find(surgeryID);
                if (newEndTime > surgeryObj.StartTime)
                {
                    surgeryObj.EndTime = newEndTime;
                    context.SaveChanges();
                    retval = 1;
                }
            }
            catch (Exception)
            {
                retval = 0;
            }
            return retval;
        }

        #endregion

        #region RemoveSurgeryDetails - Do not modify the signature

        public bool RemoveSurgeryDetails(DateTime surgeryDate)
        {

            bool retVal=false;

            try
            {
                var surgeryObjList = context.Surgeries.Where(x => x.SurgeryDate == surgeryDate).ToList<Surgery>();

                if (surgeryObjList.Count > 0)
                {
                    foreach (Surgery obj in surgeryObjList)
                    {
                        context.Surgeries.Remove(obj);
                        context.SaveChanges();
                    }
                    retVal = true;
                }
                
            }
            catch (Exception)
            {

                retVal = false;
            }

            return retVal;
        }

        #endregion
    }
}







