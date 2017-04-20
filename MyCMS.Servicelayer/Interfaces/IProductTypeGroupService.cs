using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.RSSModel;
using MyCMS.Servicelayer.EFServices.Enums;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface IProductTypeGroupService
    {
        void AddProductTypeGroup(ProductTypeGroupViewModel ProductTypeGroupModel);

        void UpdateProductTypeGroup(ProductTypeGroupViewModel ProductTypeGroupModel);
        void DeleteProductTypeGroup(int ProductTypeGroupID);
        IList<ProductTypeGroupViewModel> GetAllProductTypeGroups();
        IList<ProductTypeGroupViewModel> GetProductTypeGroup(int page, int count, Order order = Order.Asscending);


        ProductTypeGroupViewModel GetProductTypeGroupById(int ProductTypeGroupID);

    }
}