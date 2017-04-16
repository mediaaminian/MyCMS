using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class ProductPropertyConfig : EntityTypeConfiguration<ProductProperty>
    {
        public ProductPropertyConfig()
        {
            HasKey(t => t.Id);
            HasOptional(x => x.Product).WithMany(x => x.ProductProperties).HasForeignKey(x => x.ProductId).WillCascadeOnDelete(false);
            HasOptional(x => x.Property).WithMany(x => x.ProductProperties).HasForeignKey(x => x.PropertyId).WillCascadeOnDelete(false);
            //HasRequired(t => t.Product).WithMany(t => t.ProductProperties);
            //HasRequired(t => t.Property).WithMany(t => t.ProductProperties);
            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}