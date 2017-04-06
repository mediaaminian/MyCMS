using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class CurrencyConfig : EntityTypeConfiguration<Currency>
    {
        public CurrencyConfig()
        {
            //one-to-one
            //this.HasOptional(x => x.Book).WithRequired(x => x.Currency).WillCascadeOnDelete();
           
            Property(x => x.Priority).IsRequired();
            Property(x => x.Price).IsRequired();
            Property(x => x.Icon).IsRequired();
            Property(x => x.Keyword).HasMaxLength(500).IsRequired();
            Property(x => x.RowVersion).IsRowVersion();
            Property(x => x.Title).HasMaxLength(200).IsRequired();
        }
    }
}