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
    public class PropertyGroupService : IPropertyGroupService
    {

        private readonly IDbSet<PropertyGroup> _PropertyGroup;
        private readonly IMappingEngine _mappingEngine;
        private readonly IUnitOfWork _unitOfWork;

        public PropertyGroupService(IUnitOfWork uow, IMappingEngine mappingEngine)
        {
            _unitOfWork = uow;
            _mappingEngine = mappingEngine;
            _PropertyGroup = uow.Set<PropertyGroup>();
        }
        public void AddPropertyGroup(PropertyGroupModel PropertyGroupModel)
        {
            Mapper.Initialize(cfg =>
        cfg.CreateMap<PropertyGroupModel, PropertyGroup>());
            var PropertyGroupItem = Mapper.Map<PropertyGroup>(PropertyGroupModel);
            PropertyGroupItem.Properties = new List<Property>();
            _PropertyGroup.Add(PropertyGroupItem);
        }
        [CacheMethod]

        public IList<PropertyGroupModel> GetAllPropertyGroup()
        {
            var List=_PropertyGroup.AsNoTracking().OrderByDescending(c=>c.Id).ToList();
            Mapper.Initialize(cfg =>
            cfg.CreateMap< PropertyGroup, PropertyGroupModel>()
            .ForMember(q=>q.ProductTypeGroupName,q=>q.MapFrom(e=>e.ProductTypeGroup.Name)));

            var ModelList = Mapper.Map<IEnumerable<PropertyGroupModel>>(List);
            return ModelList.ToList();

        }

        
        public IList<PropertyGroupModel> GetPropertyGroup(int page, int count, Order order = Order.Asscending)
        {
            throw new NotImplementedException();
        }

        public PropertyGroupModel GetPropertyGroupById(int PropertyGroupID)
        {
            throw new NotImplementedException();
        }

        public void UpdatePropertyGroup(PropertyGroupModel PropertyGroupModel)
        {
            Mapper.Initialize(cfg =>cfg.CreateMap<PropertyGroupModel, PropertyGroup>());

            var PropertyGroupItem = Mapper.Map<PropertyGroup>(PropertyGroupModel);

            PropertyGroupItem.Properties = new List<Property>();

            _PropertyGroup.Attach(PropertyGroupItem);

        }

        public void DeletePropertyGroup(int PropertyGroupID)
        {
            _PropertyGroup.Remove(_PropertyGroup.Find(PropertyGroupID));
        }
    }
}