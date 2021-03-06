﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calendar.Infrastructure;
using Calendar.Models;
using System.Globalization;
using log4net;
using totalhr.services.messaging.Infrastructure;
using TEF = totalhr.data.EF;
using Authentication.Infrastructure;
using totalhr.data.Repositories.Infrastructure;
using totalhr.data.EF;
using Authentication.Models;
using totalhr.Shared.Models;
using totalhr.Shared;
using Res = totalhr.Resources;
using totalhr.services.Infrastructure;
using System.Text;

namespace totalhr.web.Controllers
{
    /*
     * Calendar should be based on culture of registered user  
     * and registered user should only select language supported by company
     * Multiple language support is a feature to be purchased.
     * 
     * */

   
    public class CalendarController : BaseController
    {
        readonly ICalendarDisplayService _calService;
        readonly ICalendarManagementService _calMservice;
        private IOAuthService _authService;
        private readonly IMessagingService _messagingService;

        private static readonly ILog Log = LogManager.GetLogger(typeof(AccountController));

        public CalendarController(ICalendarDisplayService cservice, ICalendarManagementService calmservice, IMessagingService messageService, IOAuthService authservice)
            : base(authservice)
        {
            _calService = cservice;
            _calMservice = calmservice;
            _messagingService = messageService;  
            _authService = authservice;
        }

        private string MakeClientJSForWeekDays()
        {
            var sbtemp = new StringBuilder();            
            string[] weekdays = _calService.GetWeekDaysByName(CultureInfo.CreateSpecificCulture(CurrentUser.Culture));
            int len = weekdays.Length;

            sbtemp.Append(" var d = new Date();" + Environment.NewLine + " var weekday = new Array(7);" + Environment.NewLine);

            for (int i = 0; i < len; i++)
            {
                sbtemp.Append(string.Format(@"weekday[{0}]=  ""{1}"";" + Environment.NewLine,
                    i, HttpUtility.JavaScriptStringEncode(weekdays[i])));
            }
            return sbtemp.ToString();
        }
       
        public ActionResult Index()
        {
            var allCalendars = _calMservice.GetCompanyCalendars(CurrentUser.CompanyId);
            return View(allCalendars);
        }
        
        public ActionResult GenerateDefault(int id)
        {
            //always put calendarid to get correct calendar.
            return MonthView(DateTime.Now.Year, DateTime.Now.Month, id);
        }

        public ActionResult PreviewEvent(int id)
        {
            CalendarEvent cevent = _calMservice.GetEvent(id);
            return View(cevent);
        }

        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            ViewBag.WeekDaysJS = MakeClientJSForWeekDays();
            CalendarEventInfo info = _calMservice.GetEventInfo(id);
            info.UserCulture = CurrentUser.Culture; 
            return View("EventEdit", "~/Views/Shared/_PopupLayout.cshtml",info);
        }

