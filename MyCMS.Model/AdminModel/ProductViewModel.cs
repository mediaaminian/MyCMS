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
    [Validator(typeof(ProductViewModelValidator))]
    public partial class ProductViewModel : IHaveCustomMappings
    {

        #region [ Prperties ]


        [Localized("Product.Brief")]
        public System.String Brief { get; set; }



        [Localized("Product.Description")]
        public System.String Description { get; set; }

        [Localized("Product.ProductTypeId")]
        public System.Int32 ProductTypeId { get; set; }

        [Localized("Product.Id")]
        public System.Int32 Id { get; set; }


        [Localized("Product.IsExtra")]
        public System.Boolean IsExtra { get; set; }


        [Localized("Product.IsSpecial")]
        public System.Boolean? IsSpecial { get; set; }


        [Localized("تصویر")]
        public System.String Picture { get; set; }

        [Localized("Product.Name")]
        public System.String Name { get; set; }

        [Localized("Product.OrderDescription")]
        public System.String OrderDescription { get; set; }

        [Localized("Product.Priority")]
        public System.Int32? Priority { get; set; }

        [Localized("Product.Status")]
        public System.Byte Status { get; set; }

        [Localized("Product.Status")]
        public String StatusTitle
        {
            get
            {
                try
                {
                    return DataDictionary.ProductStatusItems[Status].Item2;
                }
                catch (Exception)
                {

                    return "";
                }
            }
        }


        [Localized("Product.TypeName")]
        public string ProductTypeName { get; set; }
        

        [Localized("Product.IsExtra")]
        public string IsExtraT
        {
            get
            {
                if (this.IsExtra == true)
                    return "می باشد";
                else
                    return "نمی باشد";
            }
        }
        

        [Localized("Product.IsSpecial")]
        public string IsSpecialT
        {
            get
            {
                if (this.IsSpecial == true)
                    return "می باشد";
                else
                    return "نمی باشد";
            }
        }

        public int? UserId { get; set; }
        public  byte[] RowVersion { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ProductTypeGroupId { get; set; }

        #endregion

        public void CreateMappings()
        {
            //ProductMapper.Config();
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductViewModel>()

            );
            Mapper.Initialize(cfg => cfg.CreateMap<ProductViewModel, Product>()

            );
        }

        public Product GetDomain(ProductViewModel viewmodel)
        {
            var result = Mapper.Map<ProductViewModel, Product>(viewmodel);
            return result;
        }

        public ProductViewModel GetViewModel(Product domain)
        {
            var result = Mapper.Map<Product, ProductViewModel>(domain);
            return result;
        }
    }
}