namespace IMS.Service
{
    public static class UitilityService 
    {
        public enum Mode
        {
            Online = 1,
            Offline = 2
        }
        public enum ResponseType
        {
            NotResponded = 0,
            Accepted = 1,
            Denied = 2,
            Ignored = 3
        }

        public static string GetCancellationReason(int cancellationId)
        {
            if(cancellationId == 1)
                return "Interviewer not available";
            
            return "Candidate not available";
        }
    }
}