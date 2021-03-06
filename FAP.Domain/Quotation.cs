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
    
    public partial class Quotation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quotation()
        {
            this.Invoices = new HashSet<Invoice>();
        }
    
        public int id { get; set; }
        public Nullable<int> plan_id { get; set; }
        public Nullable<int> customer_id { get; set; }
        public Nullable<int> employee_id { get; set; }
        public Nullable<int> event_id { get; set; }
        public Nullable<decimal> sum { get; set; }
        public Nullable<System.DateTime> deadline { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Event Event { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual Planning Planning { get; set; }
    }
}
