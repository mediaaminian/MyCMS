using System;
using System.Collections.Generic;

namespace MyCMS.DomainClasses.Entities
{
    public class ProductTypeGroupTimeFrame
    {
        public int Id { get; set; }
		public byte Status { get; set; }
        public int ProductTypeGroupID { get; set; }
        public virtual ProductTypeGroup ProductTypeGroup { get; set; }
        public int TimeFrameID { get; set; }

        public virtual TimeFrame TimeFrame { get; set; }
        public virtual byte[] RowVersion { get; set; }
    }
}