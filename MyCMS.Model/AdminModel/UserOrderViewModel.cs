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
    public partial class UserOrderViewModel : IHaveCustomMappings
    {

        #region Properties
        [Localized("Order.Id")]
        public long Id { get; set; }

        [Localized("Factor.Status")]
        public System.Byte Status { get; set; }

        [Localized("Order.UserId")]
        public int UserId { get; set; }

        public bool IsGuest { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        [Localized("Order.Address")]
        public string Address { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }

        public string Email { get; set; }

        [Localized("Order.PostalCode")]
        public string PostalCode { get; set; }

        [Localized("توضیحات")]
        public string Description { get; set; }

        //--------------------------------------
        [Localized("Factor.PayableAmount")]
        public double? PayableAmount { get; set; }

        [Localized("Factor.TotalAmount")]
        public double? TotalAmount { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        #endregion

        public void CreateMappings()
        {            
            Mapper.Initialize(cfg => cfg.CreateMap<UserOrder, UserOrderViewModel>()

            );
            Mapper.Initialize(cfg => cfg.CreateMap<UserOrderViewModel, UserOrder>()



            );
        }

        public UserOrder GetDomain(UserOrderViewModel viewmodel)
        {
            var result = Mapper.Map<UserOrderViewModel, UserOrder>(viewmodel);
            return result;
        }

        public UserOrderViewModel GetViewModel(UserOrder domain)
        {
            var result = Mapper.Map<UserOrder, UserOrderViewModel>(domain);
            return result;
        }
    }
}