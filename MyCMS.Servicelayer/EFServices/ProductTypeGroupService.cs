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
    public class ProductTypeGroupService : IProductTypeGroupService
    {
        private readonly IDbSet<ProductTypeGroup> _ProductTypeGroup;

        public ProductTypeGroupService(IUnitOfWork uow)
        {
            _ProductTypeGroup = uow.Set<ProductTypeGroup>();
        }
        public void AddProductTypeGroup(ProductTypeGroupModel ProductTypeGroupModel)
        {
            Mapper.Initialize(cfg =>
        cfg.CreateMap<ProductTypeGroupModel, ProductTypeGroup>()
            //.ForMember(er => er.DefaultTimeFrame, er => er.MapFrom(t => new TimeFrame() { Id= t.DefaultTimeFrameID}))
            );

            var ProductTypeGroupItem = Mapper.Map<ProductTypeGroup>(ProductTypeGroupModel);
            _ProductTypeGroup.Add(ProductTypeGroupItem);
        }
        [CacheMethod]

        public IList<ProductTypeGroupModel> GetAllProductTypeGroups()
        {
            var List = _ProductTypeGroup.AsNoTracking().OrderByDescending(c => c.Id).ToList();
            Mapper.Initialize(cfg =>
            cfg.CreateMap<ProductTypeGroup, ProductTypeGroupModel>()
            //.ForMember(er => er.DefaultTimeFrameName, er => er.MapFrom(t => t.DefaultTimeFrame.Title))
            );
            var ModelList = Mapper.Map<IEnumerable<ProductTypeGroupModel>>(List);
            return ModelList.ToList();

        }


        public IList<ProductTypeGroupModel> GetProductTypeGroup(int page, int count, Order order = Order.Asscending)
        {
            throw new NotImplementedException();
        }

        public ProductTypeGroupModel GetProductTypeGroupById(int ProductTypeGroupID)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductTypeGroup(ProductTypeGroupModel ProductTypeGroupModel)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProductTypeGroupModel, ProductTypeGroup>());

            var ProductTypeGroupItem = Mapper.Map<ProductTypeGroup>(ProductTypeGroupModel);


            _ProductTypeGroup.Attach(ProductTypeGroupItem);

        }

        public void DeleteProductTypeGroup(int ProductTypeGroupID)
        {
            _ProductTypeGroup.Remove(_ProductTypeGroup.Find(ProductTypeGroupID));
        }

    }
}