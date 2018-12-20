using FAP.Domain;
using System;
using System.Collections.Generic;

namespace FAP.Web.Controllers
{
    public interface IAvailabilityRepository
    {
        List<Inspector_shedule> GetAll();
        void AddAvailabilty(Inspector_shedule date);
        void DeleteAvailabilty(Inspector_shedule date);
        Inspector_shedule Find(DateTime date);
    }
}