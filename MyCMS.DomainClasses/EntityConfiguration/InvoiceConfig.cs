using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class InvoiceConfig : EntityTypeConfiguration<Invoice>
    {
        public InvoiceConfig()
        {
            HasKey(t => t.Id);
            Property(t => t.Description).HasMaxLength(200);
            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}