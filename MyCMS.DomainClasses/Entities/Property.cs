using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCMS.DomainClasses.Entities
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public int Priority { get;set; }
        public bool IsVisibleInProductDetail { get; set; }
        public bool IsVisibleInNotification { get; set; }
        public bool IsVisibleInAdvertisements { get; set; }
        public bool IsFilterable { get; set; }
        public byte DataType { get; set; }
        public string DefaultValue { get; set; }

        public string Description { get; set; }
		public byte Status { get;set; }
        public virtual ICollection<ProductProperty> ProductProperties { get; set; }

        [ForeignKey("PropertyGroupId")]
        public virtual PropertyGroup PropertyGroup { get; set; }
        public int? PropertyGroupId { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}