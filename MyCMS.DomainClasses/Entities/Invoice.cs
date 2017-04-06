using System;
using System.Collections.Generic;

namespace MyCMS.DomainClasses.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int PrintNumber { get; set; }
        public bool Paid { get; set; }
        public string Description { get; set; }
        public byte Status { get;set; }
        public virtual UserOrder Order { get; set; }
        public virtual byte[] RowVersion { get; set; }
    }
}