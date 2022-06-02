namespace IMS.Service{
    public interface ITokenService
    {
        public object AuthToken(string employeeAceNumber, string password);
    }
}