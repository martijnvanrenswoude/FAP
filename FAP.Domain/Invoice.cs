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
    
    public partial class Invoice
    {
        public int id { get; set; }
        public Nullable<int> employee_id { get; set; }
        public Nullable<int> quotation_id { get; set; }
        public Nullable<int> payment_status { get; set; }
        public Nullable<decimal> sum { get; set; }
        public Nullable<System.DateTime> deadline { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Payment_status Payment_status1 { get; set; }
        public virtual Quotation Quotation { get; set; }
    }
}