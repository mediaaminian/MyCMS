using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class SliderConfig : EntityTypeConfiguration<Slider>
    {
        public SliderConfig()
        {
            //one-to-one
            //this.HasOptional(x => x.Book).WithRequired(x => x.Slider).WillCascadeOnDelete();
            HasOptional(x => x.User).WithMany(x => x.Sliders).HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);

            Property(x => x.Priority).IsRequired();
            Property(x => x.Picture).IsRequired();
            Property(x => x.Link).HasMaxLength(500);
            Property(x => x.RowVersion).IsRowVersion();
            Property(x => x.Title).HasMaxLength(200).IsRequired();
        }
    }
}