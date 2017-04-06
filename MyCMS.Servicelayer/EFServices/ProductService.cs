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
    public class ProductService : IProductService
    {

        private readonly IDbSet<Product> _Product;

        public ProductService(IUnitOfWork uow)
        {
            _Product = uow.Set<Product>();
        }
        public void AddProduct(ProductModel ProductModel)
        {
            Mapper.Initialize(cfg =>
        cfg.CreateMap<ProductModel, Product>());
            var ProductItem = Mapper.Map<Product>(ProductModel);
            _Product.Add(ProductItem);
        }
        [CacheMethod]

        public IList<ProductModel> GetAllProducts()
        {
            var List = _Product.AsNoTracking().OrderByDescending(c => c.Id).ToList();
            Mapper.Initialize(cfg =>
            cfg.CreateMap<Product, ProductModel>()
            .ForMember(er => er.ProductTypeGroupName, er => er.MapFrom(t => t.ProductTypeGroup.Name))
            .ForMember(er => er.ProductTypeName, er => er.MapFrom(t => t.ProductType.Name))
            );

            var ModelList = Mapper.Map<IEnumerable<ProductModel>>(List);
            return ModelList.ToList();

        }


        public IList<ProductModel> GetProduct(int page, int count, Order order = Order.Asscending)
        {
            throw new NotImplementedException();
        }

        public ProductModel GetProductById(int ProductID)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductModel ProductModel)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProductModel, Product>());

            var ProductItem = Mapper.Map<Product>(ProductModel);


            _Product.Attach(ProductItem);

        }

        public void DeleteProduct(int ProductID)
        {
            _Product.Remove(_Product.Find(ProductID));
        }
    }
}