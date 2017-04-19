using System;
using System.Collections.Generic;

namespace MyCMS.DomainClasses.Entities
{    
    public class UserOrderDetail
    {
        public int Id { get; set; }

		public Nullable<bool> IsExtra { get;set; }

		public double Fee { get;set; }
		public string Title { get;set; }
        public string Description { get; set; }
        public byte OperationType { get; set; }
        public string ServiceName { get; set; }
        public virtual UserOrder Order { get; set; }
        public virtual ICollection<UserOrderDetail> OrderDetails { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual ProductTypeGroup ProductTypeGroup { get; set; }
        public virtual TimeFrame TimeFrame { get; set; }
        public virtual ICollection<Service> Services { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual User User { get; set; }
        public virtual User EditedByUser { get; set; }
        public virtual byte[] RowVersion { get; set; }
    }
}