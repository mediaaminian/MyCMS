using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.Model.AdminModel
{
    public class PostDataTableModel
    {
        public int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Picture { get; set; }
        public DateTime PostedDate { get; set; }
        public virtual string Status { get; set; }
        public virtual bool? CommentStatus { get; set; }
        public virtual string PostAuthor { get; set; }
        public virtual string Description { get; set; }
        public virtual int VisitedNumber { get; set; }
        public virtual ICollection<Label> labels { get; set; }
    }
}