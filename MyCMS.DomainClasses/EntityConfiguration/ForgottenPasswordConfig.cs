using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class ForgottenPasswordConfig : EntityTypeConfiguration<ForgottenPassword>
    {
        public ForgottenPasswordConfig()
        {
            Property(x => x.Key).HasMaxLength(40);
        }
    }
}