namespace IMS.Service
{
    public static class UtilityService 
    {
        public static string TacHashKey="a378b5658dbdcaf167e945242572bd3339f540af202acf0ab70741e411d861b7";
        public static string AdminHashKey="6e93e549b7140ec74ade7f56aff807f19b7dec5fea37e57902e91286f3b27d64";
        public static string ManagementHashKey="f0af9bc36847bc8334ffd57cab4cff0d080116b4463d788bce2fe22c5e8bc01f";
        public static string InterviewerHashKey="3fc90e88bbe900077c96b0253ce7d279ac5646ac5d8335dea8ea9e4f98c6c582";

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

        public static object Response(string responseMessage)
        {
            return new{message = responseMessage};
        }
        
    }
}