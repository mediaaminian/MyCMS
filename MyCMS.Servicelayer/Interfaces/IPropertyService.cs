using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.AdminModel;
using MyCMS.Model.RSSModel;
using MyCMS.Servicelayer.EFServices.Enums;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface IPropertyService
    {
        void AddProperty(PropertyModel PropertyModel);

        void UpdateProperty(PropertyModel PropertyModel);
        void DeleteProperty(int PropertyGroupID);
        IList<PropertyModel> GetAllProperties();
        IList<PropertyModel> GetProperty(int page, int count, Order order = Order.Asscending);

       
        PropertyModel GetPropertyById(int PropertyID);

    }
}