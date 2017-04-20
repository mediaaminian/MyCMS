using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCMS.DomainClasses.Entities
{    
    public class UserOrder
    {
        public int Id { get; set; }

        public bool IsGuest { get; set; }

        public string Country { get; set; }
        public string City { get; set; }

        public string Address { get; set; }
        public byte Status { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public Nullable<double> PayableAmount { get; set; }
        public Nullable<double> TotalAmount { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<UserOrderDetail> OrderDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }


        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int? UserId { get; set; }


        //[ForeignKey("EditedByUserId")]
        //public virtual User EditedByUser { get; set; }
        //public int EditedByUserId { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}