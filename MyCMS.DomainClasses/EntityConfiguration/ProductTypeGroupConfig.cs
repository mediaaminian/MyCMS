using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class ProductTypeGroupConfig : EntityTypeConfiguration<ProductTypeGroup>
    {
        public ProductTypeGroupConfig()
        {
            HasKey(t => t.Id);
            Property(t => t.Name).IsRequired().HasMaxLength(200);

            Property(x => x.RowVersion).IsRowVersion();
            
            
        }
    }
}