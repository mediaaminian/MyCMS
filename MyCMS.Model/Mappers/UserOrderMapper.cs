using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using System;
using MyCMS.Model;
using MyCMS.DomainClasses.Entities;


namespace MyCMS.Model.Mappers
{
    public static class UserOrderMapper
    {
        public static void Config()
        {
            Mapper.CreateMap<UserOrder, UserOrderViewModel>();
            Mapper.CreateMap<UserOrderViewModel, UserOrder>();
        }
    }
}
