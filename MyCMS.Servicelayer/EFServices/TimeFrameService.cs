using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyCMS.Datalayer.Context;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Servicelayer.EFServices.Enums;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities.Caching;
using AutoMapper;


namespace MyCMS.Servicelayer.EFServices
{
    public class TimeFrameService : ITimeFrameService
    {

        private readonly IDbSet<TimeFrame> _TimeFrame;
        private readonly IMappingEngine _mappingEngine;
        private readonly IUnitOfWork _unitOfWork;

        public TimeFrameService(IUnitOfWork uow, IMappingEngine mappingEngine)
        {
            _unitOfWork = uow;
            _mappingEngine = mappingEngine;
            _TimeFrame = uow.Set<TimeFrame>();
        }
        public void AddTimeFrame(TimeFrameViewModel TimeFrameModel)
        {
            TimeFrame TimeFrameItem = new TimeFrame();
            _mappingEngine.Map(source: TimeFrameModel, destination: TimeFrameItem);
            _TimeFrame.Add(TimeFrameItem);
        }
        [CacheMethod]

        public IList<TimeFrameViewModel> GetAllTimeFrames()
        {
            var List = _TimeFrame.ToList();

            var ModelList = new List<TimeFrameViewModel>();
            _mappingEngine.Map(source: List, destination: ModelList); 
            return ModelList.ToList();

        }


        public IList<TimeFrameViewModel> GetTimeFrame(int page, int count, Order order = Order.Asscending)
        {
            throw new NotImplementedException();
        }

        public TimeFrameViewModel GetTimeFrameById(int TimeFrameID)
        {
            throw new NotImplementedException();
        }

        public void UpdateTimeFrame(TimeFrameViewModel TimeFrameModel)
        {
            TimeFrame TimeFrameItem = new TimeFrame();
            _mappingEngine.Map(source: TimeFrameModel, destination: TimeFrameItem);
            _TimeFrame.Attach(TimeFrameItem);

        }

        public void DeleteTimeFrame(int TimeFrameID)
        {
            _TimeFrame.Remove(_TimeFrame.Find(TimeFrameID));
        }

    }
}