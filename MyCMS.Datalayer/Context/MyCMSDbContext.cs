using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using MyCMS.DomainClasses;
using MyCMS.DomainClasses.Entities;
using MyCMS.DomainClasses.EntityConfiguration;
using EFSecondLevelCache;
using System.Linq;

namespace MyCMS.Datalayer.Context
{
    public class MyCMSDbContext : DbContext, IUnitOfWork
    {
        public DbSet<TimeFrame> TimeFrame { get; set; }
        public DbSet<PropertyGroup> PropertyGroup { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<ProductTypeGroup> ProductTypeGroup { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ProductTypeGroupTimeFrame> ProductTypeGroupTimeFrame { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<UserOrder> Order { get; set; }
        public DbSet<UserOrderDetail> OrderDetail { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookImage> BookImages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageAnsware> MessageAnswares { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserMetaData> UserMetaDatas { get; set; }
        public DbSet<AnonymousUser> AnnonymousUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<ForgottenPassword> ForgottenPasswords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new TimeFrameConfig());
            modelBuilder.Configurations.Add(new PropertyGroupConfig());
            modelBuilder.Configurations.Add(new PropertyConfig());
            modelBuilder.Configurations.Add(new ProductTypeGroupConfig());
            modelBuilder.Configurations.Add(new ProductTypeConfig());
            modelBuilder.Configurations.Add(new ProductTypeGroupTimeFrameConfig());
            modelBuilder.Configurations.Add(new ProductConfig());
            modelBuilder.Configurations.Add(new UserOrderConfig());
            modelBuilder.Configurations.Add(new UserOrderDetailConfig());
            modelBuilder.Configurations.Add(new ServiceConfig());
            modelBuilder.Configurations.Add(new InvoiceConfig());
            modelBuilder.Configurations.Add(new BookConfig());
            modelBuilder.Configurations.Add(new BookImageConfig());
            modelBuilder.Configurations.Add(new CommentConfig());
            modelBuilder.Configurations.Add(new LabelConfig());
            modelBuilder.Configurations.Add(new PageConfig());
            modelBuilder.Configurations.Add(new ArticleConfig());
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new MessageConfig());
            modelBuilder.Configurations.Add(new MessageAnswareConfig());
            modelBuilder.Configurations.Add(new PostConfig());
            modelBuilder.Configurations.Add(new UserMetaDataConfig());
            modelBuilder.Configurations.Add(new AnonymousUserConfig());
            modelBuilder.Configurations.Add(new DownloadLinkConfig());
            modelBuilder.Configurations.Add(new CategoryConfig());
            modelBuilder.Configurations.Add(new OptionConfig());
            modelBuilder.Configurations.Add(new ForgottenPasswordConfig());

            base.OnModelCreating(modelBuilder);
        }

        #region IUnitOfWork Members

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }


        public int SaveAllChanges(bool invalidateCacheDependencies)
        {
            return SaveChanges(invalidateCacheDependencies);
        }

        public async Task<int> SaveAllChangesAsync(bool invalidateCacheDependencies)
        {
            return await SaveChangesAsync(invalidateCacheDependencies);
        }

        public int SaveChanges(bool invalidateCacheDependencies)
        {
            var changedEntityNames = this.GetChangedEntityNames();
            var result = base.SaveChanges();
            if (invalidateCacheDependencies)
            {
                new EFCacheServiceProvider().InvalidateCacheDependencies(changedEntityNames);
            }
            return result;
        }

        public async Task<int> SaveChangesAsync(bool invalidateCacheDependencies)
        {
            var changedEntityNames = this.GetChangedEntityNames();
            var result = await base.SaveChangesAsync();
            if (invalidateCacheDependencies)
            {
                new EFCacheServiceProvider().InvalidateCacheDependencies(changedEntityNames);
            }
            return result;
        }


        public void MarkAsAdded<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Added;
        }
        public void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Deleted;
        }

        public IEnumerable<TEntity> AddThisRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            return ((DbSet<TEntity>)this.Set<TEntity>()).AddRange(entities);
        }

        public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Modified;
        }

        public IList<T> GetRows<T>(string sql, params object[] parameters) where T : class
        {
            return Database.SqlQuery<T>(sql, parameters).ToList();
        }

        public void ForceDatabaseInitialize()
        {
            this.Database.Initialize(force: true);
        }


        #endregion
    }
}