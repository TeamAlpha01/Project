using MailKit;
using MimeKit;
using IMS.Models;
using Microsoft.Extensions.Options;
using IMS.Service;
using MailKit.Net.Smtp;
using MailKit.Security;
using IMS.DataAccessLayer;
using System.Net.Mail;
using IMS.CustomExceptions;

namespace IMS.Service
{

    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private ILogger<MailService> _logger;
        private IMailDataAccessLayer _mailDataAccessLayer;
        public MailService(ILogger<MailService> logger, IOptions<MailSettings> mailSettings,IMailDataAccessLayer mailDataAccessLayer)
        {
            _logger = logger;
            _mailSettings = mailSettings.Value;
            _mailDataAccessLayer = mailDataAccessLayer; //DataFactory.MailDataFactory.GetMailDataAccessLayerObject(logger);
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
                    foreach (var mailid in mailRequest.ToEmailList!)
                        email.To.Add(MailboxAddress.Parse(mailid));
                }
                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder();

                builder.TextBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (SmtpException sendEmailAsyncSmptException)
            {
                _logger.LogInformation($"SmptException at Mail Service : SendEmailAsync(MailRequest mailRequest, bool isSingleMail) : {sendEmailAsyncSmptException.Message} : {sendEmailAsyncSmptException.StackTrace}");
                throw new MailException("Error Occured While Sending Mail");
            }
            catch (Exception sendEmailAsyncException)
            {
                _logger.LogInformation($"Exception at Mail Service : SendEmailAsync(MailRequest mailRequest, bool isSingleMail) : {sendEmailAsyncException.Message} : {sendEmailAsyncException.StackTrace}");
                throw new MailException("Error Occured While Sending Mail");
            }
        }
        public MailRequest WelcomeEmployeeMail(string newEmployeeMailId, string newEmployeeName)
        {
            try
            {
                MailRequest mailRequest = DataFactory.MailDataFactory.GetMailRequestObject();
                mailRequest.ToEmail = newEmployeeMailId;
                mailRequest.Subject = "Account Created Sucessfully - Aspire Interview Management System";
                mailRequest.Body = $"Hi, {newEmployeeName}.\n\nYour account has been created sucessfully, please wait until Admin verify your account.\nYou will recive a mail when the verification process is done.\n\nThank you - Team Alpha.\n\nFor any Queries Please Contact : teamalpha731@gmail.com";
                return mailRequest;
            }
            catch (Exception welcomeEmployeeMailException)
            {
                _logger.LogInformation($"Exception at Mail Service : WelcomeEmployeeMail(string newEmployeeMailId, string newEmployeeName) : {welcomeEmployeeMailException.Message} : {welcomeEmployeeMailException.StackTrace}");
                throw new MailException("Error Occured While Sending Mail");
            }
        }

        public MailRequest AddedEmployeeToPool(int employeeId, int poolId, int tacId)
        {
            try
            {
                MailRequest mailRequest = DataFactory.MailDataFactory.GetMailRequestObject();
                mailRequest.ToEmail = _mailDataAccessLayer.GetEmployeeEmail(employeeId);
                mailRequest.Subject = "Added To New Pool - Aspire Interview Management System";
                mailRequest.Body = $"Hi, {_mailDataAccessLayer.GetEmployeeName(employeeId)}.\n\nYou have been added to a \"{_mailDataAccessLayer.GetPoolName(poolId)}\" pool by TAC - {_mailDataAccessLayer.GetEmployeeName(tacId)}.\n\nThank you - Team Alpha.\n\nFor any Queries Please Contact : teamalpha731@gmail.com";
                return mailRequest;
            }
            catch (Exception addedEmployeeToPoolException)
            {
                _logger.LogInformation($"Exception at Mail Service : AddedEmployeeToPool(int employeeId, int poolId, int tacId) : {addedEmployeeToPoolException.Message} : {addedEmployeeToPoolException.StackTrace}");
                throw new MailException("Error Occured While Sending Mail");
            }
        }
        public MailRequest RemovedEmployeeFromPool(int poolMemberId, int tacId)
        {
            try
            {
                MailRequest mailRequest = DataFactory.MailDataFactory.GetMailRequestObject();
                PoolMembers? _poolMember = _mailDataAccessLayer.GetPoolMember(poolMemberId);
                mailRequest.ToEmail = _mailDataAccessLayer.GetEmployeeEmail(_poolMember.EmployeeId);
                mailRequest.Subject = "Removed From a Pool - Aspire Interview Management System";
                mailRequest.Body = $"Hi, {_mailDataAccessLayer.GetEmployeeName(_poolMember.EmployeeId)}.\n\nYou have been removed from \"{_mailDataAccessLayer.GetPoolName(_poolMember.PoolId)}\" pool by TAC - {_mailDataAccessLayer.GetEmployeeName(tacId)}.\n\nThank you - Team Alpha.\n\nFor any Queries Please Contact : teamalpha731@gmail.com";
                return mailRequest;
            }
            catch (Exception removedEmployeeFromPoolException)
            {
                _logger.LogInformation($"Exception at Mail Service : RemovedEmployeeFromPool(int poolMemberId, int tacId) : {removedEmployeeFromPoolException.Message} : {removedEmployeeFromPoolException.StackTrace}");
                throw new MailException("Error Occured While Sending Mail");
            }
        }
        public MailRequest DriveInvites(Drive drive, int tacId)
        {
            try
            {
                MailRequest mailRequest = DataFactory.MailDataFactory.GetMailRequestObject();
                mailRequest.ToEmailList = _mailDataAccessLayer.GetEmployeeEmailsByPool(drive.PoolId);
                mailRequest.Subject = "New Drive Invite - Aspire Interview Management System";
                mailRequest.Body = $"Hi,\n\nA \"{drive.Name}\" Drive has been scheduled in \"{_mailDataAccessLayer.GetPoolName(drive.PoolId)}\" pool from {drive.FromDate.ToShortDateString()} to {drive.ToDate.ToShortDateString()} by TAC - {_mailDataAccessLayer.GetEmployeeName(tacId)}.\n\nKindly give your response within {DateTime.Now.AddDays(5).ToShortDateString()}\n\nThank you - Team Alpha.\n\nFor any Queries Please Contact : teamalpha731@gmail.com";
                return mailRequest;
            }
            catch (Exception driveInvitesException)
            {
                _logger.LogInformation($"Exception at Mail Service : DriveInvites(Drive drive, int tacId) : {driveInvitesException.Message} : {driveInvitesException.StackTrace}");
                throw new MailException("Error Occured While Sending Mail");
            }
        }
        public MailRequest DriveCancelled(int driveId, int tacId)
        {
            try
            {
                MailRequest mailRequest = DataFactory.MailDataFactory.GetMailRequestObject();
                Drive ?drive = _mailDataAccessLayer.GetDrivebyId(driveId);
                mailRequest.ToEmailList = _mailDataAccessLayer.GetEmployeeEmailsByPool(drive!.PoolId);
                mailRequest.Subject = "Drive Cancelled - Aspire Interview Management System";
                mailRequest.Body = $"Hi,\n\nA \"{drive.Name}\" Drive in \"{_mailDataAccessLayer.GetPoolName(drive.PoolId)}\" pool has been Cancelled by TAC - {_mailDataAccessLayer.GetEmployeeName(tacId)}.\n\nSorry for the inconvenience.\n\nThank you - Team Alpha.\n\nFor any Queries Please Contact : teamalpha731@gmail.com";
                return mailRequest;
            }
            catch (Exception driveCancelledException)
            {
                _logger.LogInformation($"Exception at Mail Service : DriveCancelled(int driveId, int tacId) : {driveCancelledException.Message} : {driveCancelledException.StackTrace}");
                throw new MailException("Error Occured While Sending Mail");
            }
        }

        public MailRequest InterviewScheduled(int employeeAvailabilityId, int tacId)
        {
            try
            {
                MailRequest mailRequest = DataFactory.MailDataFactory.GetMailRequestObject();
                EmployeeAvailability ?employeeAvailability = _mailDataAccessLayer.GetEmployeeAvailability(employeeAvailabilityId);
                mailRequest.ToEmail = _mailDataAccessLayer.GetEmployeeEmail(employeeAvailability!.EmployeeId);
                mailRequest.Subject = "Interview Scheduled - Aspire Interview Management System";
                mailRequest.Body = $"Hi, {_mailDataAccessLayer.GetEmployeeName(employeeAvailability.EmployeeId)}\n\nA Interview in \"{employeeAvailability.Drive.Name}\" Drive under \"{_mailDataAccessLayer.GetPoolName(employeeAvailability.Drive.PoolId)}\" pool has been scheduled from {employeeAvailability.From.TimeOfDay} to {employeeAvailability.To.TimeOfDay} on {employeeAvailability.InterviewDate.ToShortDateString()} by TAC - {_mailDataAccessLayer.GetEmployeeName(tacId)}.\n\nThank you - Team Alpha.\n\nFor any Queries Please Contact : teamalpha731@gmail.com";
                return mailRequest;
            }
            catch (Exception interviewScheduledException)
            {
                _logger.LogInformation($"Exception at Mail Service : InterviewScheduled(int employeeAvailabilityId, int tacId) : {interviewScheduledException.Message} : {interviewScheduledException.StackTrace}");
                throw new MailException("Error Occured While Sending Mail");
            }
        }

        public MailRequest InterviewCancelled(int employeeAvailabilityId)
        {
            try
            {
                MailRequest mailRequest = DataFactory.MailDataFactory.GetMailRequestObject();
                EmployeeAvailability ?employeeAvailability = _mailDataAccessLayer.GetEmployeeAvailability(employeeAvailabilityId);
                mailRequest.ToEmail = _mailDataAccessLayer.GetEmployeeEmail(Convert.ToInt32(employeeAvailability!.Drive!.AddedBy));
                mailRequest.Subject = "Interview Cancelled - Aspire Interview Management System";
                mailRequest.Body = $"Hi, {_mailDataAccessLayer.GetEmployeeName(Convert.ToInt32(employeeAvailability.Drive.AddedBy))}\n\nA Interview in \"{employeeAvailability.Drive.Name}\" Drive under \"{_mailDataAccessLayer.GetPoolName(employeeAvailability.Drive.PoolId)}\" pool from {employeeAvailability.From.TimeOfDay} to {employeeAvailability.To.TimeOfDay} on {employeeAvailability.InterviewDate.ToShortDateString()}  has been cancelled by the interviewer - {_mailDataAccessLayer.GetEmployeeName(employeeAvailability.EmployeeId)}.\n\nThank you - Team Alpha.\n\nFor any Queries Please Contact : teamalpha731@gmail.com";
                return mailRequest;
            }
            catch (Exception interviewCancelledException)
            {
                _logger.LogInformation($"Exception at Mail Service : InterviewCancelled(int employeeAvailabilityId) : {interviewCancelledException.Message} : {interviewCancelledException.StackTrace}");
                throw new MailException("Error Occured While Sending Mail");
            }
        }
    }
}