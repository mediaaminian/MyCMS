using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.AdminModel;
using MyCMS.Servicelayer.EFServices.Enums;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface IPropertyGroupService
    {
        void AddPropertyGroup(PropertyGroupModel PropertyGroupModel);

        void UpdatePropertyGroup(PropertyGroupModel PropertyGroupModel);
        void DeletePropertyGroup(int PropertyGroupID);
        IList<PropertyGroupModel> GetAllPropertyGroup();
        IList<PropertyGroupModel> GetPropertyGroup(int page, int count, Order order = Order.Asscending);
        PropertyGroupModel GetPropertyGroupById(int PropertyGroupID);

    }
}