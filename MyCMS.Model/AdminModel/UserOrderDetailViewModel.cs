using AutoMapper.Configuration;
using MyCMS.Abstraction;
using MyCMS.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using MyCMS.DomainClasses.Entities;
using AutoMapper;

namespace MyCMS.Model
{
    public class UserOrderDetailViewModel : IHaveCustomMappings
    {
        #region [ Prperties ]


        [Localized("OrderDetail.Id")]
        public long Id { get; set; }

        [Localized("OrderDetail.Status")]
        public System.Byte Status { get; set; }

        [Localized("OrderDetail.Status")]
        public String StatusTitle
        {
            get
            {
                try
                {
                    return DataDictionary.OrderDetailStatusItems[Status].Item2;
                }
                catch (Exception)
                {

                    return "";
                }
            }
        }

        [Localized("OrderDetail.OrderID")]
        public Int64 UserOrderId { get; set; }

        [Localized("Product.ProductName")]
        public Int32 ProductId { get; set; }


        [Localized("OrderDetail.IsExtra")]
        public bool? IsExtra { get; set; }


        [Localized("OrderDetail.TimeFrameID")]
        public Int32 TimeFrameId { get; set; }

        [Localized("OrderDetail.SetupFee")]
        public float SetupFee { get; set; }

        [Localized("OrderDetail.Fees")]
        public double Fee { get; set; }

        [Localized("OrderDetail.Description")]
        public string Description { get; set; }

        [Localized("OrderDetail.ServiceID")]
        public Int64? ServiceId { get; set; }

        [Localized("OrderDetail.ServiceName")]
        public string ServiceName { get; set; }

        [Localized("OrderDetail.ProductName")]
        public string ProductName { get; set; }

        [Localized("OrderDetail.ProductTypeGroupName")]
        public string ProductTypeGroupName { get; set; }

        [Localized("OrderDetail.TimeFrameMonths")]
        public string TimeFramePeriod { get; set; }

        [Localized("OrderDetail.OperationType")]
        public int OperationType { get; set; }
        
        #endregion

        public void CreateMappings()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserOrderDetail, UserOrderDetailViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<UserOrderDetailViewModel, UserOrderDetail>());
        }

        public UserOrderDetail GetDomain(UserOrderDetailViewModel viewmodel)
        {
            var result = Mapper.Map<UserOrderDetailViewModel, UserOrderDetail>(viewmodel);
            return result;
        }

        public UserOrderDetailViewModel GetViewModel(UserOrderDetail domain)
        {
            var result = Mapper.Map<UserOrderDetail, UserOrderDetailViewModel>(domain);
            return result;
        }
    }
}