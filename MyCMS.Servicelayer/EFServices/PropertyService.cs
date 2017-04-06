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
    public class PropertyService : IPropertyService
    {

        private readonly IDbSet<Property> _Property;

        public PropertyService(IUnitOfWork uow)
        {
            _Property = uow.Set<Property>();
        }
        public void AddProperty(PropertyModel PropertyModel)
        {
            Mapper.Initialize(cfg =>
            cfg.CreateMap<PropertyModel, Property>());
            var PropertyItem = Mapper.Map<Property>(PropertyModel);
            _Property.Add(PropertyItem);
        }
        [CacheMethod]

        public IList<PropertyModel> GetAllProperties()
        {
            var List = _Property.AsNoTracking().OrderByDescending(c => c.Id).ToList();
            Mapper.Initialize(cfg =>
            cfg.CreateMap<Property, PropertyModel>().ForMember(er=>er.PropertyGroupName,er=>er.MapFrom(t=>t.PropertyGroup.Name)));

            var ModelList = Mapper.Map<IEnumerable<PropertyModel>>(List);
            return ModelList.ToList();

        }


        public IList<PropertyModel> GetProperty(int page, int count, Order order = Order.Asscending)
        {
            throw new NotImplementedException();
        }

        public PropertyModel GetPropertyById(int PropertyID)
        {
            throw new NotImplementedException();
        }

        public void UpdateProperty(PropertyModel PropertyModel)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PropertyModel, Property>());

            var PropertyItem = Mapper.Map<Property>(PropertyModel);


            _Property.Attach(PropertyItem);

        }

        public void DeleteProperty(int PropertyID)
        {
            _Property.Remove(_Property.Find(PropertyID));
        }

    }
}