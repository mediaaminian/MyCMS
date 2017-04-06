using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.AdminModel;
using MyCMS.Model.RSSModel;
using MyCMS.Servicelayer.EFServices.Enums;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface IProductTypeGroupTimeFrameService
    {
        void AddProductTypeGroupTimeFrame(ProductTypeGroupTimeFrameModel ProductTypeGroupTimeFrameModel);

        void UpdateProductTypeGroupTimeFrame(ProductTypeGroupTimeFrameModel ProductTypeGroupTimeFrameModel);
        void DeleteProductTypeGroupTimeFrame(int ProductTypeGroupTimeFrameID);
        IList<ProductTypeGroupTimeFrameModel> GetAllProductTypeGroupTimeFrames();
        IList<ProductTypeGroupTimeFrameModel> GetProductTypeGroupTimeFrame(int page, int count, Order order = Order.Asscending);

       
        ProductTypeGroupTimeFrameModel GetProductTypeGroupTimeFrameById(int ProductTypeGroupTimeFrameID);

    }
}