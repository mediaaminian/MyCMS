using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class ProductTypeConfig : EntityTypeConfiguration<ProductType>
    {
        public ProductTypeConfig()
        {
            HasKey(t => t.Id);
            Property(t => t.Name).IsRequired().HasMaxLength(200);
            Property(t => t.Brief).HasMaxLength(4000);
            Property(t => t.Description).HasMaxLength(4000);
            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}