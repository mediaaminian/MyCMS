using System;
using System.Configuration;
using System.Web;
using MyCMS.Model;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Web.Infrastructure;

namespace MyCMS.Web.Caching
{
    public class CacheService : ICacheService
    {
        public const string SiteConfigKey = "SiteConfig";

        private readonly HttpContextBase _httpContext;
        private readonly IOptionService _optionService;

        public CacheService(HttpContextBase httpContext, IOptionService optionService)
        {
            _httpContext = httpContext;
            _optionService = optionService;
        }

        public SiteConfig GetSiteConfig()
        {
            var siteConfig = _httpContext.CacheRead<SiteConfig>(SiteConfigKey);
            var durationMinutes =
                Convert.ToInt32(ConfigurationManager.AppSettings["CacheOptionsDuration"]);

            if (siteConfig != null) return siteConfig;

            siteConfig = _optionService.GetAll();
            _httpContext.CacheInsert(SiteConfigKey, siteConfig, durationMinutes);

            return siteConfig;
        }

        public void RemoveSiteConfig()
        {
            _httpContext.InvalidateCache(SiteConfigKey);
        }

    }
}