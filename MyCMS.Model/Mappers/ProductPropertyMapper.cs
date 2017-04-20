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
    public static class ProductPropertyMapper
    {
        public static void Config()
        {
            Mapper.CreateMap<ProductProperty, ProductPropertyViewModel>()
                .ForMember(q => q.PropertyTitle, q => q.MapFrom(w => w.Property.Name))
                .ForMember(q => q.DefaultValue, q => q.MapFrom(w => w.Property.DefaultValue));

            Mapper.CreateMap<ProductPropertyViewModel, ProductProperty>();
        }
    }
}