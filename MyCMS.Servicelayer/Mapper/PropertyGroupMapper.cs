//using MyCMS.DomainClasses.Entities;
//using MyCMS.Model.AdminModel;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
     
//namespace MyCMS.Servicelayer.Mapper
//{
//     public static class PropertyGroupMapper
//    {
//        public static void Config()
//        {
//            //Mapper.CreateMap<UserProfile, UserProfileViewModel>()
//            //    .ForMember(x => x.fk_CityTitle, x => x.MapFrom(q => q.City.Name))
//            //    .ForMember(x => x.fk_CountryTitle, x => x.MapFrom(q => q.Country.Name))
//            //    .ForMember(x => x.fk_ProvinceTitle, x => x.MapFrom(q => q.Province.Name))
//            //    ;
//            M
//            Mapper.CreateMap<AlertJob, AlertJobViewModel>()
//                .ForMember(q => q.fk_AlertTypeId, q => q.MapFrom(w => w.AlertType));

//            Mapper.CreateMap<AlertJobViewModel, AlertJob>()
//                .ForMember(q => q.AlertType, q => q.MapFrom(w => w.fk_AlertTypeId));
//        }
//    }
//}
