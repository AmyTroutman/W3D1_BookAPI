using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3D1_BookAPI.Models;

namespace W3D1_BookAPI.Services
{
    public interface IAuthorService
    {
        Author Add(Author newAuthhor);
        Author Get(int id);
        IEnumerable<Author> GetAll();
        Author Update(Author updatedAuthor);
        void Remove(Author Author);
    }
}
