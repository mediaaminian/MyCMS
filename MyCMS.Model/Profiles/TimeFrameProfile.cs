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
   public class TimeFrameProfile : Profile
    {
        public new string ProfileName
        {
            get { return this.GetType().Name; }
        }
        protected override void Configure() {
            Mapper.CreateMap<TimeFrame, TimeFrameViewModel>();
            Mapper.CreateMap<TimeFrameViewModel, TimeFrame>()
                            .ForMember(q => q.ProductTypeGroupTimeFrames, q => q.Ignore())
            .ForMember(q => q.ProductTypeGroups, q => q.Ignore())
            .ForMember(q => q.OrderDetails, q => q.Ignore());
        }
    }
}
