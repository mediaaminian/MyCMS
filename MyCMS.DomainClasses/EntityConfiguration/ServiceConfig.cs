using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class ServiceConfig : EntityTypeConfiguration<Service>
    {
        public ServiceConfig()
        {
            HasKey(t => t.Id);
            HasOptional(x => x.Product).WithMany(x => x.Services).HasForeignKey(x => x.ProductId).WillCascadeOnDelete(false);
            HasOptional(x => x.UserOrderDetail).WithMany(x => x.Services).HasForeignKey(x => x.UserOrderDetailId).WillCascadeOnDelete(false);
            HasOptional(x => x.ProductTypeGroup).WithMany(x => x.Services).HasForeignKey(x => x.ProductTypeGroupId).WillCascadeOnDelete(false);
            HasOptional(x => x.ProductType).WithMany(x => x.Services).HasForeignKey(x => x.ProductTypeId).WillCascadeOnDelete(false);
            HasOptional(x => x.User).WithMany(x => x.Services).HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
            Property(t => t.Name).IsRequired().HasMaxLength(200);            
            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}