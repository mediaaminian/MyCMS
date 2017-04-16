using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class InvoiceConfig : EntityTypeConfiguration<Invoice>
    {
        public InvoiceConfig()
        {
            HasKey(t => t.Id);
            HasOptional(x => x.UserOrder).WithMany(x => x.Invoices).HasForeignKey(x=>x.UserOrderId).WillCascadeOnDelete(false);
            HasOptional(x => x.User).WithMany(x => x.Invoices).HasForeignKey(x=>x.UserId).WillCascadeOnDelete(false);
            Property(t => t.Description).HasMaxLength(200);
            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}