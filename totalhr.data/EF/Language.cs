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
    
    public partial class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedOn { get; set; }
        public int RelatedGlossaryId { get; set; }
        public string Culture { get; set; }
    }
}
