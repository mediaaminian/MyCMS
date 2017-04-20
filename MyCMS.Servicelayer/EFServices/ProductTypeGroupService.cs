using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyCMS.Datalayer.Context;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Servicelayer.EFServices.Enums;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities.Caching;
using AutoMapper;


namespace MyCMS.Servicelayer.EFServices
{
    public class ProductTypeGroupService : IProductTypeGroupService
    {
        private readonly IDbSet<ProductTypeGroup> _ProductTypeGroup;
        private readonly IMappingEngine _mappingEngine;
        private readonly IUnitOfWork _unitOfWork;

        public ProductTypeGroupService(IUnitOfWork uow, IMappingEngine mappingEngine)
        {
            _unitOfWork = uow;
            _mappingEngine = mappingEngine;
            _ProductTypeGroup = uow.Set<ProductTypeGroup>();
        }
        public void AddProductTypeGroup(ProductTypeGroupViewModel ProductTypeGroupModel)
        {
            Mapper.Initialize(cfg =>
        cfg.CreateMap<ProductTypeGroupViewModel, ProductTypeGroup>()
            //.ForMember(er => er.DefaultTimeFrame, er => er.MapFrom(t => new TimeFrame() { Id= t.DefaultTimeFrameID}))
            );

            var ProductTypeGroupItem = Mapper.Map<ProductTypeGroup>(ProductTypeGroupModel);
            _ProductTypeGroup.Add(ProductTypeGroupItem);
        }
        [CacheMethod]

        public IList<ProductTypeGroupViewModel> GetAllProductTypeGroups()
        {
            var List = _ProductTypeGroup.ToList();

            var ModelList = new List<ProductTypeGroupViewModel>();
            _mappingEngine.Map(source: List, destination: ModelList);
            return ModelList;
        }


        public IList<ProductTypeGroupViewModel> GetProductTypeGroup(int page, int count, Order order = Order.Asscending)
        {
            throw new NotImplementedException();
        }

        public ProductTypeGroupViewModel GetProductTypeGroupById(int ProductTypeGroupID)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductTypeGroup(ProductTypeGroupViewModel ProductTypeGroupModel)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProductTypeGroupViewModel, ProductTypeGroup>());

            var ProductTypeGroupItem = Mapper.Map<ProductTypeGroup>(ProductTypeGroupModel);


            _ProductTypeGroup.Attach(ProductTypeGroupItem);

        }

        public void DeleteProductTypeGroup(int ProductTypeGroupID)
        {
            _ProductTypeGroup.Remove(_ProductTypeGroup.Find(ProductTypeGroupID));
        }

    }
}