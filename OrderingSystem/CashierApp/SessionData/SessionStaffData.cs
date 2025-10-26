using System.Drawing;
using OrderingSystem.Model;

namespace OrderingSystem.CashierApp.SessionData
{
    public class SessionStaffData
    {

        public static StaffModel StaffData { get; set; }
        public static int StaffId { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string Role { get; set; }
        public static Image Image { get; set; }

    }
}
