using System.Security.Principal;

namespace MyCMS.Web.MyCMSMembership
{
    public interface IPrincipalService
    {
        IPrincipal GetCurrent();
    }
}