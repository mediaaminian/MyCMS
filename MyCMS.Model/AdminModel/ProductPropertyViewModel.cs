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

        public int? IntValue
        {
            get
            {
                if (Value!=null)
                    return int.Parse(Value);
                else if (string.IsNullOrWhiteSpace(DefaultValue))
                    return int.Parse(DefaultValue);
                else
                    return 0;
                /*
                try
                {
                    return int.Parse(Value);

                }
                catch {
                    try
                    {
                        return int.Parse(DefaultValue);
                    }
                    catch (Exception)
                    {

                        return 0;
                    }

                }*/
                
            }
            set
            {
                Value = value.ToString();
            }
        }

        public string StringValue
        {
            get
            {

                try
                {
                    return Value;

                }
                catch 
                {

                    try
                    {
                        return DefaultValue;
                    }
                    catch (Exception)
                    {

                        return "";
                    }
                }
            }
            set
            {
                Value = value;
            }
        }

        public bool? BoolValue
        {
            get
            {
                return Value!=null && Boolean.Parse(Value);
                
                /*
                try
                {
                    return Boolean.Parse(Value);

                }
                catch 
                {
                    try
                    {

                    
                    return Boolean.Parse(DefaultValue);
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                }*/
            }
            set
            {
                Value = value.ToString();
            }
        }

        public float? FloatValue
        {
            get
            {
                try
                {
                    return float.Parse(Value);
                }
                catch 
                {
                    try
                    {
                        return float.Parse(DefaultValue);
                    }
                    catch (Exception)
                    {

                        return 0;
                    }
                    
                }
            }
            set
            {
                Value = value.ToString();
            }
        }

        public bool UseDefaultValue { get; set; }

        [Localized("ProductProperty.FkPropertyName")]
        public string PropertyTitle { get; set; }


        [Localized("ProductProperty.DataType")]
        public enumDataType DataType { get; set; }

        #endregion

        public void CreateMappings()
        {
            //ProductPropertyMapper.Config();
            Mapper.Initialize(cfg => cfg.CreateMap<ProductProperty, ProductPropertyViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<ProductPropertyViewModel, ProductProperty>());
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