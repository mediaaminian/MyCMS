﻿using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel.Syndication;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;

// Add a ref. to System.ServiceModel.dll asm.
// Add a ref. to System.Web.dll asm.
// Add a ref. to C:\Program Files\Microsoft ASP.NET\ASP.NET MVC 4\Assemblies\System.Web.Mvc.dll asm.

namespace MyCMS.Web.RSS
{
    public class FeedResult : ActionResult
    {
        private readonly List<SyndicationItem> _allItems;
        private readonly string _feedTitle;
        private readonly string _language;

        public FeedResult(string feedTitle, IEnumerable<FeedItem> rssItems, string language = "fa-IR")
        {
            _feedTitle = feedTitle;
            _allItems = mapToSyndicationItem(rssItems);
            _language = language;
        }

        private static List<SyndicationItem> mapToSyndicationItem(IEnumerable<FeedItem> rssItems)
        {
            var results = new List<SyndicationItem>();
            foreach (FeedItem item in rssItems)
            {
                var uri = new Uri(item.Url);
                var feedItem = new SyndicationItem(item.Title.CorrectRtl(),
                    SyndicationContent.CreateHtmlContent(item.Content.CorrectRtlBody()), uri, item.Url.SHA1(),
                    item.LastUpdatedTime
                    ) { PublishDate = item.PublishDate };
                feedItem.Authors.Add(new SyndicationPerson(item.AuthorName, item.AuthorName, uri.Host));
                results.Add(feedItem);
            }
            return results;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            writeToResponse(context.HttpContext);
        }

        private void writeToResponse(HttpContextBase httpContext)
        {
            var feed = new SyndicationFeed
            {
                Title = new TextSyndicationContent(_feedTitle.CorrectRtl()),
                Language = _language,
                Items = _allItems
            };
            addChannelLinks(httpContext, feed);

            string feedData = syndicationFeedToString(feed);
            // Interoperability with feed readers could be improved by avoiding Namespace Prefix: a10
            feedData = feedData.Replace("xmlns:a10", "xmlns:atom").Replace("a10:", "atom:");

            HttpResponseBase response = httpContext.Response;
            response.ContentEncoding = Encoding.UTF8;
            response.ContentType = "application/rss+xml";
            response.Write(feedData);
            response.End();
        }

        private static void addChannelLinks(HttpContextBase httpContext, SyndicationFeed feed)
        {
            // Improved interoperability with feed readers by implementing atom:link with rel="self"
            Uri baseUrl = new UriBuilder(httpContext.Request.Url.Scheme, httpContext.Request.Url.Host).Uri;
            var feedLink = new Uri(baseUrl, httpContext.Request.RawUrl);
            feed.Links.Add(SyndicationLink.CreateSelfLink(feedLink));
            feed.Links.Add(new SyndicationLink { Uri = baseUrl, RelationshipType = "alternate" });
        }

        private static string syndicationFeedToString(SyndicationFeed feed)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (XmlWriter rssWriter = XmlWriter.Create(memoryStream, new XmlWriterSettings { Indent = true }))
                {
                    var formatter3 = new Rss20FeedFormatter(feed);
                    formatter3.WriteTo(rssWriter);
                    rssWriter.Close();
                }
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }
    }
}