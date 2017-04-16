using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class UserOrderDetailConfig : EntityTypeConfiguration<UserOrderDetail>
    {
        public UserOrderDetailConfig()
        {
            HasKey(t => t.Id);
            HasOptional(x => x.UserOrder).WithMany(x => x.OrderDetails).HasForeignKey(x => x.UserOrderId).WillCascadeOnDelete(false);
            HasOptional(x => x.Product).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductId).WillCascadeOnDelete(false);
            HasOptional(x => x.ProductType).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductTypeId).WillCascadeOnDelete(false);
            HasOptional(x => x.ProductTypeGroup).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductTypeGroupId).WillCascadeOnDelete(false);
            HasOptional(x => x.TimeFrame).WithMany(x => x.OrderDetails).HasForeignKey(x => x.TimeFrameId).WillCascadeOnDelete(false);
            HasOptional(x => x.Service).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ServiceId).WillCascadeOnDelete(false);
            HasOptional(x => x.User).WithMany(x => x.UserOrderDetails).HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
            Property(t => t.Description).HasMaxLength(1000);
            Property(t => t.ServiceName).HasMaxLength(50);
            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}