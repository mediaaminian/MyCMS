using System;
using System.Collections.Generic;

namespace MyCMS.DomainClasses.Entities
{
    public class TimeFrame
    {
        public int Id { get; set; }
        public string Title { get; set; }
		public byte Status { get;set; }
		public byte Days { get;set; }
		public int Priority { get;set; }
        public string Picture { get; set; }
        public string Link { get; set; }
        public virtual ICollection<ProductTypeGroupTimeFrame> ProductTypeGroupTimeFrames { get; set; }
        public virtual byte[] RowVersion { get; set; }
    }
}