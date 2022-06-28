using System;
using System.Collections.Generic;
using IMS.Models;

namespace UnitTesting.MockData
{
    public static class DriveMock
    {
        public static Drive CreateValidDrive()
        {
            return new Drive()
            {
                Name = "Todays Drive 1",
                FromDate = System.DateTime.Now, 
                ToDate = System.DateTime.Now, 
                DepartmentId = 1,
                PoolId = 1, 
                ModeId = 2,
                LocationId = 1,
                AddedBy = 10, 
                UpdatedBy = 10,
                IsCancelled=false,
                IsScheduled=true,
                SlotTiming=30
            };
        }
        public static List<Drive> GetDriveMockForNonCancelled()
        {
            List<Drive> mockDrives = new List<Drive>();
            mockDrives.Add(new Drive(){ DriveId = 1, Name = "Todays Drive 1", FromDate = System.DateTime.Now, ToDate = System.DateTime.Now,  DepartmentId = 1, PoolId = 1, ModeId = 2, LocationId = 1, AddedBy = 10, UpdatedBy = 10,IsCancelled=false,IsScheduled=true,Pool=new Pool(){PoolName="TestPool",department=new Department(){DepartmentName="testDepartment"}},Location=new Location(){LocationName="TestLocation"}});
            mockDrives.Add(new Drive(){ DriveId = 2, Name = "Todays Drive 2", FromDate = System.DateTime.Now, ToDate = System.DateTime.Now,  DepartmentId = 1, PoolId = 1, ModeId = 2, LocationId = 1, AddedBy = 10, UpdatedBy = 10 ,IsCancelled=false,IsScheduled=true,Pool=new Pool(){PoolName="TestPool",department=new Department(){DepartmentName="testDepartment"}},Location=new Location(){LocationName="TestLocation"}});
            mockDrives.Add(new Drive(){ DriveId = 3, Name = "Scheduled Drive 1", FromDate = System.DateTime.Now.AddDays(10), ToDate = System.DateTime.Now.AddDays(10),  DepartmentId = 1, PoolId = 1, ModeId = 2, LocationId = 1, AddedBy = 10, UpdatedBy = 10 ,IsCancelled=false,IsScheduled=true,Pool=new Pool(){PoolName="TestPool",department=new Department(){DepartmentName="testDepartment"}},Location=new Location(){LocationName="TestLocation"}});
            mockDrives.Add(new Drive(){ DriveId = 4, Name = "Scheduled Drive 2", FromDate = System.DateTime.Now.AddDays(10), ToDate = System.DateTime.Now.AddDays(10),  DepartmentId = 1, PoolId = 1, ModeId = 2, LocationId = 1, AddedBy = 10, UpdatedBy = 10 ,IsCancelled=false,IsScheduled=true,Pool=new Pool(){PoolName="TestPool",department=new Department(){DepartmentName="testDepartment"}},Location=new Location(){LocationName="TestLocation"}});
            mockDrives.Add(new Drive(){ DriveId = 5, Name = "Upcomming Drive 1", FromDate = System.DateTime.Now.AddDays(10), ToDate = System.DateTime.Now.AddDays(10),  DepartmentId = 1, PoolId = 1, ModeId = 2, LocationId = 1, AddedBy = 10, UpdatedBy = 10 ,IsCancelled=false,IsScheduled=false,Pool=new Pool(){PoolName="TestPool",department=new Department(){DepartmentName="testDepartment"}},Location=new Location(){LocationName="TestLocation"}});
            mockDrives.Add(new Drive(){ DriveId = 6, Name = "Upcomming Drive 2", FromDate = System.DateTime.Now.AddDays(10), ToDate = System.DateTime.Now.AddDays(10),  DepartmentId = 1, PoolId = 1, ModeId = 2, LocationId = 1, AddedBy = 10, UpdatedBy = 10 ,IsCancelled=false,IsScheduled=false,Pool=new Pool(){PoolName="TestPool",department=new Department(){DepartmentName="testDepartment"}},Location=new Location(){LocationName="TestLocation"}});
            //mockDrives.Add(new Drive(){ DriveId = 7, Name = "Cancelled Drive", FromDate = System.DateTime.Now.AddDays(10), ToDate = System.DateTime.Now.AddDays(11),  DepartmentId = 1, PoolId = 1, ModeId =2, LocationId = 1, AddedBy = 1, UpdatedBy = 1,IsCancelled=true,IsScheduled=false,Pool=new Pool(){PoolName="TestPool",department=new Department(){DepartmentName="testDepartment"}},Location=new Location(){LocationName="TestLocation"}});
            return mockDrives;
        }
        public static List<Drive> GetDriveMockForCancelled()
        {
            List<Drive> mockDrives = new List<Drive>();
            mockDrives.Add(new Drive(){ DriveId = 7, Name = "Cancelled Drive", FromDate = System.DateTime.Now.AddDays(10), ToDate = System.DateTime.Now.AddDays(10),  DepartmentId = 1, PoolId = 1, ModeId =2, LocationId = 1, AddedBy = 1, UpdatedBy = 1,IsCancelled=true,IsScheduled=false,Pool=new Pool(){PoolName="TestPool",department=new Department(){DepartmentName="testDepartment"}},Location=new Location(){LocationName="TestLocation"}});
            return mockDrives;
        }   
        public static List<object> GetExpectedTodaysDriveMock()
        {
            List<object> mockDrives = new List<object>();
            mockDrives.Add(new { DriveId = 1, DriveName = "Todays Drive 1", FromDate = System.DateTime.Now.ToString("yyyy-MM-dd"), ToDate = System.DateTime.Now.ToString("yyyy-MM-dd"),  DrivePool="TestPool",DriveDepartment="testDepartment",DriveLocation="TestLocation",DriveMode="Offline"});
            mockDrives.Add(new { DriveId = 2, DriveName = "Todays Drive 2", FromDate = System.DateTime.Now.ToString("yyyy-MM-dd"), ToDate = System.DateTime.Now.ToString("yyyy-MM-dd"),  DrivePool="TestPool",DriveDepartment="testDepartment",DriveLocation="TestLocation",DriveMode="Offline"});
            return mockDrives;
        }   

