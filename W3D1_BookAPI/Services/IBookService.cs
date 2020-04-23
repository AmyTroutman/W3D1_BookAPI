using System;
using System.Collections.Generic;
using W3D1_BookAPI.Models;

namespace W3D1_BookAPI.Services
{
    public interface IBookService
    {
        Book Add(Book newBook);
        Book Get(int id);
        Book Update(Book updatedBook);
        void Remove(Book book);
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetBooksForAuthor(int authorId);
        IEnumerable<Book> GetBooksForPublisher(int publisherId);
    }
}
