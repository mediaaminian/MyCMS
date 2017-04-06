using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.AdminModel;
using MyCMS.Model.RSSModel;
using MyCMS.Servicelayer.EFServices.Enums;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface ITimeFrameService
    {
        void AddTimeFrame(TimeFrameModel TimeFrameModel);

        void UpdateTimeFrame(TimeFrameModel TimeFrameModel);
        void DeleteTimeFrame(int TimeFrameGroupID);
        IList<TimeFrameModel> GetAllTimeFrames();
        IList<TimeFrameModel> GetTimeFrame(int page, int count, Order order = Order.Asscending);

       
        TimeFrameModel GetTimeFrameById(int TimeFrameID);

    }
}