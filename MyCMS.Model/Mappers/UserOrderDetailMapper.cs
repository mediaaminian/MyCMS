using AutoMapper;
using System;
using MyCMS.Model;
using MyCMS.DomainClasses.Entities;


namespace MyCMS.Model.Mappers
{
    public static class UserOrderDetailMapper
    {
        public static void Config()
        {
            Mapper.CreateMap<UserOrderDetail, UserOrderDetailViewModel>()
                .ForMember(x => x.ProductName, x => x.MapFrom(q => q.Product.Name))
                .ForMember(x => x.ProductTypeGroupName, x => x.MapFrom(q => q.Product.ProductTypeGroup.Name))
                .ForMember(x => x.TimeFramePeriod, x => x.MapFrom(q => q.TimeFrame.Days.ToInt().ConvertNumberToText() + " روز"));

            Mapper.CreateMap<UserOrderDetailViewModel, UserOrderDetail>();
        }
    }
}
