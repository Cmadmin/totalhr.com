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
    
    public partial class FormFieldValidationRule
    {
        public int FormFieldId { get; set; }
        public int ValidationRuleId { get; set; }
        public System.DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public string ErrorMessage { get; set; }
        public string SetValue { get; set; }
        public int FormId { get; set; }
    
        public virtual User User { get; set; }
        public virtual FormFieldJSon FormFieldJSon { get; set; }
    }
}
