using AutoMapper.Configuration;
using MyCMS.Abstraction;
using MyCMS.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using MyCMS.DomainClasses.Entities;
using AutoMapper;

namespace MyCMS.ViewModels
{
    [Validator(typeof(TimeFrameViewModelValidator))]
    public class TimeFrameViewModel : IHaveCustomMappings
    {
        public TimeFrameViewModel()
        {
            //Initialization Properties

        }

        #region [ Prperties ]

        [Localized("TimeFrame.Datestamp")]
        public System.DateTime? Datestamp { get; set; }

        [Localized("TimeFrame.Id")]
        public System.Int32 Id { get; set; }

        [Localized("TimeFrame.Months")]
        public System.Byte Months { get; set; }

        [Localized("TimeFrame.Priority")]
        public System.Int32 Priority { get; set; }

        [Localized("TimeFrame.Status")]
        public System.Byte Status { get; set; }

        [Localized("TimeFrame.Status")]
        public String StatusTitle
        {
            get
            {
                try
                {
                    return DataDictionary.TimeFrameStatusItems[Status].Item2;
                }
                catch (Exception)
                {

                    return "";
                }
            }
        }
        [Localized("TimeFrame.IsNew")]
        public bool IsNew { get; set; }

        public string Name
        {
            get
            {
                return this.Months.ToInt().CalculateMonthName();
            }
        }
        public string TimeFrameTitle { get; set; }

        #endregion        

        public void CreateMappings()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TimeFrame, TimeFrameViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<TimeFrameViewModel, TimeFrame>());
        }

        public  TimeFrame GetDomain(TimeFrameViewModel viewmodel)
        {
            var result = Mapper.Map<TimeFrameViewModel, TimeFrame>(viewmodel);
            return result;
        }

        public TimeFrameViewModel GetViewModel(TimeFrame domain)
        {
            var result = Mapper.Map<TimeFrame, TimeFrameViewModel>(domain);
            return result;
        }
        
    }
}
