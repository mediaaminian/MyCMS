using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class PostConfig : EntityTypeConfiguration<Post>
    {
        public PostConfig()
        {
            //one-to-one
            //this.HasOptional(x => x.Book).WithRequired(x => x.Post).WillCascadeOnDelete();
            //HasOptional(x => x.Book).WithRequired(x => x.Post).WillCascadeOnDelete(true);
            //HasMany(x => x.DownloadLinks).WithOptional(x => x.Post).WillCascadeOnDelete(true);

            //HasMany(x => x.LikedUsers).WithMany(x => x.LikedPosts).Map(x =>
            //{
            //    x.ToTable("LikeUsersPosts");
            //    x.MapLeftKey("PostId");
            //    x.MapRightKey("UserId");
            //});
            Property(x => x.Body).IsMaxLength().IsOptional();
            Property(x => x.Description).HasMaxLength(400).IsOptional();
            Property(x => x.Keyword).HasMaxLength(500).IsOptional();
            Property(x => x.RowVersion).IsRowVersion();
            Property(x => x.Title).HasMaxLength(200).IsRequired();
            Property(x => x.Picture).HasMaxLength(2000).IsRequired();
        }
    }
}