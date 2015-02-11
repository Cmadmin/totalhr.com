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
    
    public partial class CompanyDocument
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompanyDocument()
        {
            this.CompanyDocumentPermissions = new HashSet<CompanyDocumentPermission>();
            this.CompanyFolderDocuments = new HashSet<CompanyFolderDocument>();
        }
    
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string OriginalFileName { get; set; }
        public System.DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public Nullable<int> LastUpdatedBy { get; set; }
        public Nullable<int> FolderId { get; set; }
        public string FolderDisplayName { get; set; }
        public int FileId { get; set; }
        public string ReadableSize { get; set; }
        public string ReadableType { get; set; }
        public string FileMimeType { get; set; }
        public int NoOfViews { get; set; }
        public int NoOfDownloads { get; set; }
        public Nullable<System.DateTime> LastViewed { get; set; }
        public Nullable<int> LastViewedBy { get; set; }
        public Nullable<System.DateTime> LastDownloaded { get; set; }
        public Nullable<int> LastDownloadedBy { get; set; }
        public Nullable<int> PermissionTypeId { get; set; }
        public bool Archived { get; set; }
        public System.Guid Identifier { get; set; }
    
        public virtual File File { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyDocumentPermission> CompanyDocumentPermissions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyFolderDocument> CompanyFolderDocuments { get; set; }
    }
}
