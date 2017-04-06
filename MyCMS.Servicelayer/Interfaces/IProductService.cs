using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.AdminModel;
using MyCMS.Model.RSSModel;
using MyCMS.Servicelayer.EFServices.Enums;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface IProductService
    {
        void AddProduct(ProductModel ProductModel);

        void UpdateProduct(ProductModel ProductModel);
        void DeleteProduct(int ProductID);
        IList<ProductModel> GetAllProducts();
        IList<ProductModel> GetProduct(int page, int count, Order order = Order.Asscending);

       
        ProductModel GetProductById(int ProductID);

    }
}