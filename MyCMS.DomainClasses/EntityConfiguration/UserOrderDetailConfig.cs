using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class UserOrderDetailConfig : EntityTypeConfiguration<UserOrderDetail>
    {
        public UserOrderDetailConfig()
        {
            HasKey(t => t.Id);
            Property(t => t.Description).HasMaxLength(1000);
            Property(t => t.ServiceName).HasMaxLength(50);
            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}