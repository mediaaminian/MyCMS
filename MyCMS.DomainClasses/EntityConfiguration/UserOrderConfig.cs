using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class UserOrderConfig : EntityTypeConfiguration<UserOrder>
    {
        public UserOrderConfig()
        {
            HasKey(t => t.Id);
            Property(t => t.Country).HasMaxLength(50);
            Property(t => t.City).HasMaxLength(50);
            Property(t => t.Address).HasMaxLength(500);
            Property(t => t.FirstName).HasMaxLength(50);
            Property(t => t.LastName).HasMaxLength(50);
            Property(t => t.Tel).HasMaxLength(50);
            Property(t => t.Mobile).HasMaxLength(50);
            Property(t => t.Email).HasMaxLength(100);
            Property(t => t.PostalCode).HasMaxLength(50);
            Property(t => t.Description).HasMaxLength(500);
            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}