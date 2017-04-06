using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class ArticleConfig : EntityTypeConfiguration<Article>
    {
        public ArticleConfig()
        {
            HasOptional(x => x.EditedByUser).WithMany(x => x.Articles).WillCascadeOnDelete(false);
            HasMany(x => x.LikedUsers).WithMany(x => x.LikedArticles).Map(x =>
            {
                x.ToTable("LikeUsersArticles");
                x.MapLeftKey("ArticleId");
                x.MapRightKey("UserId");
            });
            Property(x => x.Body).IsMaxLength();
            Property(x => x.Description).HasMaxLength(400);
            Property(x => x.Keyword).HasMaxLength(100);
            Property(x => x.Status).HasMaxLength(10);
            Property(x => x.Title).HasMaxLength(200);
        }
    }
}