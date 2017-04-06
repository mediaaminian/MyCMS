﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyCMS.Datalayer.Context;
using MyCMS.DomainClasses.Entities;
using MyCMS.Servicelayer.Interfaces;

namespace MyCMS.Servicelayer.EFServices
{
    public class MessageService : IMessageService
    {
        private readonly IDbSet<Message> _messages;
        private readonly IUnitOfWork _uow;

        public MessageService(IUnitOfWork uow)
        {
            _uow = uow;
            _messages = _uow.Set<Message>();
        }

        public void Add(Message model)
        {
            _messages.Add(model);
        }


        public IList<Message> GetAll()
        {
            return _messages.Include(m => m.User).OrderByDescending(m => m.AddedDate).ToList();
        }

        public Message Find(int id)
        {
            return _messages.Find(id);
        }

        public void Remove(int id)
        {
            _messages.Remove(_messages.Find(id));
        }
    }
}