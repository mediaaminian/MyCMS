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
   public static class ProductMapper
    {
        public static void Config()
        {
            Mapper.CreateMap<Product, ProductViewModel>()
                .ForMember(q => q.ProductTypeName, q => q.MapFrom(w => w.ProductType.Name));
            Mapper.CreateMap<ProductViewModel, Product>();
        }
    }
}
