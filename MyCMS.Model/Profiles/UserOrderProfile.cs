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
            Mapper.CreateMap<UserOrder, UserOrderViewModel>();
            Mapper.CreateMap<UserOrderViewModel, UserOrder>();
        }
    }
}
