using AutoMapper;
using System;
using MyCMS.Model;
using MyCMS.DomainClasses.Entities;


namespace MyCMS.Model
{
    public class InvoiceProfile : Profile
    {
        public new string ProfileName
        {
            get { return this.GetType().Name; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<Invoice, InvoiceViewModel>();
            Mapper.CreateMap<InvoiceViewModel, Invoice>()
                .ForMember(q => q.User, q => q.Ignore());
        }
    }
}
