using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.AdminModel;
using MyCMS.Model.RSSModel;
using MyCMS.Servicelayer.EFServices.Enums;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface IProductPropertyService
    {
        void AddProductProperty(ProductPropertyModel ProductPropertyModel);

        void UpdateProductProperty(ProductPropertyModel ProductPropertyModel);
        void DeleteProductProperty(int ProductPropertyID);
        IList<ProductPropertyModel> GetAllProductProperties();
        IList<ProductPropertyModel> GetProductProperty(int page, int count, Order order = Order.Asscending);
        ProductPropertyModel GetProductPropertyById(int ProductPropertyID);

    }
}