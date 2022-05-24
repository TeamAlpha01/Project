using IMS.Models;

namespace IMS.Service
{
    public interface IMailService
        {
             Task SendEmailAsync(MailRequest mailRequest);
        }
}