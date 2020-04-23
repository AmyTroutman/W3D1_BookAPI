using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return _BookContext.Authors.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _BookContext.Authors.ToList();                
        }

        public Author Update(Author updatedAuthor)
        {
            var currenAuthor = _BookContext.Authors.Find(updatedAuthor.Id);
            if (currenAuthor == null) return null;

            _BookContext.Entry(currenAuthor)
                .CurrentValues
                .SetValues(updatedAuthor);

            _BookContext.Authors.Update(currenAuthor);
            _BookContext.SaveChanges();
            return currenAuthor;
        }

        public void Remove(Author Author)
        {
            _BookContext.Authors.Remove(Author);
            _BookContext.SaveChanges();
        }
    }
}
