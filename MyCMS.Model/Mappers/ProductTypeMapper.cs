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
   public static class ProductTypeMapper
    {
        public static void Config()
        {
            Mapper.CreateMap<ProductType, ProductTypeViewModel>()
                .ForMember(q => q.ProductTypeGroupTitle, q=>q.MapFrom(w=>w.ProductTypeGroup.Name));

            Mapper.CreateMap<ProductTypeViewModel, ProductType>();
        }
    }
}