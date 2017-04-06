using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.AdminModel;
using MyCMS.Model.RSSModel;
using MyCMS.Servicelayer.EFServices.Enums;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface ISliderService
    {
        int Count { get; }
        void AddSlider(Slider Slider);
        void RemoveSliderById(int id);
        Slider GetSliderById(int id);
        IList<SliderModel> GetAllSlider();
        IList<Slider> GetAllSliders();
        IList<Slider> GetSliders(Func<Slider, bool> expression);
        SliderStatus GetSliderStatusById(long id);

        IList<SliderDataTableModel> GetSliderDataTable(int page, int count, Order order = Order.Asscending,
            SliderOrderBy orderBy = SliderOrderBy.ById);

        int GetSlidersCount();
        EditSliderModel GetSliderForEdit(int id);
        UpdateSliderStatus UpdateSlider(EditSliderModel SliderModel);
        SliderModel GetSlider(int id);
        Slider Find(int id);
    }
}