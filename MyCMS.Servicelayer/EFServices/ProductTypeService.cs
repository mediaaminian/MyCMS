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
    public class ProductTypeService : IProductTypeService
    {
        private readonly IDbSet<ProductType> _ProductType;

        public ProductTypeService(IUnitOfWork uow)
        {
            _ProductType = uow.Set<ProductType>();
        }
        public void AddProductType(ProductTypeModel ProductTypeModel)
        {
            Mapper.Initialize(cfg =>
        cfg.CreateMap<ProductTypeModel, ProductType>());
            var ProductTypeItem = Mapper.Map<ProductType>(ProductTypeModel);
            _ProductType.Add(ProductTypeItem);
        }
        [CacheMethod]

        public IList<ProductTypeModel> GetAllProductType()
        {
            var List = _ProductType.AsNoTracking().OrderByDescending(c => c.Id).ToList();
            Mapper.Initialize(cfg =>
            cfg.CreateMap<ProductType, ProductTypeModel>()
            .ForMember(er => er.ProductTypeGroupName, er => er.MapFrom(t => t.ProductTypeGroup.Name)));

            var ModelList = Mapper.Map<IEnumerable<ProductTypeModel>>(List);
            return ModelList.ToList();

        }


        public IList<ProductTypeModel> GetProductType(int page, int count, Order order = Order.Asscending)
        {
            throw new NotImplementedException();
        }

        public ProductTypeModel GetProductTypeById(int ProductTypeID)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductType(ProductTypeModel ProductTypeModel)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProductTypeModel, ProductType>());

            var ProductTypeItem = Mapper.Map<ProductType>(ProductTypeModel);


            _ProductType.Attach(ProductTypeItem);

        }

        public void DeleteProductType(int ProductTypeID)
        {
            _ProductType.Remove(_ProductType.Find(ProductTypeID));
        }

    }
}