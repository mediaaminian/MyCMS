using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class MessageConfig : EntityTypeConfiguration<Message>
    {
        public MessageConfig()
        {
            Property(x => x.Body).IsMaxLength();
            Property(m => m.Subject).HasMaxLength(500);
        }
    }
}