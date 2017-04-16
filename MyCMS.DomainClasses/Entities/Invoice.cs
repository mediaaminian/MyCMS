using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCMS.DomainClasses.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int PrintNumber { get; set; }
        public bool Paid { get; set; }
        public string Description { get; set; }
        public byte Status { get;set; }

        [ForeignKey("UserOrderId")]
        public virtual UserOrder UserOrder { get; set; }
        public int? UserOrderId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int? UserId { get; set; }


        //[ForeignKey("EditedByUserId")]
        //public virtual User EditedByUser { get; set; }
        //public int? EditedByUserId { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}