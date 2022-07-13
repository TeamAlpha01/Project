namespace IMS.Service{
    public interface ITokenService
    {
        public object AuthToken(string employeeMail, string password);
    }
}