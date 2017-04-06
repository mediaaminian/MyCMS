using System;
using System.Web.Mvc;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.Model.AdminModel
{
    public class AddSliderModel
    {
        public AddSliderModel()
        {
        }

        public virtual int SliderId { get; set; }
        public virtual string SliderTitle { get; set; }
        public virtual string SliderPicture { get; set; }
        public virtual string SliderLink { get; set; }
        public virtual string SliderStatus { get; set; } // visible hidden draft 
        public virtual short SliderPriority { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual User EditedByUser { get; set; }
        
    }
    
}