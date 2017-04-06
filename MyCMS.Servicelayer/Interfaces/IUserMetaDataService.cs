using MyCMS.DomainClasses.Entities;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface IUserMetaDataService
    {
        void AddUserMetaDataByUserName(UserMetaData userMetaData, string userName);
        void AddUserMetaDataById(UserMetaData userMetaData, int id);
        void UpdateUserMetaData(UserMetaData userMetaData, string userName);
    }
}