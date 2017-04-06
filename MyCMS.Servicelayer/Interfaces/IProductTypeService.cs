using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.AdminModel;
using MyCMS.Servicelayer.EFServices.Enums;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface IProductTypeService
    {
        void AddProductType(ProductTypeModel ProductTypeModel);
        void UpdateProductType(ProductTypeModel ProductTypeModel);
        void DeleteProductType(int ProductTypeID);
        IList<ProductTypeModel> GetAllProductType();
        IList<ProductTypeModel> GetProductType(int page, int count, Order order = Order.Asscending);
        ProductTypeModel GetProductTypeById(int ProductTypeID);

    }
}