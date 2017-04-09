using AutoMapper;
using AutoMapper.Configuration;

namespace MyCMS.Abstraction
{
    public interface IHaveCustomMappings<T>
    {
        void CreateMappings();
        T GetDomain(this T viewmodel)
        T GetViewModel(this T domain)
    }
}
