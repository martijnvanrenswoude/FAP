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
    
    public partial class MultipleChoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MultipleChoice()
        {
            this.MultiplechoiceAnswers = new HashSet<MultiplechoiceAnswer>();
        }
    
        public int Id { get; set; }
        public Nullable<int> questionnaire_id { get; set; }
        public string answer { get; set; }
        public Nullable<int> inspector_id { get; set; }
        public string question { get; set; }
        public int AmountOfAnswers { get; set; }
    
        public virtual Inspector Inspector { get; set; }
        public virtual Questionnaire Questionnaire { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MultiplechoiceAnswer> MultiplechoiceAnswers { get; set; }
    }
}
