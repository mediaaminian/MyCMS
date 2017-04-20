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
    [Validator(typeof(TimeFrameViewModelValidator))]
    public class TimeFrameViewModel : IHaveCustomMappings
    {
        public TimeFrameViewModel()
        {
            //Initialization Properties

        }

        #region [ Prperties ]
        
        [Localized("TimeFrame.Id")]
        public System.Int32 Id { get; set; }
                
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
        public byte[] RowVersion { get; set; }

        //[Localized("TimeFrame.IsNew")]
        //public bool IsNew { get; set; }

        //public string Name
        //{
        //    get
        //    {
        //        return this.Months.ToInt().CalculateMonthName();
        //    }
        //}
        [Localized("TimeFrame.Name")]

        public string Title { get; set; }
        [Localized("TimeFrame.Days")]

        public byte Days { get; set; }
        [Localized("TimeFrame.Picture")]

        public string Picture { get; set; }
        [Localized("TimeFrame.Link")]

        public string Link { get; set; }
        #endregion        

        public void CreateMappings()
        {
            //TimeFrameMapper.Config();
            Mapper.Initialize(cfg => cfg.CreateMap<TimeFrame, TimeFrameViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<TimeFrameViewModel, TimeFrame>()

            );
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
