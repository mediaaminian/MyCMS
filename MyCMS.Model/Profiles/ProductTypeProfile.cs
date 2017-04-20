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
   public class ProductTypeProfile : Profile
    {
        public new string ProfileName
        {
            get { return this.GetType().Name; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<ProductType, ProductTypeViewModel>()
                .ForMember(q => q.ProductTypeGroupId, q => q.MapFrom(w => w.ProductTypeGroup.Id))
                .ForMember(q => q.ProductTypeGroupTitle, q=>q.MapFrom(w=>w.ProductTypeGroup.Name));

            Mapper.CreateMap<ProductTypeViewModel, ProductType>()
                .ForMember(q => q.Products, q => q.Ignore())
                .ForMember(q => q.ProductTypeGroup, q => q.Ignore())
                .ForMember(q => q.Services, q => q.Ignore())
                .ForMember(q => q.OrderDetails, q => q.Ignore());

            
        }
    }
}