using IMS.Models;

namespace IMS.Service
{
    public interface IMailService
    {
        public Task SendEmailAsync(MailRequest mailRequest,bool isSingleMail);
        public MailRequest WelcomeEmployeeMail(string newEmployeeMailId, string newEmployeeName);
        public MailRequest AddedEmployeeToPool(int employeeId, int poolId, int tacId);
        public MailRequest RemovedEmployeeFromPool(int poolMemberId, int tacId);
        public MailRequest DriveInvites(Drive drive, int tacId);
        public MailRequest DriveCancelled(int driveId, int tacId);
        public MailRequest InterviewScheduled(int employeeAvailabilityId, int tacId);
        public MailRequest InterviewCancelled(int employeeAvailabilityId);

    }
}