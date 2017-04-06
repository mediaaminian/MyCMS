using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.Model.AdminModel
{
    public class EditCurrencyModel
    {
        public EditCurrencyModel()
        {
        }

        public int CurrencyId { get; set; }
        public string CurrencyTitle { get; set; }
        public string CurrencyKeyword { get; set; }
        public string CurrencyIcon { get; set; }
        public int CurrencyPrice { get; set; }
        public string CurrencyStatus { get; set; } // visible hidden draft 
        public short CurrencyPriority { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public User EditedByUser { get; set; }
    }
}