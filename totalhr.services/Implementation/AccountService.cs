﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using totalhr.services.Infrastructure;
using totalhr.Shared;
using totalhr.Shared.Models;
using totalhr.data.EF;
using totalhr.data.Repositories.Infrastructure;
using totalhr.data.Repositories.Implementation;
using Ninject;
using totalhr.services.messaging.Infrastructure;
using CM;
using log4net;
using totalhr.data.Models;
using System.Collections;
using totalhr.Resources;

namespace totalhr.services.Implementation
{
    public class AccountService : IAccountService
    {
        private IUserRepository _userRepos;
        private ICompanyRepository _companyRepos;
        private ILanguageRepository _langRepos;
        private IGlossaryService _glossaryService;
        
        private static readonly ILog log = LogManager.GetLogger(typeof(AccountService));
        
        public AccountService(IUserRepository userRepos, ICompanyRepository companyRepos, ILanguageRepository langRepos, IGlossaryService glossaryService)
        {
             _userRepos = userRepos;
            _companyRepos = companyRepos;
            _langRepos = langRepos;
            _glossaryService = glossaryService;
        }

        public Company CreateCompany(NewUserInfo info)
        {
            //Persist Company
            log.Debug("CreateCompany - Company creating");
            Company company = new Company();
            company.Address1 = info.CompanyAddress1;
            company.Address2 = info.CompanyAddress2;
            company.Address3 = info.CompanyAddress3;
            company.AnnualRevenue = info.AnnualRevenue;
            company.City = info.CompanyCity;
            company.CompanyType = info.CompanyType;
            company.CountryId = info.CompanyCountryId;
            company.CreatedBy = -1;
            company.CreatedOn = DateTime.Now;
            company.Description = string.Empty;
            company.DNUSNumber = info.CompanyNumber;
            company.Email = info.CompanyEmail;
            company.Name = info.CompanyName;
            company.NumberOfEmployees = info.CompanyNoEmployees;
            company.Phone1 = info.CompanyPhone1;
            company.Phone2 = info.CompanyPhone2;
            company.PostCode = info.CompanyPostCode;
            //do not save the glossary id for language but the related id from language table.
            company.PreferredLanguageId = _langRepos.GetByLanguageByGlossaryRootId(info.PreferedLanguageId).Id;
            company.StateorCounty = info.CompanyState;
            company.TaxId = info.TaxID;
            company.VATId = info.VATID;
            company.Website = info.Website;

            _companyRepos.Add(company);
            _companyRepos.Save();
            log.Debug("CreateCompany - Company created");

            if (company.ID > 0)//create default department
            {
                _companyRepos.CreateDepartment(company.ID, -1, "HR", "");
            }

            return company;
        }

        public User CreateUser(NewEmployeeInfo info)
        {
            log.Debug("Create User - User creating");

            var result = IsInfoValidForRegistration(info);
            if (result != null)
                return null;

            User user = new User();
            user.Address1 = info.Address1;
            user.Address2 = info.Address2;
            user.Address3 = info.Address3;
            user.CompanyId = info.CompanyId;
            user.countryId = info.CountryId;
            user.createdby = -1;
            user.created = DateTime.Now;
            user.email = info.Email;
            user.firstname = info.FirstName;
            user.surname = info.Surname;
            user.GenderId = info.GenderId;
            user.Mobile = info.MobilePhone;
            user.othernames = info.MiddleNames;
            user.othertitle = info.OtherTitle;
            user.password = CM.Security.Encrypt(info.Password);
            user.Phone = info.PersonalPhone;
            user.Mobile = info.MobilePhone;
            user.PostCode = info.PostCode;
            user.preferedlanguageid = info.PreferedLanguageId;
            user.stateorcounty = info.State;
            user.tersmaccepted = info.TermsAccepted;
            user.title = info.Title;
            user.Town = info.City;
            user.typeid = (info.UserTypeId > 0)? info.UserTypeId.GetValueOrDefault() : 1; //add glossary user type
            user.userguid = Guid.NewGuid();
            user.activationcode = CM.utils.random_code(20);
            user.username = info.UserName;
            user.departmentid = info.DepartmentId;
            _userRepos.Add(user);
            _userRepos.Save();

            log.Debug("Create user - user created");
            return user;
        }

