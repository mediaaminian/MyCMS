using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class OptionConfig : EntityTypeConfiguration<Option>
    {
        public OptionConfig()
        {
            Property(option => option.Name).HasMaxLength(100);
            Property(option => option.Value).HasMaxLength(100);
        }
    }
}