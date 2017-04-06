using System;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.Model.AdminModel
{
    public class AddCurrencyModel
    {
        public AddCurrencyModel()
        {
        }

        public virtual int CurrencyId { get; set; }
        public virtual string CurrencyTitle { get; set; }
        public virtual string CurrencyKeyword { get; set; }
        public virtual string CurrencyIcon { get; set; }
        public virtual int CurrencyPrice { get; set; }
        public virtual string CurrencyStatus { get; set; } // visible hidden draft 
        public virtual short CurrencyPriority { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual User EditedByUser { get; set; }
        
    }
    
}