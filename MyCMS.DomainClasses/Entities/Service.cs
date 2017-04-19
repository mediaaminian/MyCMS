using System;
using System.Collections.Generic;

namespace MyCMS.DomainClasses.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public System.DateTime StartDate { get;set; }
		public System.DateTime EndDate { get;set; }
        public string Picture { get; set; }
		public string Brief { get;set; }
        public string Description { get; set; }
		public string OrderDescription { get;set; }
		public bool IsExtra { get;set; }
        public Nullable<bool> IsSpecial { get; set; }
		public Nullable<bool> AutoRenew { get;set; }
		public int TempActivationCount { get;set; }
		public Nullable<System.DateTime> TempExpireTime { get;set; }
        public byte Status { get;set; }
        public virtual Product Product { get; set; }
        public virtual UserOrderDetail OrderDetail { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual ProductTypeGroup ProductTypeGroup { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual User User { get; set; }
        public virtual User EditedByUser { get; set; }
        public virtual byte[] RowVersion { get; set; }
    }
}