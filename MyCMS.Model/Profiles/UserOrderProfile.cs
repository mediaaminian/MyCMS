using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using System;
using MyCMS.Model;
using MyCMS.DomainClasses.Entities;


namespace MyCMS.Model
{
    public class UserOrderProfile : Profile
    {
        public new string ProfileName
        {
            get { return this.GetType().Name; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<UserOrder, UserOrderViewModel>()
                .ForSourceMember(q => q.Invoices, q => q.Ignore())
            .ForSourceMember(q => q.OrderDetails, q => q.Ignore())
            .ForSourceMember(q => q.User, q => q.Ignore());
            Mapper.CreateMap<UserOrderViewModel, UserOrder>()
                ;
        }
    }
}
