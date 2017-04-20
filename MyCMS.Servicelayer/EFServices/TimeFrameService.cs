using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyCMS.Datalayer.Context;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model.AdminModel;
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
        public void AddTimeFrame(TimeFrameModel TimeFrameModel)
        {
            Mapper.Initialize(cfg =>
            cfg.CreateMap<TimeFrameModel, TimeFrame>());
            var TimeFrameItem = Mapper.Map<TimeFrame>(TimeFrameModel);
            _TimeFrame.Add(TimeFrameItem);
        }
        [CacheMethod]

        public IList<TimeFrameModel> GetAllTimeFrames()
        {
            var List = _TimeFrame.AsNoTracking().OrderByDescending(c => c.Id).ToList();
            Mapper.Initialize(cfg =>
            cfg.CreateMap<TimeFrame, TimeFrameModel>());

            var ModelList = Mapper.Map<IEnumerable<TimeFrameModel>>(List);
            return ModelList.ToList();

        }


        public IList<TimeFrameModel> GetTimeFrame(int page, int count, Order order = Order.Asscending)
        {
            throw new NotImplementedException();
        }

        public TimeFrameModel GetTimeFrameById(int TimeFrameID)
        {
            throw new NotImplementedException();
        }

        public void UpdateTimeFrame(TimeFrameModel TimeFrameModel)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TimeFrameModel, TimeFrame>());

            var TimeFrameItem = Mapper.Map<TimeFrame>(TimeFrameModel);


            _TimeFrame.Attach(TimeFrameItem);

        }

        public void DeleteTimeFrame(int TimeFrameID)
        {
            _TimeFrame.Remove(_TimeFrame.Find(TimeFrameID));
        }

    }
}