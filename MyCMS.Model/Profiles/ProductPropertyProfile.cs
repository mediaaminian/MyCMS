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
    public class ProductPropertyProfile : Profile
    {
        public new string ProfileName
        {
            get { return this.GetType().Name; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<ProductProperty, ProductPropertyViewModel>()
                .ForMember(q => q.PropertyTitle, q => q.MapFrom(w => w.Property.Name))
                .ForMember(q => q.PropertyId, q => q.MapFrom(w => w.Property.Id))
                .ForMember(q => q.ProductId, q => q.MapFrom(w => w.Product.Id))
                .ForMember(q => q.DefaultValue, q => q.MapFrom(w => w.Property.DefaultValue));


            Mapper.CreateMap<ProductPropertyViewModel, ProductProperty>()
                //.ForMember(dest => dest.Product,
                //opt => opt.MapFrom(
                //src => Mapper.Map<ProductViewModel,Product>(src.ProductId)));
                //Igonre if not needed properties
                .ForMember(q => q.Product, q => q.Ignore())
                .ForMember(q => q.Property, q => q.Ignore());
        }
    }
}