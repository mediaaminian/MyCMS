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
            Mapper.CreateMap<ProductViewModel, Product>();
        }

    }
}
