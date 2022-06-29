using System;
using System.Collections.Generic;
using IMS.Models;

namespace UnitTesting.MockData
{
    public static class EmployeeAvailabilityMock
    {
        public static EmployeeAvailability SetTimeSlotWithValidData()
        {
            return new EmployeeAvailability()
            {
                DriveId = 1,
                EmployeeId = 1,
                InterviewDate = Convert.ToDateTime("2022-07-13"),
                From=Convert.ToDateTime("2022-07-13 09:00"),
                To=Convert.ToDateTime("2022-07-13 09:30"),
                IsInterviewScheduled=true,
                IsInterviewCancelled =false,
                CancellationReason=null,
                Comments=null
                 


            };
        }
    }
}