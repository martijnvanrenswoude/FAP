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
    
    public partial class Inspector_shedule
    {
        public int inspector_id { get; set; }
        public System.DateTime date { get; set; }
        public Nullable<System.DateTime> available_from { get; set; }
        public Nullable<System.DateTime> available_until { get; set; }
    
        public virtual Inspector Inspector { get; set; }
    }
}
