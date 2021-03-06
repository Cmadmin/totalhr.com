﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TotalHREntities : DbContext
    {
        public TotalHREntities()
            : base("name=TotalHREntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Calendar> Calendars { get; set; }
        public virtual DbSet<CalendarAssociation> CalendarAssociations { get; set; }
        public virtual DbSet<CalendarEvent> CalendarEvents { get; set; }
        public virtual DbSet<CalEventReminderType> CalEventReminderTypes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyDocument> CompanyDocuments { get; set; }
        public virtual DbSet<CompanyDocumentDownload> CompanyDocumentDownloads { get; set; }
        public virtual DbSet<CompanyDocumentPermission> CompanyDocumentPermissions { get; set; }
        public virtual DbSet<CompanyDocumentShare> CompanyDocumentShares { get; set; }
        public virtual DbSet<CompanyDocumentView> CompanyDocumentViews { get; set; }
        public virtual DbSet<CompanyFeature> CompanyFeatures { get; set; }
        public virtual DbSet<CompanyFolder> CompanyFolders { get; set; }
        public virtual DbSet<CompanyFolderDocument> CompanyFolderDocuments { get; set; }
        public virtual DbSet<ContractFormFieldValue> ContractFormFieldValues { get; set; }
        public virtual DbSet<ContractTemplate> ContractTemplates { get; set; }
        public virtual DbSet<ContractTemplateSection> ContractTemplateSections { get; set; }
        public virtual DbSet<CTemplateSectionLink> CTemplateSectionLinks { get; set; }
        public virtual DbSet<CTSectionFieldLink> CTSectionFieldLinks { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<EventToSchedule> EventToSchedules { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<FormControl> FormControls { get; set; }
        public virtual DbSet<FormField> FormFields { get; set; }
        public virtual DbSet<Glossary> Glossaries { get; set; }
        public virtual DbSet<Label> Labels { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Recipient> Recipients { get; set; }
        public virtual DbSet<RecipientList> RecipientLists { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ScheduledNotification> ScheduledNotifications { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserContract> UserContracts { get; set; }
        public virtual DbSet<UserContractData> UserContractDatas { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<UserProfilePicture> UserProfilePictures { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<FormFieldValidationRule> FormFieldValidationRules { get; set; }
        public virtual DbSet<FormFieldJSon> FormFieldJSons { get; set; }
        public virtual DbSet<UserContractFieldData> UserContractFieldDatas { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
        public virtual DbSet<ChatRoom> ChatRooms { get; set; }
        public virtual DbSet<ChatRoomUser> ChatRoomUsers { get; set; }
        public virtual DbSet<Absence> Absences { get; set; }
        public virtual DbSet<AbsenceReply> AbsenceReplies { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<TaskScheduler> TaskSchedulers { get; set; }
        public virtual DbSet<TimeRecording> TimeRecordings { get; set; }
        public virtual DbSet<TimeRecordingType> TimeRecordingTypes { get; set; }
        public virtual DbSet<AbsenceSettingField> AbsenceSettingFields { get; set; }
        public virtual DbSet<UserAbsenceFieldData> UserAbsenceFieldDatas { get; set; }
        public virtual DbSet<GalleryAlbum> GalleryAlbums { get; set; }
        public virtual DbSet<GalleryPhoto> GalleryPhotoes { get; set; }
    
        [DbFunction("TotalHREntities", "SplitCSV")]
        public virtual IQueryable<SplitCSV_Result> SplitCSV(string @string, string delimiter)
        {
            var stringParameter = @string != null ?
                new ObjectParameter("String", @string) :
                new ObjectParameter("String", typeof(string));
    
            var delimiterParameter = delimiter != null ?
                new ObjectParameter("Delimiter", delimiter) :
                new ObjectParameter("Delimiter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<SplitCSV_Result>("[TotalHREntities].[SplitCSV](@String, @Delimiter)", stringParameter, delimiterParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> BuildCalEventReminderRecipientList(Nullable<int> eventid, Nullable<int> companyid, string recipientListName, string description, Nullable<int> createdBy)
        {
            var eventidParameter = eventid.HasValue ?
                new ObjectParameter("eventid", eventid) :
                new ObjectParameter("eventid", typeof(int));
    
            var companyidParameter = companyid.HasValue ?
                new ObjectParameter("companyid", companyid) :
                new ObjectParameter("companyid", typeof(int));
    
            var recipientListNameParameter = recipientListName != null ?
                new ObjectParameter("RecipientListName", recipientListName) :
                new ObjectParameter("RecipientListName", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var createdByParameter = createdBy.HasValue ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("BuildCalEventReminderRecipientList", eventidParameter, companyidParameter, recipientListNameParameter, descriptionParameter, createdByParameter);
        }
    
        public virtual ObjectResult<GetCompanyFoldersByUser_Result> GetCompanyFoldersByUser(Nullable<int> userid, Nullable<int> departmentid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var departmentidParameter = departmentid.HasValue ?
                new ObjectParameter("departmentid", departmentid) :
                new ObjectParameter("departmentid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCompanyFoldersByUser_Result>("GetCompanyFoldersByUser", useridParameter, departmentidParameter);
        }
    
        public virtual ObjectResult<GetUserContractDetails_Result> GetUserContractDetails(Nullable<int> userid, Nullable<int> contractid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var contractidParameter = contractid.HasValue ?
                new ObjectParameter("contractid", contractid) :
                new ObjectParameter("contractid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserContractDetails_Result>("GetUserContractDetails", useridParameter, contractidParameter);
        }
    
        public virtual ObjectResult<GetUserListForAdmin_Result> GetUserListForAdmin(Nullable<bool> showactive, Nullable<int> viewinglanguageid)
        {
            var showactiveParameter = showactive.HasValue ?
                new ObjectParameter("showactive", showactive) :
                new ObjectParameter("showactive", typeof(bool));
    
            var viewinglanguageidParameter = viewinglanguageid.HasValue ?
                new ObjectParameter("viewinglanguageid", viewinglanguageid) :
                new ObjectParameter("viewinglanguageid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserListForAdmin_Result>("GetUserListForAdmin", showactiveParameter, viewinglanguageidParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> GetUserProfileIds(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetUserProfileIds", useridParameter);
        }
    
        public virtual ObjectResult<GetUserProfiles_Result> GetUserProfiles(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserProfiles_Result>("GetUserProfiles", useridParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> GetUserRoleIds(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetUserRoleIds", useridParameter);
        }
    
        public virtual ObjectResult<GetUserRoles_Result> GetUserRoles(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserRoles_Result>("GetUserRoles", useridParameter);
        }
    
        public virtual int PrepareCalendarEventScheduledReminder(string senderName, string senderEmail, Nullable<int> recipientListId)
        {
            var senderNameParameter = senderName != null ?
                new ObjectParameter("SenderName", senderName) :
                new ObjectParameter("SenderName", typeof(string));
    
            var senderEmailParameter = senderEmail != null ?
                new ObjectParameter("SenderEmail", senderEmail) :
                new ObjectParameter("SenderEmail", typeof(string));
    
            var recipientListIdParameter = recipientListId.HasValue ?
                new ObjectParameter("RecipientListId", recipientListId) :
                new ObjectParameter("RecipientListId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PrepareCalendarEventScheduledReminder", senderNameParameter, senderEmailParameter, recipientListIdParameter);
        }
    
        public virtual ObjectResult<SearchUser_Result> SearchUser(Nullable<int> id, string name, Nullable<int> usertypeid, Nullable<int> departmentid, string email, string partialaddress, string town, string county, string postcode, string phone, Nullable<int> viewinglanguageid)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var usertypeidParameter = usertypeid.HasValue ?
                new ObjectParameter("usertypeid", usertypeid) :
                new ObjectParameter("usertypeid", typeof(int));
    
            var departmentidParameter = departmentid.HasValue ?
                new ObjectParameter("departmentid", departmentid) :
                new ObjectParameter("departmentid", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var partialaddressParameter = partialaddress != null ?
                new ObjectParameter("partialaddress", partialaddress) :
                new ObjectParameter("partialaddress", typeof(string));
    
            var townParameter = town != null ?
                new ObjectParameter("town", town) :
                new ObjectParameter("town", typeof(string));
    
            var countyParameter = county != null ?
                new ObjectParameter("county", county) :
                new ObjectParameter("county", typeof(string));
    
            var postcodeParameter = postcode != null ?
                new ObjectParameter("postcode", postcode) :
                new ObjectParameter("postcode", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var viewinglanguageidParameter = viewinglanguageid.HasValue ?
                new ObjectParameter("viewinglanguageid", viewinglanguageid) :
                new ObjectParameter("viewinglanguageid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SearchUser_Result>("SearchUser", idParameter, nameParameter, usertypeidParameter, departmentidParameter, emailParameter, partialaddressParameter, townParameter, countyParameter, postcodeParameter, phoneParameter, viewinglanguageidParameter);
        }
    
        public virtual ObjectResult<SearchUserWithPaging_Result> SearchUserWithPaging(Nullable<int> id, string name, Nullable<int> usertypeid, Nullable<int> departmentid, string email, string partialaddress, string town, string county, string postcode, string phone, Nullable<int> pageSize, Nullable<int> pageNumber, string ordercolumn, string sortorder, Nullable<int> viewinglanguageid)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var usertypeidParameter = usertypeid.HasValue ?
                new ObjectParameter("usertypeid", usertypeid) :
                new ObjectParameter("usertypeid", typeof(int));
    
            var departmentidParameter = departmentid.HasValue ?
                new ObjectParameter("departmentid", departmentid) :
                new ObjectParameter("departmentid", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var partialaddressParameter = partialaddress != null ?
                new ObjectParameter("partialaddress", partialaddress) :
                new ObjectParameter("partialaddress", typeof(string));
    
            var townParameter = town != null ?
                new ObjectParameter("town", town) :
                new ObjectParameter("town", typeof(string));
    
            var countyParameter = county != null ?
                new ObjectParameter("county", county) :
                new ObjectParameter("county", typeof(string));
    
            var postcodeParameter = postcode != null ?
                new ObjectParameter("postcode", postcode) :
                new ObjectParameter("postcode", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var pageNumberParameter = pageNumber.HasValue ?
                new ObjectParameter("PageNumber", pageNumber) :
                new ObjectParameter("PageNumber", typeof(int));
    
            var ordercolumnParameter = ordercolumn != null ?
                new ObjectParameter("ordercolumn", ordercolumn) :
                new ObjectParameter("ordercolumn", typeof(string));
    
            var sortorderParameter = sortorder != null ?
                new ObjectParameter("sortorder", sortorder) :
                new ObjectParameter("sortorder", typeof(string));
    
            var viewinglanguageidParameter = viewinglanguageid.HasValue ?
                new ObjectParameter("viewinglanguageid", viewinglanguageid) :
                new ObjectParameter("viewinglanguageid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SearchUserWithPaging_Result>("SearchUserWithPaging", idParameter, nameParameter, usertypeidParameter, departmentidParameter, emailParameter, partialaddressParameter, townParameter, countyParameter, postcodeParameter, phoneParameter, pageSizeParameter, pageNumberParameter, ordercolumnParameter, sortorderParameter, viewinglanguageidParameter);
        }
    }
}
