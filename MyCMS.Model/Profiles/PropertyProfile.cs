using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCMS.Model;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.Model
{
    public  class PropertyProfile : Profile
    {
        public new string ProfileName
        {
            get { return this.GetType().Name; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<Property, PropertyViewModel>()
                .ForMember(q => q.PropertyGroupTitle, q => q.MapFrom(w => w.PropertyGroup.Name))
                .ForMember(q=>q.DataType, q=>q.MapFrom(w=> (enumDataType)w.DataType))
                .ForMember(q => q.ProductTypeGroupId, q=>q.MapFrom(w=>w.PropertyGroup.ProductTypeGroupId));

            Mapper.CreateMap<PropertyViewModel, Property>()
                .ForMember(q=>q.DataType, q=>q.MapFrom(w=> (byte)w.DataType))
                .ForMember(q => q.ProductProperties, q => q.Ignore())
            .ForMember(q => q.PropertyGroup, q => q.Ignore());
        }        
    }
}
