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
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.CompanyDocuments = new HashSet<CompanyDocument>();
            this.CompanyDocumentPermissions = new HashSet<CompanyDocumentPermission>();
            this.CompanyFolders = new HashSet<CompanyFolder>();
            this.ContractTemplates = new HashSet<ContractTemplate>();
            this.CTSectionFieldLinks = new HashSet<CTSectionFieldLink>();
            this.Profiles = new HashSet<Profile>();
            this.Profiles1 = new HashSet<Profile>();
            this.Roles = new HashSet<Role>();
            this.Roles1 = new HashSet<Role>();
            this.UserContracts = new HashSet<UserContract>();
            this.UserContracts1 = new HashSet<UserContract>();
            this.UserContracts2 = new HashSet<UserContract>();
            this.UserContractDatas = new HashSet<UserContractData>();
            this.UserContractDatas1 = new HashSet<UserContractData>();
            this.UserContractDatas2 = new HashSet<UserContractData>();
            this.UserProfiles = new HashSet<UserProfile>();
            this.UserProfilePictures = new HashSet<UserProfilePicture>();
            this.UserProfilePictures1 = new HashSet<UserProfilePicture>();
            this.UserProfilePictures2 = new HashSet<UserProfilePicture>();
            this.UserRoles = new HashSet<UserRole>();
            this.FormFieldValidationRules = new HashSet<FormFieldValidationRule>();
            this.Departments = new HashSet<Department>();
            this.ChatRooms = new HashSet<ChatRoom>();
            this.ChatRoomUsers = new HashSet<ChatRoomUser>();
            this.ChatRoomUsers1 = new HashSet<ChatRoomUser>();
        }
    
        public int id { get; set; }
        public int GenderId { get; set; }
        public string firstname { get; set; }
        public string othernames { get; set; }
        public string surname { get; set; }
        public int title { get; set; }
        public string othertitle { get; set; }
        public string username { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Town { get; set; }
        public string stateorcounty { get; set; }
        public string PostCode { get; set; }
        public int countryId { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public int CompanyId { get; set; }
        public System.DateTime created { get; set; }
        public int createdby { get; set; }
        public Nullable<System.DateTime> lastvisit { get; set; }
        public int novisits { get; set; }
        public bool active { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Nullable<int> lastupdatedby { get; set; }
        public Nullable<System.DateTime> lastupdated { get; set; }
        public int typeid { get; set; }
        public System.Guid userguid { get; set; }
        public int preferedlanguageid { get; set; }
        public bool tersmaccepted { get; set; }
        public string activationcode { get; set; }
        public string chosenculture { get; set; }
        public int departmentid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyDocument> CompanyDocuments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyDocumentPermission> CompanyDocumentPermissions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyFolder> CompanyFolders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractTemplate> ContractTemplates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTSectionFieldLink> CTSectionFieldLinks { get; set; }
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Profile> Profiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Profile> Profiles1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> Roles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> Roles1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserContract> UserContracts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserContract> UserContracts1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserContract> UserContracts2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserContractData> UserContractDatas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserContractData> UserContractDatas1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserContractData> UserContractDatas2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserProfilePicture> UserProfilePictures { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserProfilePicture> UserProfilePictures1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserProfilePicture> UserProfilePictures2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormFieldValidationRule> FormFieldValidationRules { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Department> Departments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatRoom> ChatRooms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatRoomUser> ChatRoomUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatRoomUser> ChatRoomUsers1 { get; set; }
    }
}
