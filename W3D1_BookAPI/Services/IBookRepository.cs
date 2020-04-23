using System.Collections.Generic;
using W3D1_BookAPI.Models;

namespace W3D1_BookAPI.Services
{
    public interface IBookRepository
    {
        Book Add(Book book);
        Book Get(int Id);
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetBooksForAuthor(int Id);
        //Do I need this:
        //IEnumerable<Book> GetBooksForPublisher(int Id);
        void Remove(Book book);
        Book Update(Book updatedBook);
    }
}
