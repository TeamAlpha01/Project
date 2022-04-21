using System;
 public class AvailableResponse{

 };
public class CancellationResponse{

 };


 public class AvailableResponseServices{

    //For AvailableResponse entity
    public List<AvailableResponse> ViewAvailableMember(int DriveId);
    public List<AvailableResponse> ViewCancelledInterview();
    public void ScheduleInterview(int employeeId);
    
    //For CancellationReason entity
    public void CancellInterview(int employeeId);
 }