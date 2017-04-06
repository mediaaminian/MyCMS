using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.Model.AdminModel
{
    public class SliderDataTableModel
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Picture { get; set; }
        public virtual string Link { get; set; }
        public virtual short Priority { get; set; }
        public virtual string Status { get; set; }

    }
}