using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCMS.DomainClasses.Entities
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public int Priority { get;set; }
        public bool IsService { get; set; }
        public string Picture { get; set; }
		public string Brief { get;set; }
        public string Description { get; set; }
		public int TrialDay { get;set; }
		public double CancelAmount { get;set; }
		public int MoneyBackDay { get;set; }
		public bool IsCancelable { get;set; }

        [ForeignKey("ProductTypeGroupId")]
        public virtual ProductTypeGroup ProductTypeGroup { get; set; }
        public int? ProductTypeGroupId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<UserOrderDetail> OrderDetails { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}