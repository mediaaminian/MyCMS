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
    [Validator(typeof(InvoiceViewModelValidator))]
    public class InvoiceViewModel : IHaveCustomMappings
    {
        public InvoiceViewModel()
        {
            //Initialization Properties

        }

        #region [ Prperties ]


        [Localized("Factor.Id")]
        public int Id { get; set; }

        [Localized("Factor.OrderID")]

        public Int32? UserOrderId { get; set; }

        [Localized("Factor.UserID")]
        public int UserId { get; set; }

        [Localized("Factor.PrintNumber")]
        public int PrintNumber { get; set; }

        public UserOrderViewModel UserOrder { get; set; }

        [Localized("Factor.FactorOwner")]
        public string FactorOwner { get; set; }

        [Localized("Factor.Paid")]
        public bool Paid { get; set; }

        [Localized("Factor.Paid")]
        public String PaidTitle
        {
            get
            {
                try
                {
                    return DataDictionary.FactorPaidStatusItems[Status].Item2;
                }
                catch (Exception)
                {

                    return "";
                }
            }
        }

        [Localized("Factor.Description")]
        public string Description { get; set; }


        [Localized("Factor.Status")]
        public System.Byte Status { get; set; }

        [Localized("Factor.Status")]
        public String StatusTitle
        {
            get
            {
                try
                {
                    return DataDictionary.FactorStatusItems[Status].Item2;

                }
                catch (Exception)
                {

                    return "";
                }
            }
        }
        #endregion

        public void CreateMappings()
        {
           //InvoiceMapper.Config();
            Mapper.Initialize(cfg => cfg.CreateMap<Invoice, InvoiceViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<InvoiceViewModel, Invoice>());
        }

        public  Invoice GetDomain(InvoiceViewModel viewmodel)
        {
            var result = Mapper.Map<InvoiceViewModel, Invoice>(viewmodel);
            return result;
        }

        public InvoiceViewModel GetViewModel(Invoice domain)
        {
            var result = Mapper.Map<Invoice, InvoiceViewModel>(domain);
            return result;
        }
        
    }
}
