using FAP.Domain;
using FAP.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var master = new MasterRepository();
            var employeeRepository = master.GetRepository<Employee>();

            var employeeList = employeeRepository.Get();
            var firstEmployee = employeeList.First();
            firstEmployee.name = "Kees";

            employeeRepository.Update(firstEmployee);
        }
    }
}
