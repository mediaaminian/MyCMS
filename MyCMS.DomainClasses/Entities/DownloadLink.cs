﻿namespace MyCMS.DomainClasses.Entities
{
    public class DownloadLink
    {
        public virtual int Id { get; set; }
        public virtual string Link { get; set; }
        public virtual string FileSize { get; set; }
        public virtual string FileFormat { get; set; }
        public virtual Post Post { get; set; }
    }
}