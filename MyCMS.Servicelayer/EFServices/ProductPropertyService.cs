using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyCMS.Datalayer.Context;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model.AdminModel;
using MyCMS.Servicelayer.EFServices.Enums;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities.Caching;
using AutoMapper;


namespace MyCMS.Servicelayer.EFServices
{
    public class ProductPropertyService : IProductPropertyService
    {
        private readonly IDbSet<ProductProperty> _ProductProperty;

        public ProductPropertyService(IUnitOfWork uow)
        {
            _ProductProperty = uow.Set<ProductProperty>();
        }
        public void AddProductProperty(ProductPropertyModel ProductPropertyModel)
        {
            Mapper.Initialize(cfg =>
        cfg.CreateMap<ProductPropertyModel, ProductProperty>());
            var ProductPropertyItem = Mapper.Map<ProductProperty>(ProductPropertyModel);
            _ProductProperty.Add(ProductPropertyItem);
        }
        [CacheMethod]

        public IList<ProductPropertyModel> GetAllProductProperties()
        {
            var List = _ProductProperty.AsNoTracking().OrderByDescending(c => c.Id).ToList();
            Mapper.Initialize(cfg =>
            cfg.CreateMap<ProductProperty, ProductPropertyModel>());

            var ModelList = Mapper.Map<IEnumerable<ProductPropertyModel>>(List);
            return ModelList.ToList();

        }


        public IList<ProductPropertyModel> GetProductProperty(int page, int count, Order order = Order.Asscending)
        {
            throw new NotImplementedException();
        }

        public ProductPropertyModel GetProductPropertyById(int ProductPropertyID)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductProperty(ProductPropertyModel ProductPropertyModel)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProductPropertyModel, ProductProperty>());

            var ProductPropertyItem = Mapper.Map<ProductProperty>(ProductPropertyModel);


            _ProductProperty.Attach(ProductPropertyItem);

        }

        public void DeleteProductProperty(int ProductPropertyID)
        {
            _ProductProperty.Remove(_ProductProperty.Find(ProductPropertyID));
        }

    }
}