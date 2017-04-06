using MyCMS.Model;

namespace MyCMS.Web.Caching
{
    public interface ICacheService
    {
        SiteConfig GetSiteConfig();
        void RemoveSiteConfig();
    }
}