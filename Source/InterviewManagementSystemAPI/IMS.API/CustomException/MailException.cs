namespace IMS.CustomExceptions
{
    public class MailException : Exception
    {
        public MailException(string errorMessage) : base(errorMessage){}
    }
}