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



        [Localized("Property.Description")]
        public System.String Description { get; set; }

        [Localized("Property.PropertyGroupId")]
        public System.Int32 PropertyGroupId { get; set; }




        [Localized("Property.IsFilterable")]
        public System.Boolean IsFilterable { get; set; }


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
        



        [Localized("Property.PropertyGroupId")]
        public string PropertyGroupTitle { get; set; }





        [Localized("Property.ProductTypeGroupID")]
        public int ProductTypeGroupId { get; set; }

        public bool IsVisibleInProductDetail { get; set; }
        public bool IsVisibleInNotification { get; set; }
        public bool IsVisibleInAdvertisements { get; set; }
        public  byte[] RowVersion { get; set; }
        #endregion
        public void CreateMappings()
        {
            //PropertyMapper.Config();
            Mapper.Initialize(cfg => cfg.CreateMap<Property, PropertyViewModel>()
            
            );
            Mapper.Initialize(cfg => cfg.CreateMap<PropertyViewModel, Property>()

            
            );
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