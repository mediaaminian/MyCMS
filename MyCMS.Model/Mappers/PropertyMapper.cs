using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCMS.Model;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.Model.Mappers
{
    public static class PropertyMapper
    {
        public static void Config()
        {
            Mapper.CreateMap<Property, PropertyViewModel>()
                .ForMember(q => q.PropertyGroupTitle, q => q.MapFrom(w => w.PropertyGroup.Name))
                .ForMember(q=>q.DataType, q=>q.MapFrom(w=> w.DataType))
                .ForMember(q => q.ProductTypeGroupId, q=>q.MapFrom(w=>w.PropertyGroup.ProductTypeGroupId));

            Mapper.CreateMap<PropertyViewModel, Property>();
        }        
    }
}
