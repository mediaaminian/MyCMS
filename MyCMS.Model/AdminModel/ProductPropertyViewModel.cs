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
    [Validator(typeof(ProductPropertyViewModelValidator))]
	public partial class ProductPropertyViewModel : IHaveCustomMappings
    {

        #region [ Prperties ]

        [Localized("ProductProperty.Id")]
        public System.Int32 Id { get; set; }


        [Localized("ProductProperty.FkProductId")]
        public System.Int32 ProductId { get; set; }

        [Localized("ProductProperty.Value")]
        public System.String Value { get; set; }

        [Localized("ProductProperty.Status")]
        public System.Byte Status { get; set; }

        [Localized("ProductProperty.Status")]
        public String StatusTitle
        {
            get
            {
                try
                {
                    return DataDictionary.ProductPropertyStatusItems[Status].Item2;
                }
                catch (Exception)
                {

                    return "";
                }
            }
        }        
        

        public string DefaultValue { get; set; }

  



        public bool UseDefaultValue { get; set; }

        [Localized("ProductProperty.FkPropertyName")]
        public string PropertyTitle { get; set; }
        public int PropertyId { get; set; }
        public byte[] RowVersion { get; set; }


        #endregion
        /// <summary>
        /// اینا دیگه استفاده نمیشه
        /// </summary>
        public void CreateMappings()
        {
            //ProductPropertyMapper.Config();
            Mapper.Initialize(cfg => cfg.CreateMap<ProductProperty, ProductPropertyViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<ProductPropertyViewModel, ProductProperty>()
            .ForMember(q=>q.Product,q=>q.Ignore())
            .ForMember(q => q.Property, q=>q.Ignore())
            );
        }

        public ProductProperty GetDomain(ProductPropertyViewModel viewmodel)
        {
            var result = Mapper.Map<ProductPropertyViewModel, ProductProperty>(viewmodel);
            return result;
        }

        public ProductPropertyViewModel GetViewModel(ProductProperty domain)
        {
            var result = Mapper.Map<ProductProperty, ProductPropertyViewModel>(domain);
            return result;
        }
    }
}