        public static List<object> GetExpectedScheduledDriveMock()
        {
            List<object> mockDrives = new List<object>();
            mockDrives.Add(new { DriveId = 3, DriveName = "Scheduled Drive 1", FromDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"), ToDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"),  DrivePool="TestPool",DriveDepartment="testDepartment",DriveLocation="TestLocation",DriveMode="Offline"});
            mockDrives.Add(new { DriveId = 4, DriveName = "Scheduled Drive 2", FromDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"), ToDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"),  DrivePool="TestPool",DriveDepartment="testDepartment",DriveLocation="TestLocation",DriveMode="Offline"});
            return mockDrives;
        }   
        public static List<object> GetExpectedUpcommingDriveMock()
        {
            List<object> mockDrives = new List<object>();
            mockDrives.Add(new { DriveId = 5, DriveName = "Upcomming Drive 1", FromDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"), ToDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"),  DrivePool="TestPool",DriveDepartment="testDepartment",DriveLocation="TestLocation",DriveMode="Offline"});
            mockDrives.Add(new { DriveId = 6, DriveName = "Upcomming Drive 2", FromDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"), ToDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"),  DrivePool="TestPool",DriveDepartment="testDepartment",DriveLocation="TestLocation",DriveMode="Offline"});
            return mockDrives;
        }   
        public static List<object> GetExpectedCancelledDriveMock()
        {
            List<object> mockDrives = new List<object>();
            mockDrives.Add(new { DriveId = 7, DriveName = "Cancelled Drive", FromDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"), ToDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"),  DrivePool="TestPool",DriveDepartment="testDepartment",DriveLocation="TestLocation",DriveMode="Offline"});
            return mockDrives;
        }   

        public static Dictionary<string, int> GetTacExpectedDashboardCount()
        {
                var ExpectedDashboardCount = new Dictionary<string, int>();
                ExpectedDashboardCount.Add("Scheduled Drives", 1);
                ExpectedDashboardCount.Add("Cancelled Drives", 1);
                return ExpectedDashboardCount;
        }

        internal static object GetExpectedDriveMock()
        {
            return new { DriveId = 1, DriveName = "Todays Drive 1", FromDate = System.DateTime.Now.ToString("yyyy-MM-dd"), ToDate = System.DateTime.Now.ToString("yyyy-MM-dd"),  DrivePool="TestPool",DriveDepartment="testDepartment",DriveLocation="TestLocation",DriveMode="Offline"};
        }

        internal static Drive GetDriveMock()
        {
            return new Drive(){ DriveId = 1, Name = "Todays Drive 1", FromDate = System.DateTime.Now, ToDate = System.DateTime.Now,  DepartmentId = 1, PoolId = 1, ModeId = 2, LocationId = 1, AddedBy = 10, UpdatedBy = 10,IsCancelled=false,IsScheduled=true,Pool=new Pool(){PoolName="TestPool",department=new Department(){DepartmentName="testDepartment"}},Location=new Location(){LocationName="TestLocation"}};
        }
        public static List<object> GetExpectedDriveInviteMock()
        {
            List<object> mockDrives = new List<object>();
            mockDrives.Add(new { DriveId = 3, DriveName = "Scheduled Drive 1", FromDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"), ToDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"),  DrivePool="TestPool",DriveDepartment="testDepartment",DriveLocation="TestLocation",DriveMode="Offline"});
            mockDrives.Add(new { DriveId = 4, DriveName = "Scheduled Drive 2", FromDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"), ToDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"),  DrivePool="TestPool",DriveDepartment="testDepartment",DriveLocation="TestLocation",DriveMode="Offline"});
            mockDrives.Add(new { DriveId = 5, DriveName = "Upcomming Drive 1", FromDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"), ToDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"),  DrivePool="TestPool",DriveDepartment="testDepartment",DriveLocation="TestLocation",DriveMode="Offline"});
            mockDrives.Add(new { DriveId = 6, DriveName = "Upcomming Drive 2", FromDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"), ToDate = System.DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"),  DrivePool="TestPool",DriveDepartment="testDepartment",DriveLocation="TestLocation",DriveMode="Offline"});
            return mockDrives;
        }
    }
}