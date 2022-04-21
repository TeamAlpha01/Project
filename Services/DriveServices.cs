using System;
public class Drive{

}
public class DriveServices{
    
    //For TAC in Drive Enitity
     public void CreateDrive(Drive drive);
    public void CancelDrive(int driveId);    
    public List<Drive> ViewTodayDrive(int departmentId,int poolId);
    public List<Drive> ViewUpcommingDrive(int departmentId,int poolId,DateTime driveDate);
    public List<Drive> ViewScheduledDrive(int departmentId,int poolId,DateTime driveDate);
    public Drive ViewDrive(int driveId);
    public List<Drive> ViewDrives(int departmentId,int poolId,DateTime driveDate);
    
    //For Interviewer in Drive Enitity
    
    public List<Drive> ViewDriveInvites(int employeeId);
    public List<Drive> ViewTodayInterviews(int driveId,int poolId,DateTime driveDate,int employeeId);
    public List<Drive> ViewScheduledInterviews(int driveId,int poolId,DateTime driveDate,int employeeId);
    public List<Drive> ViewUpcommingInterviews(int driveId,int poolId,DateTime driveDate,int employeeId);
    public List<Drive> ViewDashboard(int employeeId);
    public List<Drive> ViewScheduledHistory(int employeeId);
    public List<Drive> ViewCancelledHistory(int employeeId);

}