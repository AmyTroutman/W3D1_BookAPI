using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookContext.Books
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .ToList();
            //return _bookContext.Books;
        }

        public IEnumerable<Book> GetBooksForAuthor(int authorId)
        {
            return _bookContext.Books
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .Where(b => b.AuthorId == authorId)
                .ToList();
        }

        public IEnumerable<Book> GetBooksForPublisher(int publisherID)
        {
            return _bookContext.Books
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .Where(b => b.PublisherId == publisherID)
                .ToList();           
        }

        public Book Update(Book updatedBook)
        {
            var currentBook = _bookContext.Books.Find(updatedBook.Id);
            if (currentBook == null) return null;

            _bookContext.Entry(currentBook)
                .CurrentValues
                .SetValues(updatedBook);

            _bookContext.Books.Update(currentBook);
            _bookContext.SaveChanges();
            return currentBook;
        }

        public void Remove(Book book)
        {
            Book currentBook = _bookContext.Books.FirstOrDefault(b => b.Id == book.Id);
            if (currentBook != null)
            {
                _bookContext.Books.Remove(currentBook);
                _bookContext.SaveChanges();
            }
            else
            {
                throw new Exception("Book not found!");
            }
        }
    }
}
