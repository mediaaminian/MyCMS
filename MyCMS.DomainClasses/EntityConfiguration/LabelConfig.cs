using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class LabelConfig : EntityTypeConfiguration<Label>
    {
        public LabelConfig()
        {
            Property(x => x.Name).HasMaxLength(200);
            Property(x => x.Description).HasMaxLength(1000);
        }
    }
}