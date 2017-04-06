using System;
using System.Configuration;
using System.Web;
using MyCMS.Model;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Web.Infrastructure;

namespace MyCMS.Web.Caching
{
    public class MyCMSCache
    {
        public const string SiteConfigKey = "SiteConfig";

        public static SiteConfig GetSiteConfig(HttpContextBase httpContext, IOptionService optionService)
        {
            var siteConfig = httpContext.CacheRead<SiteConfig>(SiteConfigKey);
            int durationMinutes =
                Convert.ToInt32(ConfigurationManager.AppSettings["CacheOptionsDuration"]);

            if (siteConfig == null)
            {
                siteConfig = optionService.GetAll();
                httpContext.CacheInsert(SiteConfigKey, siteConfig, durationMinutes);
            }
            return siteConfig;
        }

        public static void RemoveSiteConfig(HttpContextBase httpContext)
        {
            httpContext.InvalidateCache(SiteConfigKey);
        }
    }
}