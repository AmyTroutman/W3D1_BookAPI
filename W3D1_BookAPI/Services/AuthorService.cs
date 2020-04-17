using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3D1_BookAPI.Data;
using W3D1_BookAPI.Models;
using W3D1_BookAPI.Services;

namespace W3D1_AuthorAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BookContext _BookContext;

        public AuthorService(BookContext BookContext)
        {
            _BookContext = BookContext;
        }

        //_ means this is a private variable
        public Author Add(Author newAuthor)
        {
            _BookContext.Add(newAuthor);
            _BookContext.SaveChanges();
            return newAuthor;
        }

        public Author Get(int id)
        {
            return _BookContext.Authors
                .Include(a=> a.Books)
                .FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _BookContext.Authors
                .Include(a=> a.Books)
                .ToList();
            //return _BookContext.Authors;
        }

        public void Remove(Author Author)
        {
            Author currentAuthor = _BookContext.Authors.FirstOrDefault(a => a.Id == Author.Id);
            if (currentAuthor != null)
            {
                _BookContext.Authors.Remove(currentAuthor);
                _BookContext.SaveChanges();
            }
            else
            {
                throw new Exception("Author not found!");
            }
        }

        public Author Update(Author updatedAuthor)
        {
            Author currentAuthor = _BookContext.Authors.FirstOrDefault(a => a.Id == updatedAuthor.Id);
            if (currentAuthor != null)
            {
                _BookContext.Entry<Author>(currentAuthor).CurrentValues.SetValues(updatedAuthor);
                _BookContext.Authors.Update(currentAuthor);
                _BookContext.SaveChanges();
                return currentAuthor;
            }
            return null;
            //check recording ~8pm
        }
    }

}
