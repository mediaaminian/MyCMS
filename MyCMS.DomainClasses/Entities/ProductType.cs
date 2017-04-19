using System;
using System.Collections.Generic;

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

        //public int ProductTypeGroupID { get; set; }
        public virtual ProductTypeGroup ProductTypeGroup { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}