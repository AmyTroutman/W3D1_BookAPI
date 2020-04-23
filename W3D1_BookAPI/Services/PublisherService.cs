using System;
using System.Collections.Generic;
using System.Linq;
using W3D1_BookAPI.Data;
using W3D1_BookAPI.Models;

namespace W3D1_BookAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly BookContext _bookContext;

        public PublisherService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public Publisher Add(Publisher publisher)
        {
            _bookContext.Publishers.Add(publisher);
            _bookContext.SaveChanges();
            return publisher;
        }

        public Publisher Get(int id)
        {
            return _bookContext.Publishers.Find(id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _bookContext.Publishers.ToList();
        }

        public Publisher Update(Publisher updatePublisher)
        {
            var currentPublisher = _bookContext.Publishers.Find(updatePublisher.Id);

            if (currentPublisher == null) return null;

            _bookContext.Entry(currentPublisher)
                .CurrentValues
                .SetValues(updatePublisher);
            _bookContext.Publishers.Update(currentPublisher);
            _bookContext.SaveChanges();
            return currentPublisher;
        }

        public void Remove(Publisher publisher)
        {
            _bookContext.Publishers.Remove(publisher);
            _bookContext.SaveChanges();
        }
    }
}
