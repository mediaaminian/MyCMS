using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class TimeFrameConfig : EntityTypeConfiguration<TimeFrame>
    {
        public TimeFrameConfig()
        {
            HasKey(t => t.Id);
            Property(t => t.Title).IsRequired().HasMaxLength(200);
            Property(t => t.Days).IsRequired();
            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}