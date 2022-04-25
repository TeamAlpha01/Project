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
    public bool CancelDrive(int driveId, string Reason);
    public List<Drive> ViewTodayDrive(int departmentId, int poolId);
    public List<Drive> ViewUpcommingDrive(int departmentId, int poolId, DateTime driveDate);
    public List<Drive> ViewScheduledDrive(int departmentId, int poolId, DateTime driveDate);
    public List<Drive> ViewDashboard(int employeeId);
    public List<Drive> ViewAllScheduledDrives(int departmentId, int poolId, DateTime driveDate);
    public List<Drive> ViewAllCancelledDrives(int departmentId, int poolId, DateTime driveDate);
    public Drive ViewDrive(int driveId);


    //For Interviewer in Drive Enitity

    public List<Drive> ViewDriveInvites(int employeeId);
    public List<Drive> ViewAllInterview(int employeeId);
    public List<Drive> ViewTodayInterviews(int poolId, DateTime driveDate, int employeeId);
    public List<Drive> ViewScheduledInterviews(int poolId, DateTime driveDate, int employeeId);
    public List<Drive> ViewUpcommingInterviews(int poolId, DateTime driveDate, int employeeId);

    public List<Drive> ViewInterviewStatus(int employeeId, bool IsScheduled, bool IsInterviewCancelled, int ResponseType);

    //For Available Member entity
    public List<AvailableMember> ViewAvailableMember(int DriveId);
    public List<AvailableMember> ViewCancelledInterview(int DriveId);
    public bool ScheduleInterview(AvailableMember availableMember);
    public bool CancelInterview(AvailableMember availableMember);

    
    //For Employee Drive Response entity
    public bool AddResponse(EmployeeDriveResponse employeeResponse);




}