#region

using System.Security.Principal;
using System.Web;
using System.Web.Security;

#endregion

namespace MyCMS.Web.MyCMSMembership
{
    public class MyCMSSupportPrincipalService : IPrincipalService
    {
        private readonly HttpContextBase _context;

        public MyCMSSupportPrincipalService(HttpContextBase context)
        {
            _context = context;
        }

        #region IPrincipalService Members

        public IPrincipal GetCurrent()
        {
            IPrincipal user = _context.User;
            // if they are already signed in, and conversion has happened
            if (user != null && user is MyCMSPrincipal)
                return user;

            // if they are signed in, but conversion has still not happened
            if (user == null || !user.Identity.IsAuthenticated || !(user.Identity is FormsIdentity))
                return new MyCMSPrincipal(new MyCMSIdentity((FormsAuthenticationTicket) null));
            var id = (FormsIdentity) _context.User.Identity;

            FormsAuthenticationTicket ticket = id.Ticket;
            if (FormsAuthentication.SlidingExpiration)
                ticket = FormsAuthentication.RenewTicketIfOld(ticket);

            var fid = new MyCMSIdentity(ticket);
            return new MyCMSPrincipal(fid);

            // not sure what's happening, let's just default here to a Guest
        }

        #endregion
    }
}