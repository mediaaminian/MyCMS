using AutoMapper.Configuration;
using MyCMS.Abstraction;
using MyCMS.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using MyCMS.DomainClasses.Entities;
using AutoMapper;
//using MyCMS.Model.Mappers;

namespace MyCMS.Model
{
    [Validator(typeof(ServiceViewModelValidator))]
    public partial class ServiceViewModel : IHaveCustomMappings
    {

        #region [ Prperties ]

        [Localized("Service.ID")]
        public System.Int32 Id { get; set; }

        [Localized("Service.Name")]
        public System.String Name { get; set; }

        [Localized("Service.StartDate")]
        public System.DateTime StartDate { get; set; }

        [Localized("Service.EndDate")]
        public System.DateTime EndDate { get; set; }

        [Localized("تصویر")]
        public System.String Picture { get; set; }

        [Localized("خلاصه")]
        public System.String Brief { get; set; }

        [Localized("توضیحات")]
        public System.String Description { get; set; }

        [Localized("توصیحات سفارش")]
        public System.String OrderDescription { get; set; }

        [Localized("Service.ProductID")]
        public System.Int32 ProductId { get; set; }


        [Localized("امکانات اضافی")]
        public System.Boolean IsExtra { get; set; }

        [Localized("ویژه")]
        public System.Boolean? IsSpecial { get; set; }

        [Localized("Service.AutoRenew")]
        public System.Boolean? AutoRenew { get; set; }


        [Localized("Service.TempActivationCount")]
        public System.Int32 TempActivationCount { get; set; }

        [Localized("Service.TempExpireTime")]
        public DateTime TempExpireTime { get; set; }

        [Localized("Service.Status")]
        public System.Byte Status { get; set; }

        [Localized("Service.Status")]
        public String StatusTitle
        {
            get
            {
                try
                {
                    //return DataDictionary.ServiceStatusItems[Status].Item2;
                    return Status == 0 ? string.Empty : DataDictionary.ServiceStatusItems[Status].Item2;
                }
                catch (Exception)
                {

                    return "";
                }
            }
        }


        [Localized("Service.ProductTypeTitle")]
        public string ProductTypeTitle { get; set; }

        [Localized("Service.ProductTitle")]
        public string ProductTitle { get; set; }

        [Localized("Service.ProductTypeGroupTitle")]
        public string ProductTypeGroupTitle { get; set; }

        public long? UserOrderDetailId { get; set; }

        public String StatusColor
        {
            get
            {
                try
                {
                    //return DataDictionary.ServiceStatusItems[Status].Item2;
                    return Status == 0 ? string.Empty : DataDictionary.ServiceStatusColors[Status].Item1;
                }
                catch (Exception)
                {

                    return "";
                }
            }
        }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ProductTypeId { get; set; }
        public int? ProductTypeGroupId { get; set; }
        public int? UserId { get; set; }
        public byte[] RowVersion { get; set; }

        #endregion
        public void CreateMappings()
        {
            //ServiceMapper.Config();
            Mapper.Initialize(cfg => cfg.CreateMap<Service, ServiceViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<ServiceViewModel, Service>()

            );
        }

        public Service GetDomain(ServiceViewModel viewmodel)
        {
            var result = Mapper.Map<ServiceViewModel, Service>(viewmodel);
            return result;
        }

        public ServiceViewModel GetViewModel(Service domain)
        {
            var result = Mapper.Map<Service, ServiceViewModel>(domain);
            return result;
        }
    }
}