        public UserRegStruct CreateEmployee(NewEmployeeInfo info, AdminStruct adminstruct)
        {
            var result = IsInfoValidForRegistration(info);
            if (result != null)
                return result;

            User user = CreateUser(info);

            if (user != null && user.id > 0)
            {
                log.Debug("CreateEmployee - user created");
                string activationlink = adminstruct.SiteRootURL + "Account/Activate/" + user.userguid;
                return new UserRegStruct
                {
                    UserId = user.id,
                    CompanyId = user.CompanyId,
                    Email = info.Email,
                    Name = info.FirstName,
                    Surname = info.Surname,
                    ActivationLink = activationlink
                };
            }
            return new UserRegStruct
                {
                    UserId = -1,
                    CompanyId = -1,
                    RegError = Error.Error_Could_Not_Register_Employee
                };
        }

        public string GenerateUserActivationLink(string email)
        {            
            return CM.Security.Encrypt(email);
        }
        
        public bool UserExistByEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;

            User user = GetUserByEmail(email);
            return (user != null) ;
        }

        public User GetUserByEmail(string email)
        {
            return _userRepos.FindBy(x => x.email.ToLower().Trim().Equals(email.ToLower().Trim())).FirstOrDefault();
        }

        public UserRegStruct IsInfoValidForRegistration(NewEmployeeInfo info)
        {
            UserRegStruct userstruct = new UserRegStruct();

            //validate user email.
            if (UserExistByEmail(info.Email))
            {
                log.Debug("RegisterUserCompany - " + Resources.FormMessages.Error_User_Email_Exist);

                userstruct.UserId = -1; userstruct.CompanyId = -1;
                userstruct.RegError = Resources.FormMessages.Error_User_Email_Exist;
                return userstruct;
            }

            //check if user name already exists
            if (GetUserByUsername(info.UserName) != null)
            {
                log.Debug("RegisterUserCompany - " + Resources.FormMessages.Error_User_Name_Exist);

                userstruct.UserId = -1; userstruct.CompanyId = -1;
                userstruct.RegError = Resources.FormMessages.Error_User_Name_Exist;
                return userstruct;
            }

            return null;
        }

        public UserRegStruct RegisterUserCompany(NewUserInfo info, AdminStruct adminstruct)
        {
            var result = IsInfoValidForRegistration(info);
            if (result != null)
                return result;

            //*** create the default department which is HR and set user to that also create default calendar.
            //*** give user some default roles and profiles when they are activated. (this is not nec)

            Company company = CreateCompany(info);

            if (company.ID > 0)
            {
                log.Debug("RegisterUserCompany - company created");

                info.CompanyId = company.ID;
                User user = CreateUser(info);

                if (user.id > 0)
                {                   
                    log.Debug("RegisterUserCompany - user created");
                    string activationlink = adminstruct.SiteRootURL + "Account/Activate/" + user.userguid;
                    return new UserRegStruct { 
                        UserId = user.id, CompanyId = company.ID, Email = info.Email, Name = info.FirstName, Surname = info.Surname,
                        ActivationLink = activationlink 
                    };
                }
            }

            return null;
           
        }

        public void ClearUserDataByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return;

