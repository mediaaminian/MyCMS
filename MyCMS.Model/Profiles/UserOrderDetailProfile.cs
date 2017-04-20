using AutoMapper;
using System;
using MyCMS.Model;
using MyCMS.DomainClasses.Entities;


namespace MyCMS.Model
{
    public class UserOrderDetailProfile : Profile
    {
        public new string ProfileName
        {
            get { return this.GetType().Name; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<UserOrderDetail, UserOrderDetailViewModel>()
                .ForMember(x => x.ProductName, x => x.MapFrom(q => q.Product.Name))
                .ForMember(x => x.ProductTypeGroupName, x => x.MapFrom(q => q.Product.ProductTypeGroup.Name))
                .ForMember(x => x.TimeFramePeriod, x => x.MapFrom(q => q.TimeFrame.Days.ToInt().ConvertNumberToText() + " روز"));

            Mapper.CreateMap<UserOrderDetailViewModel, UserOrderDetail>().ForMember(q => q.UserOrder, q => q.Ignore())
            .ForMember(q => q.OrderDetails, q => q.Ignore())
            .ForMember(q => q.Services, q => q.Ignore())
            .ForMember(q => q.Product, q => q.Ignore())
            .ForMember(q => q.ProductType, q => q.Ignore())
            .ForMember(q => q.ProductTypeGroup, q => q.Ignore())
            .ForMember(q => q.TimeFrame, q => q.Ignore())
            .ForMember(q => q.Service, q => q.Ignore())
            .ForMember(q => q.User, q => q.Ignore())
            .ForMember(q => q.EditedByUser, q => q.Ignore());
        }
    }
}
