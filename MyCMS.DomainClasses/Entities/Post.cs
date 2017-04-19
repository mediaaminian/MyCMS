﻿using System;
using System.Collections.Generic;

namespace MyCMS.DomainClasses.Entities
{
    public enum PageStatus
    {
        Hidden,
        Visible,
        Draft,
        Archive
    }

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Keyword { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // visible hidden draft archive
        public bool? CommentStatus { get; set; }
        public string Body { get; set; }
        public int VisitedNumber { get; set; }
        public int Like { get; set; }
        //public virtual Book Book { get; set; }
        public virtual User User { get; set; }
        public virtual User EditedByUser { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Label> Labels { get; set; }
        //public virtual ICollection<DownloadLink> DownloadLinks { get; set; }
        //public virtual ICollection<User> LikedUsers { get; set; }
        public virtual byte[] RowVersion { get; set; }
    }
}