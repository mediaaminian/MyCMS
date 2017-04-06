using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.Model.AdminModel
{
    public class EditSliderModel
    {
        public EditSliderModel()
        {
        }

        public int SliderId { get; set; }
        public string SliderTitle { get; set; }
        public string SliderPicture { get; set; }
        public string SliderLink { get; set; }
        public string SliderStatus { get; set; } // visible hidden draft 
        public short SliderPriority { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public User EditedByUser { get; set; }
    }
}