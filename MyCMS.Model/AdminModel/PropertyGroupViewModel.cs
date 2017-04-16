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
    [Validator(typeof(PropertyGroupViewModelValidator))]
	public partial class PropertyGroupViewModel : IHaveCustomMappings
    {

        #region [ Prperties ]

        [Localized("PropertyGroup.Datestamp")]
        public System.DateTime? Datestamp { get; set; }

        [Localized("PropertyGroup.Id")]
        public System.Int32 Id { get; set; }

        [Localized("PropertyGroup.Name")]
        public System.String Name { get; set; }
        [Localized("PropertyGroup.Priority")]
        public System.Int32 Priority { get; set; }

        [Localized("تصویر")]
        public System.String Picture { get; set; }

        [Localized("توضیحات")]
        public System.String Description { get; set; }


        [Localized("PropertyGroup.Status")]
        public System.Byte Status { get; set; }

        [Localized("PropertyGroup.Status")]
        public String StatusTitle
        {
            get
            {
                try
                {
                    return DataDictionary.PropertyGroupStatusItems[Status].Item2;
                }
                catch (Exception)
                {

                    return "";
                }
            }
        }

        

        public Dictionary<PropertyViewModel, ProductPropertyViewModel> Propertieslist { get; set; }

        public int ProductId { get; set; }

        [Localized("PropertyGroup.ProductTypeGroupID")]
        public int ProductTypeGroupId { get; set; }


        #endregion        
        public void CreateMappings()
        {
            //PropertyGroupMapper.Config();
            Mapper.Initialize(cfg => cfg.CreateMap<PropertyGroup, PropertyGroupViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<PropertyGroupViewModel, PropertyGroup>());
        }

        public PropertyGroup GetDomain(PropertyGroupViewModel viewmodel)
        {
            var result = Mapper.Map<PropertyGroupViewModel, PropertyGroup>(viewmodel);
            return result;
        }

        public PropertyGroupViewModel GetViewModel(PropertyGroup domain)
        {
            var result = Mapper.Map<PropertyGroup, PropertyGroupViewModel>(domain);
            return result;
        }
    }
}