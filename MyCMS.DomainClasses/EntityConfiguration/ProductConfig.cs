using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class ProductConfig : EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
            HasKey(t => t.Id);
            HasOptional(x => x.ProductType).WithMany(x => x.Products).HasForeignKey(x => x.ProductTypeId).WillCascadeOnDelete(false);
            HasOptional(x => x.ProductTypeGroup).WithMany(x => x.Products).HasForeignKey(x => x.ProductTypeGroupId).WillCascadeOnDelete(false);
            HasOptional(x => x.User).WithMany(x => x.Products).HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
            Property(t => t.Name).IsRequired().HasMaxLength(200);
            Property(t => t.Brief).HasMaxLength(4000);
            Property(t => t.Description).HasMaxLength(4000);
            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}