﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using totalhr.data.TimeRecordingSystem.EF;
using totalhr.data.TimeRecordingSystem.Models;
using totalhr.data.TimeRecordingSystem.Repositories.Infrastructure;
using totalhr.services.Infrastructure;

namespace totalhr.services.Implementation
{
    public class TimeRecordingServices: ITimeRecordingServices
    {
        private ITimeRecordingRepository _timeRecordingRepository { get; set; }
        private IAccountService _accountService { get; set; }

        public TimeRecordingServices(ITimeRecordingRepository timeRecordingRepository, IAccountService accountService)
        {
            _timeRecordingRepository = timeRecordingRepository;
            _accountService = accountService;
        }

        public bool RecordTimeForUser(int userId, int companyId, DateTime startTime, DateTime endTime, Audit audit)
        {
            //find if user exists
            if (_accountService.GetUser(userId) != null)
            {
                //record time
                var timeRecording = new TimeRecording(userId, startTime, endTime, audit);
                _timeRecordingRepository.Add(timeRecording);
                return true;
            }
            return false;
        }
    }
}
