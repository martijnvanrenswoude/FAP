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
    
    public partial class OpenSubjectQuestion
    {
        public int Id { get; set; }
        public int inspector_id { get; set; }
        public string subject { get; set; }
        public string answer { get; set; }
        public Nullable<int> questionnaire_id { get; set; }
    
        public virtual Inspector Inspector { get; set; }
        public virtual Questionnaire Questionnaire { get; set; }
    }
}
