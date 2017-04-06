using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.AdminModel;
using MyCMS.Model.RSSModel;
using MyCMS.Servicelayer.EFServices.Enums;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface IProductTypeGroupService
    {
        void AddProductTypeGroup(ProductTypeGroupModel ProductTypeGroupModel);

        void UpdateProductTypeGroup(ProductTypeGroupModel ProductTypeGroupModel);
        void DeleteProductTypeGroup(int ProductTypeGroupID);
        IList<ProductTypeGroupModel> GetAllProductTypeGroups();
        IList<ProductTypeGroupModel> GetProductTypeGroup(int page, int count, Order order = Order.Asscending);

       
        ProductTypeGroupModel GetProductTypeGroupById(int ProductTypeGroupID);

    }
}