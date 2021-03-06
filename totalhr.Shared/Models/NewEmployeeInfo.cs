﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using totalhr.Resources;
using System.ComponentModel.DataAnnotations;
using totalhr.Shared.Models.Attributes;
using System.Web;

namespace totalhr.Shared.Models
{
    public class NewEmployeeInfo
    {
        
        #region personaldetails

        [Required(ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Gender_Rq")]
        public int GenderId { get; set; }

        [Required(ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Title_Rq")]
        public int Title { get; set; }

        [MaxLength(30, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_OtherTitle_Too_long")]
        public string OtherTitle { get; set; }

        [Required(ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Firstname_Rq")]
        [MaxLength(50, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_FirstName_Too_long")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Surname_Rq")]
        [MaxLength(50, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_SurName_Too_long")]
        public string Surname { get; set; }

        [MaxLength(50, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_OtherName_Too_long")]
        public string MiddleNames { get; set; }

        [Required(ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Email_Reminder")]
        [EmailAddress(ErrorMessage = null, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Invalid_Email")]
        [MaxLength(100, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Email_Too_long")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Addres1_Rq")]
        [MaxLength(255, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Address1_Too_Long")]
        public string Address1 { get; set; }

        [MaxLength(255, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Address2_Too_Long")]
        public string Address2 { get; set; }

        [MaxLength(255, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Address3_Too_Long")]
        public string Address3 { get; set; }

        [Required(ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_City_Rq")]
        [MaxLength(50, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_City_Too_Long")]
        public string City { get; set; }

        [MaxLength(50, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_State_Too_Long")]
        public string State { get; set; }

        [MaxLength(30, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Postcode_Too_Long")]
        public string PostCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Country_Required")]
        public int CountryId { get; set; }

        [Required(ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Phone1_Rq")]
        [MaxLength(30, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_PersonalPhone_Too_Long")]
        public string PersonalPhone { get; set; }

        [MaxLength(30, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_MobilePhone_Too_Long")]
        public string MobilePhone { get; set; }

        [AlwaysTrue(ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Terms_Not_Accepted_Rq")]
        public bool TermsAccepted { get; set; }

        [Required(ErrorMessageResourceType = typeof(Error), ErrorMessageResourceName = "Error_Picture_File_Required")]
        public HttpPostedFileBase PictureFile { get; set; }

        public int CreatedBy { get; set; }

        #endregion


        #region logondetails

        public bool UseEmailAsUserName { get; set; }

        [MaxLength(100, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_UserName_Too_long")]
        [Required(ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Username_Rq")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Password_Rq")]
        [StringLength(15, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Password_NotInRange", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Password_Conf_Rq")]
        [Compare("Password", ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_Password_Not_Matched")]
        // [MaxLength(15, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_PasswordConfirm_Too_long")]
        [StringLength(15, ErrorMessageResourceType = typeof(FormMessages), ErrorMessageResourceName = "Error_PasswordConfirm_NotInRange", MinimumLength = 6)]
        public string PasswordConfirm { get; set; }

        public int PreferedLanguageId { get; set; }

        #endregion

        public int CompanyId { get; set; }

        public int UserId { get; set; }

        public int DepartmentId { get; set; }

        public IEnumerable<ListItemStruct> DepartmentList { get; set; }

        public IEnumerable<ListItemStruct> LanguageList { get; set; }

        public int? UserTypeId { get; set; }
    }
}
