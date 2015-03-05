//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace totalhr.data.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Notification()
        {
            this.AbsenceReplies = new HashSet<AbsenceReply>();
        }
    
        public int Id { get; set; }
        public string Subject { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string RecipientName { get; set; }
        public string RecipientEmail { get; set; }
        public string Content { get; set; }
        public System.DateTime Created { get; set; }
        public int SenderId { get; set; }
        public Nullable<int> RecipientId { get; set; }
        public int TypeId { get; set; }
        public int statusId { get; set; }
        public Nullable<int> RelatedItemId { get; set; }
        public Nullable<int> RelatedItemTypeId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AbsenceReply> AbsenceReplies { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}