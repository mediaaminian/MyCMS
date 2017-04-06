﻿using System.Web.Mvc;

namespace MyCMS.Model.AdminModel
{
    public class EditPageModel
    {
        public int Id { get; set; }
        public virtual string Title { get; set; }

        [AllowHtml]
        public virtual string Body { get; set; }
        public virtual string SubTitle { get; set; }
        public virtual string IconClass { get; set; }
        public virtual string FeatureImage { get; set; }
        public virtual string ExternalLink { get; set; }
        public virtual string Keyword { get; set; }
        public virtual string Description { get; set; }
        public virtual string Status { get; set; }
        public virtual bool CommentStatus { get; set; }
        public virtual int? Order { get; set; }
        public virtual int? ParentId { get; set; }
    }
}