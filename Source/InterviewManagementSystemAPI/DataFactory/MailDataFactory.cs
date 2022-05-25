using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Service;
namespace IMS.DataFactory{
    public static class MailDataFactory
    {
        public static IMailDataAccessLayer GetMailDataAccessLayerObject(ILogger<MailService> logger)
        {
            return new MailDataAccessLayer(logger);
        }
        public static MailRequest GetMailRequestObject()
        {
            return new MailRequest();
        }
    }
}
