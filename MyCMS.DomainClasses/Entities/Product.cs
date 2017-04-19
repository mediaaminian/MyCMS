using System;
using System.Collections.Generic;

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
        public int ProductTypeID { get; set; }
        public virtual ProductType ProductType { get; set; }
        public int ProductTypeGroupID { get; set; }

        public virtual ProductTypeGroup ProductTypeGroup { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int UserID { get; set; }

        public virtual User User { get; set; }
        //public int EditedByUserID { get; set; }

        //public virtual User EditedByUser { get; set; }
        public virtual byte[] RowVersion { get; set; }
    }
}