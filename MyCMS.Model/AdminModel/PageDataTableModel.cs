﻿using System;

namespace MyCMS.Model.AdminModel
{
    public class PageDataTableModel
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string SubTitle { get; set; }
        public virtual string IconClass { get; set; }
        public virtual string FeatureImage { get; set; }
        public virtual string ExternalLink { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual string Status { get; set; }
        public virtual bool? CommentStatus { get; set; }
        public int CommentCount { get; set; }
        public int? ParentId { get; set; }
        public string ParentTitle { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
    }
}