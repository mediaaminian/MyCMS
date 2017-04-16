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
    public class ProductTypeGroupTimeFrameService : IProductTypeGroupTimeFrameService
    {
        private readonly IDbSet<ProductTypeGroupTimeFrame> _ProductTypeGroupTimeFrame;
        private readonly IMappingEngine _mappingEngine;
        private readonly IUnitOfWork _unitOfWork;

        public ProductTypeGroupTimeFrameService(IUnitOfWork uow, IMappingEngine mappingEngine)
        {
            _unitOfWork = uow;
            _mappingEngine = mappingEngine;
            _ProductTypeGroupTimeFrame = uow.Set<ProductTypeGroupTimeFrame>();
        }
        public void AddProductTypeGroupTimeFrame(ProductTypeGroupTimeFrameModel ProductTypeGroupTimeFrameModel)
        {
            Mapper.Initialize(cfg =>
        cfg.CreateMap<ProductTypeGroupTimeFrameModel, ProductTypeGroupTimeFrame>());
            var ProductTypeGroupTimeFrameItem = Mapper.Map<ProductTypeGroupTimeFrame>(ProductTypeGroupTimeFrameModel);
            _ProductTypeGroupTimeFrame.Add(ProductTypeGroupTimeFrameItem);
        }
        [CacheMethod]

        public IList<ProductTypeGroupTimeFrameModel> GetAllProductTypeGroupTimeFrames()
        {
            var List = _ProductTypeGroupTimeFrame.AsNoTracking().OrderByDescending(c => c.Id).ToList();
            Mapper.Initialize(cfg =>
            cfg.CreateMap<ProductTypeGroupTimeFrame, ProductTypeGroupTimeFrameModel>()
            .ForMember(er => er.ProductTypeGroupName, er => er.MapFrom(t => t.ProductTypeGroup.Name))
            .ForMember(er => er.TimeFrameName, er => er.MapFrom(t => t.TimeFrame.Title))
            );

            var ModelList = Mapper.Map<IEnumerable<ProductTypeGroupTimeFrameModel>>(List);
            return ModelList.ToList();

        }


        public IList<ProductTypeGroupTimeFrameModel> GetProductTypeGroupTimeFrame(int page, int count, Order order = Order.Asscending)
        {
            throw new NotImplementedException();
        }

        public ProductTypeGroupTimeFrameModel GetProductTypeGroupTimeFrameById(int ProductTypeGroupTimeFrameID)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductTypeGroupTimeFrame(ProductTypeGroupTimeFrameModel ProductTypeGroupTimeFrameModel)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProductTypeGroupTimeFrameModel, ProductTypeGroupTimeFrame>());

            var ProductTypeGroupTimeFrameItem = Mapper.Map<ProductTypeGroupTimeFrame>(ProductTypeGroupTimeFrameModel);


            _ProductTypeGroupTimeFrame.Attach(ProductTypeGroupTimeFrameItem);

        }

        public void DeleteProductTypeGroupTimeFrame(int ProductTypeGroupTimeFrameID)
        {
            _ProductTypeGroupTimeFrame.Remove(_ProductTypeGroupTimeFrame.Find(ProductTypeGroupTimeFrameID));
        }

    }
}