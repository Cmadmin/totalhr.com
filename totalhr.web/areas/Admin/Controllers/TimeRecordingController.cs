﻿using Authentication.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using totalhr.data.TimeRecordingSystem.Models;
using totalhr.services.Infrastructure;
using totalhr.web.Areas.TimeRecording.ViewModels;

namespace totalhr.web.Areas.Admin.Controllers
{
    public class TimeRecordingController : AdminBaseController
    {
        public ITimeRecordingServices _timeRecordingService { get; set; }
        public IAccountService _accountsService { get; set; }

        public TimeRecordingController(ITimeRecordingServices timeRecordingService, IAccountService accountService,
            IOAuthService authService)    : base(authService)
        {
            _timeRecordingService = timeRecordingService;
            _accountsService = accountService;
        }

        // GET: /TimeRecording/TimeRecording/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RecordTime(long id = 0)
        {
            var vm = new TimeRecordingVM();
            if (id == 0)
            {
                //Get User Id & Company Id
                var user = _accountsService.GetUser(59);
                vm = new TimeRecordingVM()
                {
                    UserId = user.id,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now
                };
            }
            else
            {
                vm = new TimeRecordingVM(_timeRecordingService.GetById(id));
            }
            return View(vm);
        }

        [HttpPost]
        public ActionResult RecordTime(TimeRecordingVM vm)
        {
            if (ModelState.IsValid)
            {
                var isSuccess = false;
                if (vm.Id == 0)
                {
                    isSuccess = _timeRecordingService.RecordTimeForUser(vm.Id, vm.UserId, vm.StartTime, vm.EndTime,
                       new Audit() { AddedByUserId = vm.UserId, DateAdded = DateTime.Now });
                    if (isSuccess)
                        return RedirectToAction("Index", "TimeRecording");
                }
                else
                {
                    isSuccess = _timeRecordingService.RecordTimeForUser(vm.Id, vm.UserId, vm.StartTime, vm.EndTime,
                       new Audit() { UpdatedByUserId = vm.UserId, DateUpdated = DateTime.Now });
                    if (isSuccess)
                        return RedirectToAction("Details", "TimeRecording", new { id = vm.Id });
                }
            }
            return View(vm);
        }

        [HttpGet]
        public ActionResult Search()
        {
            var vm = new SearchVM();
            vm.SetUpInitialSearch();
            var searchResults = _timeRecordingService.Search(vm.StartDate, vm.EndDate, 0, vm.ResultsPerPage);
            vm.Results = TimeRecordingDetailsVM.Build(searchResults);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Search(SearchVM vm)
        {
            var searchResults = _timeRecordingService.Search(vm.StartDate, vm.EndDate, vm.PageNumber * vm.ResultsPerPage, vm.ResultsPerPage);
            vm.Results = TimeRecordingDetailsVM.Build(searchResults);
            return View(vm);
        }


        public ActionResult Details(long id)
        {
            var vm = new TimeRecordingDetailsVM(_timeRecordingService.GetById(id));
            return View(vm);
        }

    }
}