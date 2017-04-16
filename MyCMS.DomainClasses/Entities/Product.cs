using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCMS.DomainClasses.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public int Priority { get;set; }
        public string Picture { get; set; }
		public string Brief { get;set; }
        public string Description { get; set; }
		public string OrderDescription { get;set; }
		public bool IsExtra { get;set; }
        public bool IsSpecial { get; set; }
        public byte Status { get;set; }
        public virtual ICollection<UserOrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductProperty> ProductProperties { get; set; }
        public virtual ICollection<Service> Services { get; set; }

        [ForeignKey("ProductTypeId")]
        public virtual ProductType ProductType { get; set; }
        public int? ProductTypeId { get; set; }

        [ForeignKey("ProductTypeGroupId")]
        public virtual ProductTypeGroup ProductTypeGroup { get; set; }
        public int? ProductTypeGroupId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int? UserId { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}