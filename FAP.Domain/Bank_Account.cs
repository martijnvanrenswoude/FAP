//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FAP.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bank_Account
    {
        public int account_number { get; set; }
        public Nullable<int> employee_id { get; set; }
    
        public virtual ID ID { get; set; }
    }
}
