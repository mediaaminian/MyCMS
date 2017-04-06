using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class MessageAnswareConfig : EntityTypeConfiguration<MessageAnsware>
    {
        public MessageAnswareConfig()
        {
            Property(x => x.Body).IsMaxLength();
        }
    }
}