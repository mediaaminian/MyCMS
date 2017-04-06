using System;
using System.Collections.Generic;

namespace MyCMS.DomainClasses.Entities
{
    public class ProductTypeGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public string AppKey { get;set; }
		public int Priority { get;set; }
        public bool IsService { get; set; }
        public bool IsAvailableToOrder { get; set; }
        public string Picture { get; set; }
		public string Brief { get;set; }
        public string Description { get; set; }

        //[System.ComponentModel.DataAnnotations.Schema.ForeignKey("TimeFrameID")]
        public virtual TimeFrame TimeFrame { get; set; }
        //public int  TimeFrameID { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductType> ProductTypes { get; set; }
        public virtual ICollection<ProductTypeGroupTimeFrame> ProductTypeGroupTimeFrames { get; set; }
        public virtual ICollection<PropertyGroup> PropertyGroups { get; set; }
        public virtual byte[] RowVersion { get; set; }
    }
}