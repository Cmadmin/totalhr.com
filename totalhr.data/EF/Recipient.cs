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
    
    public partial class Recipient
    {
        public int id { get; set; }
        public int RecipientUserId { get; set; }
        public string RecipientEmail { get; set; }
        public string RecipientName { get; set; }
        public string RecipientPhone { get; set; }
        public int NoNotifications { get; set; }
        public Nullable<System.DateTime> LastNotificationDate { get; set; }
        public int RecipientListId { get; set; }
    }
}
