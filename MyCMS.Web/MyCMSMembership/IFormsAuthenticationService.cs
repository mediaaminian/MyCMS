using MyCMS.DomainClasses.Entities;

namespace MyCMS.Web.MyCMSMembership
{
    public interface IFormsAuthenticationService
    {
        void SignIn(User user, bool createPersistentCookie);
        void SignOut();
    }
}