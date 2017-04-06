using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyCMS.Datalayer.Context;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.AdminModel;
using MyCMS.Model.RSSModel;
using MyCMS.Servicelayer.EFServices.Enums;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities.Caching;

namespace MyCMS.Servicelayer.EFServices
{
    public class SliderService : ISliderService
    {
        private readonly IDbSet<Slider> _Sliders;

        public SliderService(IUnitOfWork uow)
        {
            _Sliders = uow.Set<Slider>();
        }

        public void AddSlider(Slider Slider)
        {
            _Sliders.Add(Slider);
        }

        public void RemoveSliderById(int id)
        {
            _Sliders.Remove(_Sliders.Find(id));
        }

        public EditSliderModel GetSliderForEdit(int id)
        {
            EditSliderModel SliderModel =
                _Sliders.Where(Slider => Slider.Id == id)
                    .Select(
                        Slider =>
                            new EditSliderModel
                            {
                                SliderId = Slider.Id,
                                SliderPicture = Slider.Picture,
                                SliderTitle = Slider.Title,
                                SliderStatus = Slider.Status,
                                SliderLink = Slider.Link,
                                SliderPriority = Slider.Priority,
                                ModifiedDate = DateTime.Now,
                                EditedByUser = Slider.User
                            })
                    .FirstOrDefault();
            return SliderModel;
        }


        public UpdateSliderStatus UpdateSlider(EditSliderModel SliderModel)
        {
            Slider selectedSlider = _Sliders.Find(SliderModel.SliderId);

            selectedSlider.Picture = SliderModel.SliderPicture;
            selectedSlider.ModifiedDate = SliderModel.ModifiedDate;
            selectedSlider.Status = SliderModel.SliderStatus;
            selectedSlider.Title = SliderModel.SliderTitle;
            selectedSlider.Priority = SliderModel.SliderPriority;
            selectedSlider.ModifiedDate = DateTime.Now;
            selectedSlider.Link = SliderModel.SliderLink;

            return UpdateSliderStatus.Successfull;
        }



        [CacheMethod(SecondsToCache = 20)]
        public SliderModel GetSlider(int id)
        {
            return _Sliders.AsNoTracking().Where(Slider => Slider.Id == id).Select(Slider => new SliderModel
            {
                Id = Slider.Id,
                Picture = Slider.Picture,
                Title = Slider.Title,
                Link = Slider.Link,
                Priority = Slider.Priority,
            }).FirstOrDefault();
        }


        public int Count
        {
            get { return _Sliders.Count(); }
        }


        public Slider Find(int id)
        {
            return _Sliders.Find(id);
        }


       
        [CacheMethod]
        public IList<SliderModel> GetUserSlider(string userName, int page, int count)
        {
            return
                _Sliders.AsNoTracking().Where(Slider => Slider.User.UserName == userName).Select(Slider => new SliderModel
                {
                    Id = Slider.Id,
                    Title = Slider.Title,
                    Picture = Slider.Picture,
                    Link = Slider.Link,
                    Priority = Slider.Priority
                }).OrderByDescending(Slider => Slider.Priority).Skip(page * count).Take(count).ToList();
        }


        public int GetUserSlidersCount(string userName)
        {
            return _Sliders.Count(Slider => Slider.User.UserName == userName);
        }

        [CacheMethod(SecondsToCache = 300)]
        public IList<SiteMapModel> GetSiteMapData(int count)
        {
            return _Sliders.AsNoTracking().OrderByDescending(Slider => Slider.CreatedDate).Take(count).
                Select(Slider => new SiteMapModel
                {
                    Id = Slider.Id,
                    CreatedDate = Slider.CreatedDate,
                    ModifiedDate = Slider.ModifiedDate,
                    Title = Slider.Title
                }).ToList();
        }

        #region Get Sliders Data

        public Slider GetSliderById(int id)
        {
            return _Sliders.Find(id);
        }


        public IList<SliderModel> GetAllSlider()
        {
            return
                _Sliders.AsNoTracking().Select(Slider => new SliderModel
                {
                    Id = Slider.Id,
                    Title = Slider.Title,
                    Picture = Slider.Picture,
                    Link = Slider.Link,
                    Priority = Slider.Priority
                }).ToList();
        }
        public IList<Slider> GetAllSliders()
        {
            return _Sliders.ToList();
        }

        [CacheMethod(SecondsToCache = 120)]
        public IList<Slider> GetSliders(Func<Slider, bool> expression)
        {
            return _Sliders.Where(expression).ToList();
        }

        [CacheMethod]
        public Slider GetSliderDataById(int id)
        {
            return _Sliders.Where(x => x.Id == id).Include(x => x.User).FirstOrDefault();
        }

        #endregion

        #region Get Slider Status

        public SliderStatus GetSliderStatusById(long id)
        {
            const SliderStatus status = SliderStatus.Visible;
            //if (selectedSlider.Status == "visible")
            //{
            //    status = SliderStatus.Visible;
            //}
            //else if (selectedSlider.Status == "hidden")
            //{
            //    status = SliderStatus.Hidden;
            //}
            //else if (selectedSlider.Status == "draft")
            //{
            //    status = SliderStatus.Draft;
            //}
            return status;
        }

        public IList<SliderDataTableModel> GetSliderDataTable(int page, int count, Order order = Order.Asscending,
            SliderOrderBy orderBy = SliderOrderBy.ById)
        {
            IQueryable<SliderDataTableModel> lstSliders =
                _Sliders.Include(Slider => Slider.User)
                    .Select(
                        Slider =>
                            new SliderDataTableModel
                            {
                                Id = Slider.Id,
                                Title = Slider.Title,
                                Priority = Slider.Priority,
                                Status = Slider.Status,
                                Link = Slider.Link,
                                Picture = Slider.Picture
                            })
                    .AsQueryable();

            if (order == Order.Asscending)
            {
                switch (orderBy)
                {
                    case SliderOrderBy.ById:
                        lstSliders = lstSliders.OrderBy(Slider => Slider.Id).AsQueryable();
                        break;
                    case SliderOrderBy.ByTitle:
                        lstSliders = lstSliders.OrderBy(Slider => Slider.Title).AsQueryable();
                        break;
                    case SliderOrderBy.ByPriority:
                        lstSliders = lstSliders.OrderBy(Slider => Slider.Priority).AsQueryable();
                        break;
                }
            }
            else
            {
                switch (orderBy)
                {
                    case SliderOrderBy.ById:
                        lstSliders = lstSliders.OrderByDescending(Slider => Slider.Id).AsQueryable();
                        break;
                    case SliderOrderBy.ByTitle:
                        lstSliders = lstSliders.OrderByDescending(Slider => Slider.Title).AsQueryable();
                        break;
                    case SliderOrderBy.ByPriority:
                        lstSliders = lstSliders.OrderByDescending(Slider => Slider.Priority).AsQueryable();
                        break;
                }
            }
            return lstSliders.Skip(page * count).Take(count).ToList();
        }


        public int GetSlidersCount()
        {
            return _Sliders.Count();
        }

        #endregion
    }
}