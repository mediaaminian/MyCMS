using MyCMS.Model;
using MyCMS.Model.AdminModel;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface IOptionService
    {
        bool ModeratingComment { get; }
        SiteConfig GetAll();
        void Update(UpdateOptionModel model);
    }
}