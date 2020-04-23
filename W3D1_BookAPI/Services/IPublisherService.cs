using System.Collections.Generic;
using W3D1_BookAPI.Models;

namespace W3D1_BookAPI.Services
{
    public interface IPublisherService
    {
        Publisher Add(Publisher publisher);
        Publisher Get(int id);
        Publisher Update(Publisher publisher);
        void Remove(Publisher publisher);
        IEnumerable<Publisher> GetAll();
    }
}