            List<User> users = _userRepos.FindBy(x => x.email.Trim().ToLower().Equals(email.Trim().ToLower())).ToList();
            if (users != null && users.Count > 0)
            {
                foreach (User user in users)
                {
                    _userRepos.Delete(user);
                }
                _userRepos.Save();
            }
        }

        public User GetUser(string UserName, string Password)
        {
            string EncryptedPassword = CM.Security.Encrypt(Password);

            return _userRepos.FindBy(x => (x.username.Trim().ToLower() == UserName.Trim().ToLower()
                || x.email.Trim().ToLower() == UserName.Trim().ToLower()) &&
                EncryptedPassword == x.password).FirstOrDefault();
        }

        public User GetUser(int userId)
        {
            return _userRepos.FindBy(x => x.id == userId).FirstOrDefault();
        }

        public UserDetailsStruct GetUserDetailsForLogin(string UserName, string Password)
        {
            User user = this.GetActiveUser(UserName, Password);
            if (user == null)
                return null;

            user.lastvisit = DateTime.Now;
            user.novisits++;
            _userRepos.Save();

            if (user == null)
                return null;
            
            UserDetailsStruct userstruct = new UserDetailsStruct { 
                UserBasicDetails =  user,
                UserProfiles = _userRepos.GetUserProfiles(user.id),
                UserRoles = _userRepos.GetUserRoles(user.id)
            };


            return userstruct;
        }

        public User GetActiveUser(string UserName, string Password)
        {
            string EncryptedPassword = CM.Security.Encrypt(Password);

            return _userRepos.FindBy(x => (x.username.Trim().ToLower() == UserName.Trim().ToLower()
                || x.email.Trim().ToLower() == UserName.Trim().ToLower()) &&
                EncryptedPassword == x.password &&
                x.active).FirstOrDefault();
        }

        public User GetUserByUsername(string username)
        {
            return _userRepos.FindBy(x => (x.username.Trim().ToLower() == username.Trim().ToLower())).FirstOrDefault();
        }

        public User GetUserByGuid(string guid)
        {
            return _userRepos.FindBy(x => x.userguid == new System.Guid(guid)).FirstOrDefault();
        }

        public User ActivateUser(string guid)
        {
            User user = GetUserByGuid(guid);

            if (user != null)
            {
                user.active = true;

                _userRepos.Save();
            }

            return user;            
        }

        public List<User> GetCompanyUsers(int companyid)
        {
            return _userRepos.GetCompanyUsers(companyid);
        }

        public IEnumerable<SimpleUser> GetCompanyUsersSimple(int companyid, int exudedUserId)
        {
            return _userRepos.GetCompanyUsers(companyid, exudedUserId);
        }

        public List<Department> GetCompanyDepartments(int companyid)
        {
            return _companyRepos.GetCompanyDepartments(companyid);
        }

        public UserPersonalInfo GetUserInfoByEmail(string email)
        {
            User user = GetUserByEmail(email);
            return GetUserPersonalInfo(user);
        }

        public UserPersonalInfo GetUserInfoByGuid(string guid)
        {
            User user =  GetUserByGuid(guid);
            return GetUserPersonalInfo(user);
        }

        public UserPersonalInfo GetUserPersonalInfo(User user){
            var profilePicture = _userRepos.GetProfilePicturePath(user.id); 

            return new UserPersonalInfo(){
                Address1 = user.Address1,
                Address2 = user.Address2,
                Address3 = user.Address3,
                City = user.Town,
                CompanyId = user.CompanyId,
                CountryId = user.countryId,
                Email = user.email,
                FirstName = user.firstname,
                GenderId = user.GenderId,
                MiddleNames = user.othernames,
                MobilePhone = user.Mobile,
                OtherTitle = user.othertitle,
                Password = CM.Security.Decrypt(user.password),
                PersonalPhone = user.Phone,
                PostCode = user.PostCode,
                PreferedLanguageId = user.preferedlanguageid,
                State = user.stateorcounty,
                Surname = user.surname,
                Title = user.title,
                UserId = user.id,
                UserTypeId = user.typeid,
                UserName = user.username,
                ProfilePictureAdded = !string.IsNullOrEmpty(profilePicture),
                ProfilePicturePath = string.IsNullOrEmpty(profilePicture) ? "" : profilePicture,
                TitleGlossary = _glossaryService.GetSpecificGlossaryTerm(user.preferedlanguageid, user.title, Variables.GlossaryGroups.Title),
                GenderGlossary = _glossaryService.GetSpecificGlossaryTerm(user.preferedlanguageid, user.GenderId, Variables.GlossaryGroups.Gender)
           
            };
            
        }

        public int UpdateUserDetails(UserPersonalInfo info)
        {
            User user = _userRepos.FindBy(x => x.id == info.UserId).FirstOrDefault();

            if (user == null)
            {
                return -1;//user details not found
            }

            user.Address1 = info.Address1;
            user.Address2= info.Address2 ;
            user.Address3= info.Address3  ;
            user.Town= info.City;
            user.CompanyId= info.CompanyId  ;
            user.countryId =info.CountryId  ;
            user.email = info.Email ;
            user.firstname = info.FirstName ;
            user.GenderId= info.GenderId;
            user.othernames= info.MiddleNames;
            user.Mobile = info.MobilePhone;
            user.othertitle =info.OtherTitle;
            user.password= CM.Security.Encrypt(info.Password);
            user.Phone= info.PersonalPhone;
            user.PostCode= info.PostCode;
            user.preferedlanguageid =info.PreferedLanguageId;
            user.stateorcounty= info.State;
            user.surname= info.Surname;
            user.title = info.Title;
            user.id =info.UserId;
            user.username= info.UserName;

            _userRepos.Save();

            return 1;
        }

        public List<string> GetUserNamesByIds(List<int> ids)
        {
            return _userRepos.GetUserNamesByIds(ids);
        }

        public IEnumerable<ListItemStruct> GetUserProfile(int userId)
        {
            return _userRepos.GetUserProfile(userId);
        }

        public IEnumerable<ListItemStruct> GetUserProfileByGuid(Guid uniqueid)
        {
            return _userRepos.GetUserProfileByGuid(uniqueid);
        }

        public void UpdateUserProfiles(int hdnUserId, string hdnSelectedProfileIds, int updatedByUserId)
        {
            _userRepos.UpdateUserProfiles(hdnUserId, hdnSelectedProfileIds, updatedByUserId);
        }

        public IEnumerable<ListItemStruct> GetUserRoles(int userId)
        {
            return _userRepos.GetUserRole(userId);
        }

        public IEnumerable<ListItemStruct> GetUserRoleByGuid(Guid uniqueid)
        {
            return _userRepos.GetUserRoleByGuid(uniqueid);
        }

        public void UpdateUserRoles(int hdnUserId, string hdnSelectedRolesIds, int updatedByUserId)
        {
            _userRepos.UpdateUserRoles(hdnUserId, hdnSelectedRolesIds, updatedByUserId);
        }

        public IEnumerable<User> ListCompanyUsers(int companyId)
        {
            return _userRepos.FindBy(x => x.CompanyId == companyId);
        }

        public IEnumerable<ListItemStruct> ListCompanyUsersSimple(int companyId)
        {
            return _userRepos.FindBy(x => x.CompanyId == companyId).
                Select(x => new ListItemStruct {Id = x.id, Name = x.firstname + " " + x.surname  });
        }

        public UserAdminStruct GetUserDetailsForAdmin(string uniqueid)
        {
            User user = GetUserByGuid(uniqueid);

            return new UserAdminStruct
            {
                PersonalInfo = GetUserPersonalInfo(user),
                UserProfiles = GetUserProfile(user.id),
                UserRoles = GetUserRoles(user.id)
            };
        }

        public IEnumerable<GetUserListForAdmin_Result> GetUserListForAdmin(bool? bShowActive, int languageId)
        {
            return _userRepos.GetUserListForAdmin(bShowActive, languageId);
        }

        public IEnumerable<GetUserListForAdmin_Result> SearchUsers(UserSearchInfo searchInfo)
        {
            return _userRepos.SearchUser(searchInfo);
        }

        public IEnumerable<SearchUserWithPaging_Result> SearchUserWithPaging(UserSearchInfo searchInfo)
        {
            return _userRepos.SearchUserWithPaging(searchInfo);
        }

        public bool SaveProfilePicture(UserProfilePicture profilePicture)
        {
            return _userRepos.SaveProfilePicture(profilePicture);
        }
    }
}
