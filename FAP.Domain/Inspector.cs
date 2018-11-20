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
    
    public partial class Inspector
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inspector()
        {
            this.Answers = new HashSet<Answer>();
            this.ComboQuestions = new HashSet<ComboQuestion>();
            this.MultipleChoices = new HashSet<MultipleChoice>();
            this.OpenSubjectQuestions = new HashSet<OpenSubjectQuestion>();
            this.Plannings = new HashSet<Planning>();
        }
    
        public int Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public Nullable<int> telephone_nr { get; set; }
        public string postcode { get; set; }
        public string house_number { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComboQuestion> ComboQuestions { get; set; }
        public virtual Inspector_shedule Inspector_shedule { get; set; }
        public virtual Inspector_Bank_Account Inspector_Bank_Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MultipleChoice> MultipleChoices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OpenSubjectQuestion> OpenSubjectQuestions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Planning> Plannings { get; set; }
    }
}
