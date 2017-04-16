using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCMS.DomainClasses.Entities
{
    public enum PostStatus
    {
        Hidden,
        Visible,
        Draft,
    }

    public class Page
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string SubTitle { get; set; }
        public virtual string IconClass { get; set; }
        public virtual int Priority { get; set; }
        public virtual string FeatureImage { get; set; }
        public virtual string ExternalLink { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string Body { get; set; }
        public virtual string Keyword { get; set; }
        public virtual string Description { get; set; }
        public virtual string Status { get; set; }
        public virtual bool CommentStatus { get; set; }
        public virtual int VisitedCount { get; set; }
        public virtual int LikeCount { get; set; }
        public virtual int? Order { get; set; }
        public virtual User User { get; set; }
        public virtual User EditedByUser { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        [ForeignKey("ParentId")]
        public virtual Page Parent { get; set; }
        public virtual int? ParentId { get; set; }

        public virtual ICollection<Page> Children { get; set; }
        public virtual ICollection<User> LikedUsers { get; set; }
    }
}