        [ProfileCheck(Variables.Profiles.CalendarCreateEvent)]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditEvent(CalendarEventInfo eventinfo)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.WeekDaysJS = MakeClientJSForWeekDays();
                eventinfo.UserCulture = CurrentUser.Culture;
                return View("EventEdit", "~/Views/Shared/_PopupLayout.cshtml", eventinfo);
            }

            eventinfo.LastModifiedBy = CurrentUser.UserId;
            _calMservice.SaveEvent(eventinfo);

            return View("EventEdit", "~/Views/Shared/_PopupLayout.cshtml", eventinfo);
        }
       
        [ProfileCheck(Variables.Profiles.CalendarCreateEvent)]
        [HttpGet]
        public ActionResult CreateEvent(int calendarid, int year, int month, int day)
         {
             var calendar = _calMservice.GetCalendar(calendarid);
             
            if (calendar == null)
            {
                return RedirectToAction("AccessDenied", "Error", new { ModelError = "Calendar not registered." });
            }
            else
            {
                ViewBag.WeekDaysJS = MakeClientJSForWeekDays();
                CalendarEventInfo model = new CalendarEventInfo {CalendarId = calendar.id, CalendarName = calendar.Name, UserCulture = CurrentUser.Culture };
                
                try
                {
                    model.EndDate = model.StartDate = new DateTime(year, month, day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);                    
                }
                catch { }

                return View("EventAdd", "~/Views/Shared/_PopupLayout.cshtml", model);
            }
         }


        [ProfileCheck(Variables.Profiles.CalendarCreateEvent)]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateEvent(CalendarEventInfo eventinfo)
        {
            if (!ModelState.IsValid)
            {
                return View("EventAdd", eventinfo);
            }

            eventinfo.CreatedBy = CurrentUser.UserId;
            eventinfo.CompanyId = CurrentUser.CompanyId;
          
            var cevent = _calMservice.CreateEvent(eventinfo);
            _messagingService.NotifyUserOfCalendarEvent(WebsiteKernel, eventinfo);
           
            if (cevent.id > 0)
            {
                return View("PreviewEvent", cevent);
            }
            else
            {
                return RedirectToAction("CreateEvent", "Calendar", new {id = eventinfo.CalendarId });
            }
            
        }

        public ActionResult GetCalendarYear(int year, int calendarid)
        {

            var calendar = _calMservice.GetCalendar(calendarid);

            if (calendar != null)
            {
                ViewBag.CalendarName = calendar.Name;
                ViewBag.CalendarId = calendar.id;
            }

            var calEvents = calendarid == 0 ? _calMservice.GetUserCalendarEvents(CurrentUser.UserId, year, 0) :
               _calMservice.GetUserCalendarEvents(CurrentUser.UserId, year, 0, calendarid);

            var rqStruct = new CalendarRequestStruct
            {
                Info = CultureInfo.CreateSpecificCulture(CurrentUser.Culture),
                TableTemplate = @" border=""1"" class=""calendar"" ",
                Year = year,
                RelatedEvents = calEvents,
                CalendarId = calendarid,
                UserCanCreateEvent = CurrentUser.HasProfile((int)Variables.Profiles.CalendarCreateEvent),
                UserId = CurrentUser.UserId,
                ClientConfig = new ClientScriptConfig
                {
                    PageClientId = 1,
                    ActiveTdClickCallBack = @" onclick=""ManageActiveDay(this);"" ",
                    EventClickCallBack = @" onclick=""ManageEvent(this);"" ",
                    PreviewCallBack = @" onclick=""PreviewEvent(this);"" ",
                    JsArrayEventName = "ArrEvents",
                    CurrentDayCssClass = "today"
                },
                LabelsAndNames = GetLabelsForMonthView()
            };
            return View("Generate", _calService.GenerateYearHTML(rqStruct));
        }

        private ActionResult MonthView(int year, int month, int calendarid =0)
        {

            var calEvents = calendarid == 0 ? _calMservice.GetUserCalendarEvents(CurrentUser.UserId,year,month) :
                _calMservice.GetUserCalendarEvents( CurrentUser.UserId, year, month, calendarid);

            //***verify that current user is not viewing calendars they are not authorized to view
            var calendar = _calMservice.GetCalendar(calendarid);
            
            if (calendar != null)
            {
                ViewBag.CalendarName = calendar.Name;
                ViewBag.CalendarId = calendar.id;
            }

            var rqStruct = new CalendarRequestStruct
            {
                Info = CultureInfo.CreateSpecificCulture(CurrentUser.Culture),
                TableTemplate = @" border=""1"" class=""calendar"" ",
                Year = year,
                Month = month,
                RelatedEvents = calEvents,
                CalendarId = calendarid,
                UserCanCreateEvent = CurrentUser.HasProfile((int)Variables.Profiles.CalendarCreateEvent),
                UserId = CurrentUser.UserId,
                ClientConfig = new ClientScriptConfig
                    {
                        PageClientId = 1,
                        ActiveTdClickCallBack = @" onclick=""ManageActiveDay(this);"" ",
                        EventClickCallBack = @" onclick=""ManageEvent(this);"" ",
                        PreviewCallBack = @" onclick=""PreviewEvent(this);"" ",
                        JsArrayEventName = "ArrEvents",
                        CurrentDayCssClass = "today"
                    },
                LabelsAndNames = GetLabelsForMonthView()
            };
            return View("Generate",_calService.GenerateCalendarHTML(rqStruct));
        }

        private Dictionary<string, string> GetLabelsForMonthView()
        {
            return new Dictionary<string, string>
                {
                    {"EventTitle", Res.Calendar.Evt_Title },
                    {"EventLocation", Res.Calendar.Evt_Location},
                    {"EventStart", Res.Calendar.Evt_Start},
                    {"EventEnd", Res.Calendar.Evt_End},
                    {"EventDescription", Res.Calendar.Evt_Description},
                    {"TooltipEditEvent", Res.Calendar.Evt_Edit},
                    {"ClosePreview", Res.Calendar.Evt_Preview_Close}
                };
        }

        public ActionResult GetCalendarMonth(int year, int month, int calendarid)
        {
            return MonthView(year, month, calendarid);
        }
       
        public ActionResult GetWeekView(int year, int month, int day, int calendarid =0)
        {
            try
            {
                var calendar = _calMservice.GetCalendar(calendarid);

                if (calendar != null)
                {
                    ViewBag.CalendarName = calendar.Name;
                    ViewBag.CalendarId = calendar.id;
                }

                var calEvents = calendarid == 0 ? _calMservice.GetUserCalendarEvents(CurrentUser.UserId, year, month) :
               _calMservice.GetUserCalendarEvents(CurrentUser.UserId, year, month, calendarid);

                var weekRequest = new CalendarWeekRequestStruct
                {
                    DateRequested = new DateTime(year, month, day),
                    Info = CultureInfo.CreateSpecificCulture(CurrentUser.Culture),//read user culture here
                    TableTemplate = @" border=""1"" class=""calendarweek"" ",
                    DayHeaderFormat = "ddd, MMM d",
                    CrossEdgeContent = " ",
                    RelatedEvents = calEvents,
                    CalendarId = calendarid,
                     ClientConfig = new ClientScriptConfig
                    {
                        PageClientId = 1,
                        ActiveTdClickCallBack = @" onclick=""ManageActiveDay(this);"" ",
                        EventClickCallBack = @" onclick=""ManageEvent(this);"" ",
                        JsArrayEventName = "ArrEvents",
                        CurrentDayCssClass = "today"
                    }
                };

                return View("Generate", _calService.GenerateWeekHTML(weekRequest));
            }
            catch (Exception ex)
            {
                Log.Debug(string.Format("Calendar week view params Year: {0} - Month {1} - Day {2} " + Environment.NewLine +
                    ex.Message, year, month, day));

                return View("Generate");
            }

            
        }


        public ActionResult GetDayView(int year, int month, int day, int calendarid = 0)
        {
            Log.Debug(string.Format("Calendar day view params Year: {0} - Month {1} - Day {2} ", year, month, day));

            var calendar = _calMservice.GetCalendar(calendarid);

            if (calendar != null)
            {
                ViewBag.CalendarName = calendar.Name;
                ViewBag.CalendarId = calendar.id;
            }

            var calEvents = calendarid == 0 ? _calMservice.GetUserDayCalendarEvents(CurrentUser.UserId, new DateTime(year, month, day)) :
             _calMservice.GetUserDayCalendarEvents(CurrentUser.UserId, new DateTime( year, month,day), calendarid);

            var weekRequest = new CalendarWeekRequestStruct
            {
                DateRequested = new DateTime(year, month, day),
                Info = CultureInfo.CreateSpecificCulture(CurrentUser.Culture),//read user culture here
                TableTemplate = @" border=""1"" class=""calendarweek"" ",
                DayHeaderFormat = "ddd, MMM d",
                CrossEdgeContent = " ",
                RelatedEvents = calEvents,
                CalendarId = calendarid,
                ClientConfig = new ClientScriptConfig
                {
                    PageClientId = 1,
                    ActiveTdClickCallBack = @" onclick=""ManageActiveDay(this);"" ",
                    EventClickCallBack = @" onclick=""ManageEvent(this);"" ",
                    JsArrayEventName = "ArrEvents",
                    CurrentDayCssClass = ""
                }
            };

            return View("Generate", _calService.GenerateDayHTML(weekRequest));
        }

        
        public ActionResult ListPersonal()
        {
            List<TEF.Calendar> lstCalendars = _calMservice.GetUserCalendars(CurrentUser.UserId);
            return View("Index", lstCalendars);
        }

       
    }
}

