using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class PropertyGroupConfig : EntityTypeConfiguration<PropertyGroup>
    {
        public PropertyGroupConfig()
        {

            HasKey(t => t.Id);
            HasOptional(x => x.ProductTypeGroup).WithMany(x=>x.PropertyGroups).HasForeignKey(x => x.ProductTypeGroupId).WillCascadeOnDelete(false);
            Property(t => t.Name).IsRequired().HasMaxLength(200);
            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}