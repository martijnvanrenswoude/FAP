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
    
    public partial class ID
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ID()
        {
            this.Bank_Account = new HashSet<Bank_Account>();
        }
    
        public int Id1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bank_Account> Bank_Account { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Inlogdata Inlogdata { get; set; }
        public virtual Inspector Inspector { get; set; }
    }
}
