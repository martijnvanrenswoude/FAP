using FAP.Domain;
using FAP.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAP.Web.Repository
{
    public class PlanningDummyRepository : IPlanningRepository
    {
        public void AddAvailabilty(Planning plan)
        {
            throw new NotImplementedException();
        }

        public void DeleteAvailabilty(int Id)
        {
            throw new NotImplementedException();
        }

        public void EditAvailabilty(Planning plan)
        {
            throw new NotImplementedException();
        }

        public Planning Find(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Planning> GetAll()
        {
            List<Planning> DummyPlanningList = new List<Planning>();

            Planning plan1 = new Planning
            {
                id = 0,
                customer_id = 1,
                event_id = 1,
                questionnaire_id = 1,
                start_date = new DateTime(2018,12,22),
                employee_id = 1
            };

            Planning plan2 = new Planning
            {
                id = 0,
                customer_id = 1,
                event_id = 1,
                questionnaire_id = 1,
                start_date = new DateTime(2018, 12, 22),
                employee_id = 1
            };

            Planning plan3 = new Planning
            {
                id = 0,
                customer_id = 1,
                event_id = 1,
                questionnaire_id = 1,
                start_date = new DateTime(2018, 12, 22),
                employee_id = 1
            };

            DummyPlanningList.Add(plan1);
            DummyPlanningList.Add(plan2);
            DummyPlanningList.Add(plan3);

            return DummyPlanningList;
        }
    }
}