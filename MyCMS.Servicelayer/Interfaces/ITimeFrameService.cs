using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.RSSModel;
using MyCMS.Servicelayer.EFServices.Enums;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface ITimeFrameService
    {
        void AddTimeFrame(TimeFrameViewModel TimeFrameModel);

        void UpdateTimeFrame(TimeFrameViewModel TimeFrameModel);
        void DeleteTimeFrame(int TimeFrameGroupID);
        IList<TimeFrameViewModel> GetAllTimeFrames();
        IList<TimeFrameViewModel> GetTimeFrame(int page, int count, Order order = Order.Asscending);


        TimeFrameViewModel GetTimeFrameById(int TimeFrameID);

    }
}