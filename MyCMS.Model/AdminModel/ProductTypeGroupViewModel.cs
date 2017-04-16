using AutoMapper.Configuration;
using MyCMS.Abstraction;
using MyCMS.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using MyCMS.DomainClasses.Entities;
using AutoMapper;
using System.Collections.Generic;
//using MyCMS.Model.Mappers;

namespace MyCMS.Model
{
    [Validator(typeof(ProductTypeGroupViewModelValidator))]
	public partial class ProductTypeGroupViewModel : IHaveCustomMappings
    {

        
        #region [ Prperties ]

        [Localized("ProductTypeGroup.Id")]
        public System.Int32 Id { get; set; }

        [Localized("ProductTypeGroup.Name")]
        public System.String Name { get; set; }

        [Localized("ProductTypeGroup.AppKey")]
        public System.String AppKey { get; set; }

        [Localized("ProductTypeGroup.Priority")]
        public System.Int32 Priority { get; set; }

        [Localized("خدمت")]
        public bool IsService { get; set; }

        [Localized("خدمت")]
        public string IsServiceT
        {
            get
            {
                if (this.IsService == true)
                    return "می باشد";
                else
                    return "نمی باشد";
            }
        }

        [Localized("قابل سفارش")]
        public bool IsAvailableToOrder { get; set; }

        [Localized("قابل سفارش")]
        public string IsAvailableToOrderT
        {
            get
            {
                if (this.IsAvailableToOrder == true)
                    return "می باشد";
                else
                    return "نمی باشد";
            }
        }

        [Localized("تصویر")]
        public System.String Picture { get; set; }

        [Localized("ProductTypeGroup.Brief")]
        public System.String Brief { get; set; }
        
        [Localized("ProductTypeGroup.Description")]
        public System.String Description { get; set; }


        [Localized("ProductTypeGroup.Status")]
        public System.Byte Status { get; set; }

        public Dictionary<ProductTypeViewModel, IEnumerable<ProductViewModel>> ProductList { get; set; }

        [Localized("ProductTypeGroup.TimeFrameId")]
        public System.Int32 TimeFrameId { get; set; }

        public IEnumerable<ProductTypeViewModel> ProductTypeList { get; set; }


        #endregion

        public void CreateMappings()
        {
            //ProductTypeGroupMapper.Config();
            Mapper.Initialize(cfg => cfg.CreateMap<ProductTypeGroup, ProductTypeGroupViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<ProductTypeGroupViewModel, ProductTypeGroup>());
        }

        public ProductTypeGroup GetDomain(ProductTypeGroupViewModel viewmodel)
        {
            var result = Mapper.Map<ProductTypeGroupViewModel, ProductTypeGroup>(viewmodel);
            return result;
        }

        public ProductTypeGroupViewModel GetViewModel(ProductTypeGroup domain)
        {
            var result = Mapper.Map<ProductTypeGroup, ProductTypeGroupViewModel>(domain);
            return result;
        }
    }

    public partial class ProductTypeGroupViewModelForWizard
    {
        public ProductTypeGroupViewModel ProductTypeGroupViewModel { get; set; }
        public ProductTypeViewModel ProductTypeViewModel { get; set; }

        public ProductTypeGroupViewModelForWizard()
        {
            ProductTypeGroupViewModel = new ProductTypeGroupViewModel();
            ProductTypeViewModel = new ProductTypeViewModel();
        }
    }
}