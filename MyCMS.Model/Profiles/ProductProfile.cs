using AutoMapper;
using MyCMS.DomainClasses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Model
{
    public class ProductProfile : Profile
    {
        public new string ProfileName
        {
            get { return this.GetType().Name; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<Product, ProductViewModel>()
                .ForMember(q => q.ProductTypeName, q => q.MapFrom(w => w.ProductType.Name));
            Mapper.CreateMap<ProductViewModel, Product>()
                            .ForMember(q => q.OrderDetails, q => q.Ignore())
            .ForMember(q => q.ProductProperties, q => q.Ignore())
            .ForMember(q => q.Services, q => q.Ignore())
            .ForMember(q => q.ProductType, q => q.Ignore())
            .ForMember(q => q.ProductTypeGroup, q => q.Ignore())
            .ForMember(q => q.User, q => q.Ignore());
        }

    }
}
