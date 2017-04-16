using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCMS.DomainClasses.Entities;


namespace MyCMS.Model.Mappers
{
    public static class ServiceMapper
    {
        public static void Config()
        {
            Mapper.CreateMap<MyCMS.DomainClasses.Entities.Service, ServiceViewModel>()
                .ForMember(q=>q.ProductTypeTitle, q=>q.MapFrom(w=>w.Product.ProductType.Name))
                .ForMember(q => q.ProductTitle, q => q.MapFrom(w => w.Product.Name))
                .ForMember(q => q.ProductTypeGroupTitle, q => q.MapFrom(w => w.Product.ProductTypeGroup.Name));

            Mapper.CreateMap<ServiceViewModel, MyCMS.DomainClasses.Entities.Service>();
        }
    }
}
