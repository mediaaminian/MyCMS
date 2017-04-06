using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface IMessageService
    {
        void Add(Message model);
        IList<Message> GetAll();
        Message Find(int id);
        void Remove(int id);
    }
}