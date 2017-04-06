using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.LuceneModel;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface IBookService
    {
        int Count { get; }
        void AddBook(Book book);
        void DeleteBookById(int id);
        void EditBook(Book book);
        IList<Book> GetAllBooks();
        Book GetBookById(int id);
        Book GetBook(Func<Book, bool> expression);
        IList<SliderImagesModel> GetSliderImages(int count);
        IList<LuceneBookModel> GetAllForLuceneIndex();
    }
}