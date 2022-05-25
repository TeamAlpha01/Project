using IMS.Models;

namespace IMS.Service
{
    public interface IMailService
    {
        public Task SendEmailAsync(MailRequest mailRequest,bool isSingleMail);
        public MailRequest WelcomeEmployeeMail(string newEmployeeMailId, string newEmployeeName);
        public MailRequest AddedEmployeeToPool(int employeeId, int poolId, int tacId);
        public MailRequest RemovedEmployeeFromPool(int poolMemberId, int tacId);
    }
}