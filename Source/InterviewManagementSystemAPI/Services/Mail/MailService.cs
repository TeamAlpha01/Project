using MailKit;
using MimeKit;
using IMS.Models;
using Microsoft.Extensions.Options;
using IMS.Service;
using MailKit.Net.Smtp;
using MailKit.Security;
using IMS.DataAccessLayer;

namespace IMS.Service
{

    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private ILogger<MailService> _logger;
        private IMailDataAccessLayer _mailDataAccessLayer;
        public MailService(ILogger<MailService> logger, IOptions<MailSettings> mailSettings)
        {
            _logger = logger;
            _mailSettings = mailSettings.Value;
            _mailDataAccessLayer = DataFactory.MailDataFactory.GetMailDataAccessLayerObject(logger);
        }

        public async Task SendEmailAsync(MailRequest mailRequest, bool isSingleMail)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                if (isSingleMail == true)
                    email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                else
                {
                    foreach (var mailid in mailRequest.ToEmailList)
                        email.To.Add(MailboxAddress.Parse(mailid));
                }
                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder();

                builder.TextBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {
                throw ex;//make it perfect
            }
        }
        public MailRequest WelcomeEmployeeMail(string newEmployeeMailId, string newEmployeeName)
        {
            MailRequest mailRequest = DataFactory.MailDataFactory.GetMailRequestObject();
            mailRequest.ToEmail = newEmployeeMailId;
            mailRequest.Subject = "Account Created Sucessfully - Aspire Interview Management System";
            mailRequest.Body = $"Hi, {newEmployeeName}.\n\nYour account has been created sucessfully, please wait until Admin verify your account.\nYou will recive a mail when the verification process is done.\n\nThank you - Team Alpha.\n\nFor any Queries Please Contact : teamalpha731@gmail.com";
            return mailRequest;
        }

        public MailRequest AddedEmployeeToPool(int employeeId, int poolId, int tacId)
        {
            MailRequest mailRequest = DataFactory.MailDataFactory.GetMailRequestObject();
            mailRequest.ToEmail = _mailDataAccessLayer.GetEmployeeEmail(employeeId);
            mailRequest.Subject = "Added To New Pool - Aspire Interview Management System";
            mailRequest.Body = $"Hi, {_mailDataAccessLayer.GetEmployeeName(employeeId)}.\n\nYou have been added to a \"{_mailDataAccessLayer.GetPoolName(poolId)}\" pool by TAC - {_mailDataAccessLayer.GetEmployeeName(tacId)}.\n\nThank you - Team Alpha.\n\nFor any Queries Please Contact : teamalpha731@gmail.com";
            return mailRequest;
        }
        public MailRequest RemovedEmployeeFromPool(int poolMemberId, int tacId)
        {
            MailRequest mailRequest = DataFactory.MailDataFactory.GetMailRequestObject();
            PoolMembers _poolMember = _mailDataAccessLayer.GetPoolMember(poolMemberId);
            mailRequest.ToEmail = _mailDataAccessLayer.GetEmployeeEmail(_poolMember.EmployeeId);
            mailRequest.Subject = "Removed From a Pool - Aspire Interview Management System";
            mailRequest.Body = $"Hi, {_mailDataAccessLayer.GetEmployeeName(_poolMember.EmployeeId)}.\n\nYou have been removed from \"{_mailDataAccessLayer.GetPoolName(_poolMember.PoolId)}\" pool by TAC - {_mailDataAccessLayer.GetEmployeeName(tacId)}.\n\nThank you - Team Alpha.\n\nFor any Queries Please Contact : teamalpha731@gmail.com";
            return mailRequest;
        }
        public MailRequest DriveInvites(Drive drive, int tacId)
        {
            MailRequest mailRequest = DataFactory.MailDataFactory.GetMailRequestObject();
            mailRequest.ToEmailList = _mailDataAccessLayer.GetEmployeeEmailsByPool(drive.PoolId);
            mailRequest.Subject = "New Drive Invite - Aspire Interview Management System";
            mailRequest.Body = $"Hi,\n\nA \"{drive.Name}\" Drive has been scheduled in \"{_mailDataAccessLayer.GetPoolName(drive.PoolId)}\" pool from {drive.FromDate.ToShortDateString()} to {drive.ToDate.ToShortDateString()} by TAC - {_mailDataAccessLayer.GetEmployeeName(tacId)}.\n\nKindly give your response within {DateTime.Now.AddDays(5).ToShortDateString()}\n\nThank you - Team Alpha.\n\nFor any Queries Please Contact : teamalpha731@gmail.com";
            return mailRequest;
        }
        public MailRequest DriveCancelled(int driveId, int tacId)
        {
            MailRequest mailRequest = DataFactory.MailDataFactory.GetMailRequestObject();
            Drive drive = _mailDataAccessLayer.GetDrivebyId(driveId);
            mailRequest.ToEmailList = _mailDataAccessLayer.GetEmployeeEmailsByPool(drive.PoolId);
            mailRequest.Subject = "Drive Cancelled - Aspire Interview Management System";
            mailRequest.Body = $"Hi,\n\nA \"{drive.Name}\" Drive in \"{_mailDataAccessLayer.GetPoolName(drive.PoolId)}\" pool has been Cancelled by TAC - {_mailDataAccessLayer.GetEmployeeName(tacId)}.\n\nSorry for the inconvenience.\n\nThank you - Team Alpha.\n\nFor any Queries Please Contact : teamalpha731@gmail.com";
            return mailRequest;
        }

        public MailRequest InterviewScheduled(int employeeAvailabilityId, int tacId)
        {
            MailRequest mailRequest = DataFactory.MailDataFactory.GetMailRequestObject();
            EmployeeAvailability employeeAvailability = _mailDataAccessLayer.GetEmployeeAvailability(employeeAvailabilityId);
            mailRequest.ToEmail = _mailDataAccessLayer.GetEmployeeEmail(employeeAvailability.EmployeeId);
            mailRequest.Subject = "Interview Scheduled - Aspire Interview Management System";
            mailRequest.Body = $"Hi, {_mailDataAccessLayer.GetEmployeeName(employeeAvailability.EmployeeId)}\n\nA Interview in \"{employeeAvailability.Drive.Name}\" Drive under \"{_mailDataAccessLayer.GetPoolName(employeeAvailability.Drive.PoolId)}\" pool has been scheduled from {employeeAvailability.From.TimeOfDay} to {employeeAvailability.To.TimeOfDay} on {employeeAvailability.InterviewDate.ToShortDateString()} by TAC - {_mailDataAccessLayer.GetEmployeeName(tacId)}.\n\nThank you - Team Alpha.\n\nFor any Queries Please Contact : teamalpha731@gmail.com";
            return mailRequest;
        }

        public MailRequest InterviewCancelled(int employeeAvailabilityId)
        {
            MailRequest mailRequest = DataFactory.MailDataFactory.GetMailRequestObject();
            EmployeeAvailability employeeAvailability = _mailDataAccessLayer.GetEmployeeAvailability(employeeAvailabilityId);
            mailRequest.ToEmail = _mailDataAccessLayer.GetEmployeeEmail(Convert.ToInt32(employeeAvailability.Drive.AddedBy));
            mailRequest.Subject = "Interview Cancelled - Aspire Interview Management System";
            mailRequest.Body = $"Hi, {_mailDataAccessLayer.GetEmployeeName(Convert.ToInt32(employeeAvailability.Drive.AddedBy))}\n\nA Interview in \"{employeeAvailability.Drive.Name}\" Drive under \"{_mailDataAccessLayer.GetPoolName(employeeAvailability.Drive.PoolId)}\" pool from {employeeAvailability.From.TimeOfDay} to {employeeAvailability.To.TimeOfDay} on {employeeAvailability.InterviewDate.ToShortDateString()}  has been cancelled by the interviewer - {_mailDataAccessLayer.GetEmployeeName(employeeAvailability.EmployeeId)}.\n\nThank you - Team Alpha.\n\nFor any Queries Please Contact : teamalpha731@gmail.com";
            return mailRequest;
        }
    }
}