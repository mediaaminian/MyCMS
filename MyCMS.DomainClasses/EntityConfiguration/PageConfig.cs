using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class PageConfig : EntityTypeConfiguration<Page>
    {
        public PageConfig()
        {
            // Self reference entity
            HasOptional(x => x.Parent).WithMany(x => x.Children).HasForeignKey(x => x.ParentId);
            HasOptional(x => x.EditedByUser).WithMany(x => x.Pages).WillCascadeOnDelete(false);
            HasMany(x => x.LikedUsers).WithMany(x => x.LikedPages).Map(x =>
            {
                x.ToTable("LikeUsersPages");
                x.MapLeftKey("PageId");
                x.MapRightKey("UserId");
            });
            Property(x => x.Body).IsMaxLength();
            Property(x => x.Description).HasMaxLength(400);
            Property(x => x.Keyword).HasMaxLength(100);
            Property(x => x.Status).HasMaxLength(10);
            Property(x => x.Title).HasMaxLength(200).IsRequired();
            Property(x => x.SubTitle).HasMaxLength(200);
            Property(x => x.IconClass).HasMaxLength(40);
            Property(x => x.ExternalLink).HasMaxLength(1200);
            Property(x => x.FeatureImage).HasMaxLength(1200);
        }
    }
}