using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AssignmentAdded = "Assignment Added";
        public static string AssignmentDeleted = "Assignment Deleted";
        public static string AssignmentUpdated = "Assignment Updated";
        public static string AssignmentListed = "Assignmen t Listed";

        public static string UserRegistered = "User Registered";

        public static string UserAlreadyExists = "User Already Exists";
        internal static string UserNotExists = "User Not Exists";
        internal static string WrongData = "Wrong User Data";
        internal static string SuccessfulLogin = "SuccessfulLogin";
        internal static string AccessTokenCreated = "AccessTokenCreated";
    }
}
