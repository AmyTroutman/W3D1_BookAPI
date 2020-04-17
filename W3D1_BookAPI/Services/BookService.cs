using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3D1_BookAPI.Data;
using W3D1_BookAPI.Models;

namespace W3D1_BookAPI.Services
{
    public class BookService : IBookService
    {
        private readonly BookContext _bookContext;

        public BookService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        //_ means this is a private variable
        public Book Add(Book newBook)
        {
            _bookContext.Add(newBook);
            _bookContext.SaveChanges();
            return newBook;
        }

        public Book Get(int id)
        {
            return _bookContext.Books
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookContext.Books
                .Include(b => b.Author)
                .ToList();
            //return _bookContext.Books;
        }

        public void Remove(Book book)
        {
            Book currentBook = _bookContext.Books.FirstOrDefault(b => b.Id == book.Id);
            if(currentBook != null)
            {
                _bookContext.Books.Remove(currentBook);
                _bookContext.SaveChanges();
            }
            else
            {
                throw new Exception("Book not found!");
            }
        }

        public Book Update(Book updatedBook)
        {
            Book currentBook = _bookContext.Books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if(currentBook != null)
            {
                _bookContext.Entry<Book>(currentBook).CurrentValues.SetValues(updatedBook);
                _bookContext.Books.Update(currentBook);
                _bookContext.SaveChanges();
                return currentBook;
            }
            return null;
            //check recording ~8pm
        }
    }
}
