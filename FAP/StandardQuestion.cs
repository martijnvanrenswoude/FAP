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
    
    public partial class StandardQuestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StandardQuestion()
        {
<<<<<<< HEAD:FAP/StandardQuestion.cs
            this.StandardQuestionsList = new HashSet<StandardQuestionsList>();
=======
            this.StandardQuestionsLists = new HashSet<StandardQuestionsList>();
>>>>>>> Martijn:FAP/FAP/StandardQuestion.cs
        }
    
        public int Id { get; set; }
        public string question { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
<<<<<<< HEAD:FAP/StandardQuestion.cs
        public virtual ICollection<StandardQuestionsList> StandardQuestionsList { get; set; }
=======
        public virtual ICollection<StandardQuestionsList> StandardQuestionsLists { get; set; }
>>>>>>> Martijn:FAP/FAP/StandardQuestion.cs
    }
}
