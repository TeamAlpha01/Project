using System;
public class Drive
{

}
public class AvailableMember { }
public class EmployeeDriveResponse { }
public class DriveServices
{

    //For TAC in Drive Enitity
    public bool CreateDrive(Drive drive);
    public List<Drive> ViewTodayDrive(int departmentId, int poolId);
    public List<Drive> ViewUpcommingDrive(int departmentId, int poolId, DateTime driveDate);
    public List<Drive> ViewScheduledDrive(int departmentId, int poolId, DateTime driveDate);
    public bool CancelDrive(int driveId, string Reason,int employeeId);
    public List<int> ViewDashboard(int employeeId); //for all  user : based on the emp role we can seggregate the output
    public List<Drive> ViewAllScheduledDrives(int departmentId, int poolId, DateTime driveDate);
    public List<Drive> ViewAllCancelledDrives(int departmentId, int poolId, DateTime driveDate);


    //For Interviewer in Drive Enitity

    public Drive ViewDrive(int driveId);
    public List<Drive> ViewDriveInvites(int employeeId);
    public List<Drive> ViewAllInterview(int employeeId);
    public List<Drive> ViewTodayInterviews(int poolId, DateTime driveDate, int employeeId);
    public List<Drive> ViewScheduledInterviews(int poolId, DateTime driveDate, int employeeId);
    public List<Drive> ViewUpcommingInterviews(int poolId, DateTime driveDate, int employeeId);

    public List<Drive> ViewInterviewStatus(int employeeId, bool IsScheduled, bool IsInterviewCancelled, int ResponseType);


    //For Available Member entity

    //TAC
    public List<AvailableMember> ViewDriveMembersByStatus(int DriveId,bool IsScheduled); // for both viewing today's and upcoming drive members based on IsSchedule
    public List<AvailableMember> ViewCancelledInterview(int DriveId);
    public bool ScheduleInterview(AvailableMember availableMember);
    public bool CancelInterview(AvailableMember availableMember);

    
    //For Employee Drive Response entity
    public bool AddResponse(EmployeeDriveResponse employeeResponse);




}