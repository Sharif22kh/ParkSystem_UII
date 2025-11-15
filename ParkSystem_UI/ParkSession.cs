namespace ParkSystem_UI
{
    
    public static class ParkSession
    {
        public static int? LoggedInVisitorID { get; private set; }
        public static string LoggedInVisitorName { get; private set; }

        public static void Login(int visitorID, string name)
        {
            LoggedInVisitorID = visitorID;
            LoggedInVisitorName = name;
        }

        public static void Logout()
        {
            LoggedInVisitorID = null;
            LoggedInVisitorName = null;
        }

        public static bool IsLoggedIn()
        {
            return LoggedInVisitorID.HasValue;
        }
    }
}