using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCMS.DomainClasses.Entities
{
    public class ProductTypeGroupTimeFrame
    {
        public int Id { get; set; }
		public byte Status { get; set; }

        [ForeignKey("ProductTypeGroupId")]
        public virtual ProductTypeGroup ProductTypeGroup { get; set; }
        public int? ProductTypeGroupId { get; set; }


        [ForeignKey("TimeFrameId")]
        public virtual TimeFrame TimeFrame { get; set; }
        public int? TimeFrameId { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}