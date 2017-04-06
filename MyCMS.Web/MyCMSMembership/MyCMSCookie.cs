using System.Collections.Generic;

namespace MyCMS.Web.MyCMSMembership
{
    public class MyCMSCookie
    {
        public MyCMSCookie()
        {
            Roles = new List<string>();
        }

        public string UserName { get; set; }
        //public string Email { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string TimeZone { get; set; }
        public List<string> Roles { get; set; }
        public bool RememberMe { get; set; }
    }
}