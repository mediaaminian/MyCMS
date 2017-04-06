using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface IBookImageService
    {
        void AddImage(BookImage bookImage);
        void RemoveImage(int id);
        void EditImage(BookImage bookImage);
        BookImage GetImageById(int id);
        BookImage GetImage(Func<BookImage, bool> expression);
        IList<BookImage> GetAllImages();
    }
}