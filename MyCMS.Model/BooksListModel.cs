﻿using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.Model
{
    public class BooksListModel
    {
        public int PostId { get; set; }
        public string BookName { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int LikeCount { get; set; }
        public ICollection<Label> Lables { get; set; }
        public string Body { get; set; }
        public string ImageTitle { get; set; }
        public string ImageDescription { get; set; }
        public string ImagePath { get; set; }
        public int VisitedCount { get; set; }
        public int CommentsCount { get; set; }
    }
}