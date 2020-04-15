using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3D1_BookAPI.Models;

namespace W3D1_BookAPI.Services
{
    public interface IBookService
    {
        Book Add(Book newBook);
        Book Get(int id);
        IEnumerable<Book> GetAll();
        Book Update(Book updatedBook);
        void Remove(Book book);
    }
}
