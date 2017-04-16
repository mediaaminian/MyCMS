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
    [Validator(typeof(PropertyViewModelValidator))]
	public partial class PropertyViewModel : IHaveCustomMappings
    {

        #region [ Prperties ]



        [Localized("Property.Id")]
        public System.Int32 Id { get; set; }

        [Localized("Property.Datestamp")]
        public System.DateTime? Datestamp { get; set; }

        [Localized("Property.Description")]
        public System.String Description { get; set; }

        [Localized("Property.PropertyGroupId")]
        public System.Int32 PropertyGroupId { get; set; }

        [Localized("Property.ScaleGroupID")]
        public string ScaleGroupId { get; set; }

        [Localized("Property.ScaleGroupID")]
        public string ScaleGroupTitle { get; set; }

        [Localized("Property.IsFilterable")]
        public System.Boolean IsFilterable { get; set; }

        [Localized("Property.IsDefault")]
        public System.Boolean IsDefault { get; set; }

        [Localized("Property.IsVisible")]
        public System.Boolean IsVisible { get; set; }

        [Localized("Property.Name")]
        public System.String Name { get; set; }

        [Localized("Property.Priority")]
        public System.Int32 Priority { get; set; }

        [Localized("Property.Status")]
        public System.Byte Status { get; set; }

        [Localized("Property.DataType")]
        public enumDataType DataType { get; set; }

        [Localized("Property.DefaultValue")]
        public string DefaultValue { get; set; }

        [Localized("Property.Status")]
        public String StatusTitle
        {
            get
            {
                try
                {
                    return DataDictionary.PropertyStatusItems[Status].Item2;
                }
                catch (Exception)
                {

                    return "";
                }
            }

        }        
        
        [Localized("Property.IsNew")]
        public bool IsNew { get; set; }


        [Localized("Property.PropertyGroupId")]
        public string PropertyGroupTitle { get; set; }

        [Localized("Property.ScaleId")]
        public string ScaleTitle { get; set; }

        [Localized("Property.ScaleId")]
        public string ScaleId { get; set; }


        public string TextDefaultValue
        {
            get
            {
                if (this.DataType == enumDataType.Int && DefaultValue != null)
                {
                    return DefaultValue;
                }
                else
                    return "";
            }
            set
            {
                if (this.DataType == enumDataType.String)
                    if (value != null)
                        DefaultValue = value.ToString();
            }
        }

        public Boolean BooleanDefaultValue
        {
            get
            {
                if (this.DataType == enumDataType.Boolean && DefaultValue != null)
                {
                    return Boolean.Parse(this.DefaultValue);
                }
                else
                    return false;
            }

            set
            {
                if (this.DataType == enumDataType.Boolean)
                    if (value != null)
                        DefaultValue = value.ToString();
            }
        }

        public int? IntDefaultValue
        {
            get
            {
                if (this.DataType == enumDataType.Int && DefaultValue != null)
                {
                    return int.Parse(DefaultValue);
                }
                else
                    return 0;
            }

            set
            {
                if (this.DataType == enumDataType.Int)
                    if (value != null)
                        DefaultValue = value.ToString();
            }
        }

        public float? FloatDefaultValue
        {
            get
            {
                if (this.DataType == enumDataType.Float && DefaultValue != null)
                {
                    return float.Parse(DefaultValue);
                }
                else
                    return 0;
            }
            set
            {
                if (this.DataType == enumDataType.Float)
                    if (value != null)
                        DefaultValue = value.ToString();
            }
        }


        [Localized("Property.ProductTypeGroupID")]
        public int ProductTypeGroupId { get; set; }

        #endregion
        public void CreateMappings()
        {
            //PropertyMapper.Config();
            Mapper.Initialize(cfg => cfg.CreateMap<Property, PropertyViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<PropertyViewModel, Property>());
        }

        public Property GetDomain(PropertyViewModel viewmodel)
        {
            var result = Mapper.Map<PropertyViewModel, Property>(viewmodel);
            return result;
        }

        public PropertyViewModel GetViewModel(Property domain)
        {
            var result = Mapper.Map<Property, PropertyViewModel>(domain);
            return result;
        }
    }
}