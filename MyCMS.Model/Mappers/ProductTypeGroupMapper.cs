using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Utilities;

namespace MyCMS.Model.Mappers
{
   public static class ProductTypeGroupMapper
    {
        public static void Config()
        {
            Mapper.CreateMap<ProductTypeGroup, ProductTypeGroupViewModel>()
                .ForMember(q => q.ProductTypeList, q => q.MapFrom(w => w.ProductTypes.Select(p=>p)))
                .ForMember(q => q.AppKey, q => q.MapFrom(w => DataDictionary.AppKeyItems.Where(e => e.Value == w.AppKey).Select(e => e.Key.ToString()).FirstOrDefault())); 



            Mapper.CreateMap<ProductTypeGroupViewModel, ProductTypeGroup>()
                .ForMember(q=>q.AppKey, q=>q.MapFrom(w=> DataDictionary.AppKeyItems.Where(e=>e.Key.ToString() == w.AppKey).Select(e=>e.Value.ToString()).FirstOrDefault()));
        }
    }
}
