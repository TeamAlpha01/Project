using IMS.Models;

namespace IMS.Services
{
    public interface IMailService
        {
             Task SendEmailAsync(MailRequest mailRequest);
        }
}