using FAP.Domain;
using System.Collections.Generic;

namespace FAP.Web.Controllers
{
    public interface IPlanningRepository
    {
        List<Planning> GetAll();
        void AddAvailabilty(Planning plan);
        void DeleteAvailabilty(int Id);
        void EditAvailabilty(Planning plan);
        Planning Find(int Id);
    }
}