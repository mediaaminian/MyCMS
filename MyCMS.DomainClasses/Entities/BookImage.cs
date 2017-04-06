﻿using System;

namespace MyCMS.DomainClasses.Entities
{
    public class BookImage
    {
        public virtual long Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Path { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? UploadedDate { get; set; }
        public virtual Book Book { get; set; }
    }
}