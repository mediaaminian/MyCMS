using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class ProductTypeGroupTimeFrameConfig : EntityTypeConfiguration<ProductTypeGroupTimeFrame>
    {
        public ProductTypeGroupTimeFrameConfig()
        {
            HasKey(t => t.Id);
            HasRequired(t => t.ProductTypeGroup).WithMany(t => t.ProductTypeGroupTimeFrames);
            HasRequired(t => t.TimeFrame).WithMany(t => t.ProductTypeGroupTimeFrames);
            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}