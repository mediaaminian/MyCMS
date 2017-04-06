using System.Collections.Generic;
using MyCMS.Datalayer.Context;
using MyCMS.Model;
using MyCMS.Servicelayer.EFServices;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Web.Helpers;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Extensibility;

namespace MyCMS.Web.Sitemap
{
    public class PostDetailsDynamicNodeProvider : DynamicNodeProviderBase
    {
        private readonly IPostService _postService;

        public PostDetailsDynamicNodeProvider()
        {
            _postService = new PostService(new MyCMSDbContext());
        }

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection()
        {
            var returnValue = new List<DynamicNode>();

            foreach (SiteMapModel post in _postService.GetSiteMapData(20))
            {
                var node = new DynamicNode
                {
                    Title = post.Title,
                    Controller = "Post",
                    Action = "Index",
                    Area = "",
                    LastModifiedDate = post.ModifiedDate ?? post.CreatedDate,
                    ChangeFrequency = ChangeFrequency.Daily,
                    UpdatePriority = UpdatePriority.Absolute_050,
                };
                node.RouteValues.Add("id", post.Id);
                node.RouteValues.Add("title", UrlExtensions.ResolveTitleForUrl(node.Title));
                returnValue.Add(node);
            }

            // Return 
            return returnValue;
        }
    }
}