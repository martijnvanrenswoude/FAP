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
    
    public partial class Planning
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Planning()
        {
            this.Quotations = new HashSet<Quotation>();
            this.Inspectors = new HashSet<Inspector>();
        }
    
        public int id { get; set; }
        public Nullable<int> customer_id { get; set; }
        public Nullable<int> event_id { get; set; }
        public Nullable<int> questionnaire_id { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<int> employee_id { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Event Event { get; set; }
        public virtual Questionnaire Questionnaire { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quotation> Quotations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inspector> Inspectors { get; set; }
    }
}
