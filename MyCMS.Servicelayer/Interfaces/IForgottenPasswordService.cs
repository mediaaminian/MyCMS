using System;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface IForgottenPasswordService
    {
        void Add(ForgottenPassword model);
        DateTime RequestDate(string key);
        User FindUser(string key);
        void Remove(string key);
    }
}