using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAP.Desktop.Message;
using FAP.Desktop.View;
using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace FAP.Desktop.ViewModel
{
    public class PlanningCreateViewModel
        :   ViewModelBase,
            ITransitionable
    {
        private readonly GenericRepository<Planning> planningRepository;

        public PlanningCreateViewModel( GenericRepository<Planning> planningRepository,
                                        GenericRepository<Employee> employeeRepository)
        {
            this.planningRepository = planningRepository;

            //Messenger.Default.Register<ModelMessage<Planning>>(this, (message) =>
            //{
            //    if (message.FromWho == nameof(PlanningBeheerViewModel))
            //    {
            //    }
            //});
        }
        
        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Hide()
        {
            throw new NotImplementedException();
        }
    }
}
