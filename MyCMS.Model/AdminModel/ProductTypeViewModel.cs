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
    [Validator(typeof(ProductTypeViewModelValidator))]
    public partial class ProductTypeViewModel : IHaveCustomMappings
    {

        #region [ Prperties ]

        [Localized("ProductType.Id")]
        public System.Int32 Id { get; set; }

        [Localized("ProductType.Brief")]
        public System.String Brief { get; set; }

        [Localized("ProductType.Description")]
        public System.String Description { get; set; }

        [Localized("ProductType.ProductTypeGroup")]
        public System.Int32 ProductTypeGroupId { get; set; }


        [Localized("تصویر")]
        public System.String Picture { get; set; }

        [Localized("ProductType.Name")]
        public System.String Name { get; set; }

        [Localized("ProductType.Priority")]
        public System.Byte? Priority { get; set; }

        [Localized("ProductType.Status")]
        public System.Byte Status { get; set; }

        [Localized("ProductType.Status")]
        public String StatusTitle
        {
            get
            {
                try
                {
                    return DataDictionary.ProductTypeStatusItems[Status].Item2;
                }
                catch (Exception)
                {

                    return "";
                }
            }
        }

        [Localized("خدمت")]
        public bool IsService { get; set; }
        

        [Localized("ProductType.MoneyBackDay")]
        public int MoneyBackDay { get; set; }

        [Localized("ProductType.CancelAmount")]
        public double CancelAmount { get; set; }

        [Localized("ProductType.TrialDay")]
        public int TrialDay { get; set; }


        [Localized("قابل لغو")]
        public bool IsCancelable { get; set; }


        [Localized("قابل لغو")]
        public string IsCancelableT
        {
            get
            {
                if (this.IsCancelable == true)
                    return "می باشد";
                else
                    return "نمی باشد";
            }
        }


        [Localized("ProductType.ProductTypeGroup")]
        public string ProductTypeGroupTitle { get; set; }

        public byte[] RowVersion { get; set; }

        #endregion

        public void CreateMappings()
        {
            //ProductTypeMapper.Config();
            Mapper.Initialize(cfg => cfg.CreateMap<ProductType, ProductTypeViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<ProductTypeViewModel, ProductType>()
            .ForMember(q=>q.ProductTypeGroup,q=>q.Ignore())
            .ForMember(q=>q.Products, q=>q.Ignore())
            .ForMember(q=>q.Services, q=>q.Ignore())
            .ForMember(q=>q.OrderDetails, q=>q.Ignore())
            );
        }

        public ProductType GetDomain(ProductTypeViewModel viewmodel)
        {
            var result = Mapper.Map<ProductTypeViewModel, ProductType>(viewmodel);
            return result;
        }

        public ProductTypeViewModel GetViewModel(ProductType domain)
        {
            var result = Mapper.Map<ProductType, ProductTypeViewModel>(domain);
            return result;
        }
    }
}