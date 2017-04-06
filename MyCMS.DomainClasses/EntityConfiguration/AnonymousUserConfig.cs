using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class AnonymousUserConfig : EntityTypeConfiguration<AnonymousUser>
    {
        public AnonymousUserConfig()
        {
            //HasOptional(x => x.Comment).WithRequired(x => x.AnonymousUser).WillCascadeOnDelete(true);
            Property(x => x.Name).HasMaxLength(20);
            Property(x => x.Email).HasMaxLength(50);
            Property(x => x.IP).HasMaxLength(50);
        }
    }
}