using System;
using System.Linq;
using System.Security.Principal;

namespace MyCMS.Web.MyCMSMembership
{
    public class MyCMSPrincipal : IPrincipal
    {
        private readonly MyCMSIdentity _identity;

        public MyCMSPrincipal(MyCMSIdentity identity)
        {
            _identity = identity;
        }

        #region IPrincipal Members

        public bool IsInRole(string role)
        {
            return
                _identity.Roles.Any(
                    current => string.Compare(current, role, StringComparison.InvariantCultureIgnoreCase) == 0);
        }

        public IIdentity Identity
        {
            get { return _identity; }
        }

        public MyCMSIdentity Information
        {
            get { return _identity; }
        }

        public bool IsUser
        {
            get { return !IsGuest; }
        }

        public bool IsGuest
        {
            get { return IsInRole("guest"); }
        }

        #endregion
    }
}