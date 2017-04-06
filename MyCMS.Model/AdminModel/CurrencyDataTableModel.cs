using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.Model.AdminModel
{
    public class CurrencyDataTableModel
    {
        public int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Keyword { get; set; }
        public virtual int Price { get; set; }
        public virtual string Icon { get; set; }
        public virtual short Priority { get; set; }
        public virtual string Status { get; set; }
    }
}