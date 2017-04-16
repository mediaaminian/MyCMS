using AutoMapper;
using System;
using MyCMS.Model;
using MyCMS.DomainClasses.Entities;


namespace MyCMS.Model.Mappers
{
    public static class InvoiceMapper
    {
        public static void Config()
        {
            Mapper.CreateMap<Invoice, InvoiceViewModel>();
            Mapper.CreateMap<InvoiceViewModel, Invoice>();
        }
    }
}
