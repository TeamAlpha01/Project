using System;
using System.Collections.Generic;
using IMS.Models;

namespace UnitTesting.MockData
{
    public static class EmployeeResponseMock
    {
        public static EmployeeDriveResponse AddResponse()
        {
            return new EmployeeDriveResponse()
            {
                DriveId = 1,
                EmployeeId = 1, 
                ResponseType = 1
            };
        }
    }
}