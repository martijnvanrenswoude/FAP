//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FAP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Question
    {
        public int Id { get; set; }
        public int questionnaire_id { get; set; }
        public string question1 { get; set; }
        public string answer { get; set; }
    
        public virtual Questionnaire Questionnaire { get; set; }
    }
}
