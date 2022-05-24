using MailKit;
using MimeKit;
using IMS.Models;
using Microsoft.Extensions.Options;
using IMS.Services;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace IMS.Services
{

    public class MailService : IMailService
    {
    private readonly MailSettings _mailSettings;
    public MailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }

    public async Task SendEmailAsync(MailRequest mailRequest)
{
    var email = new MimeMessage();
    email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
    email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
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
}
}