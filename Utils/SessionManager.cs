using AIUBBusManagementSystem.Models;

namespace AIUBBusManagementSystem.Utils
{
    internal class SessionManager
    {
        public static User CurrentUser { get; private set; }

        public static void StartSession(User user)
        {
            CurrentUser = user;
        }

        public static void EndSession()
        {
            CurrentUser = null;
        }

        public static bool IsLoggedIn()
        {
            return CurrentUser != null;
        }

        public static bool IsAdmin()
        {
            return CurrentUser != null && CurrentUser.Role == "Admin";
        }

        public static bool IsDriver()
        {
            return CurrentUser != null && CurrentUser.Role == "Driver";
        }

        public static bool IsStudent()
        {
            return CurrentUser != null && CurrentUser.Role == "Student";
        }
    }
}