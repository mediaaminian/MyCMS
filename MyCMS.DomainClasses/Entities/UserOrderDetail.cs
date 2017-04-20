using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("UserOrderId")]
        public virtual UserOrder UserOrder { get; set; }
        public int? UserOrderId { get; set; }
        public System.Byte Status { get; set; }

        public virtual ICollection<UserOrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Service> Services { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int? ProductId { get; set; }

        [ForeignKey("ProductTypeId")]
        public virtual ProductType ProductType { get; set; }
        public int? ProductTypeId { get; set; }

        [ForeignKey("ProductTypeGroupId")]
        public virtual ProductTypeGroup ProductTypeGroup { get; set; }
        public int? ProductTypeGroupId { get; set; }

        [ForeignKey("TimeFrameId")]
        public virtual TimeFrame TimeFrame { get; set; }
        public int? TimeFrameId { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }
        public int? ServiceId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }


        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int? UserId { get; set; }


        [ForeignKey("EditedByUserId")]
        public virtual User EditedByUser { get; set; }
        public int? EditedByUserId { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}