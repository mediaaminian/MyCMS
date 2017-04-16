using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class PropertyConfig : EntityTypeConfiguration<Property>
    {
        public PropertyConfig()
        {
            HasKey(t => t.Id);
            HasOptional(x => x.PropertyGroup).WithMany(x => x.Properties).HasForeignKey(x => x.PropertyGroupId).WillCascadeOnDelete(false);
            Property(t => t.Name).IsRequired().HasMaxLength(200);
            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}