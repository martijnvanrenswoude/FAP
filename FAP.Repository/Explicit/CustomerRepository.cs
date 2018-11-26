using FAP.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAP.Domain;

namespace FAP.Repository.Explicit
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(FAPDatabaseEntities context) : base(context)
        {

        }

        // ==============================================================================================================================
        // <<< BELANGRIJK >>> Voor elke 'custom' repository die je maakt moet je de implicit cast operator overloaden! <<< BELANGRIJK >>>
        // Dingen die je moet veranderen indien je dit stuk code copyt zijn hieronder weergegeven.
        // 
        // Bij #1#: Verander deze naam naar de naam van jou repository klasse.
        // Bij #2#: Verander het generic parameter naar de model die de repository gebruikt.
        // Bij #3#: Verander het type die gereturnet wordt naar de naam van jou repository klasse.
        //
        // public static implicit operator #1#(GenericRepository<#2#> v)
        // {
        //     return new #3#(v.Context);
        // }
        //
        // ==============================================================================================================================
        public static implicit operator CustomerRepository(GenericRepository<Employee> v)
        {
            return new CustomerRepository(v.Context);
        }

        public void SpecialCustomerRelatedAction()
        {
            Console.WriteLine("Very wow");
        }

    }
}
