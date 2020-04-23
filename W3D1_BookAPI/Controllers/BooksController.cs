using System;
using Microsoft.AspNetCore.Mvc;
using W3D1_BookAPI.ApiModels;
using W3D1_BookAPI.Models;
using W3D1_BookAPI.Services;

namespace W3D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var bookModels = _bookService
                .GetAll()
                .ToApiModels();
            return Ok(bookModels);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookService.Get(id).ToApiModel();
            if (book == null) return NotFound();
            return Ok(book);
        }

        //GET api/author/{authorId}/books
        [HttpGet("/api/author/{authorId}/books")]
        public IActionResult GetBooksForAuthor(int authorId)
        {
            var bookModels = _bookService
                .GetBooksForAuthor(authorId)
                .ToApiModels();
            return Ok(bookModels);
        }

        //GET api/publisher/{publisherId}/books
        [HttpGet("/api/publisher/{publisherId}/books")]
        public IActionResult GetBooksForPublisher(int publisherId)
        {
            var bookModels = _bookService
                .GetBooksForPublisher(publisherId)
                .ToApiModels();
            return Ok(bookModels);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] BookModel newBook)
        {
            try
            {
                _bookService.Add(newBook.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddBook", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = newBook.Id }, newBook);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookModel updatedBook)
        {
            var book = _bookService.Update(updatedBook.ToDomainModel());
            if (book == null) return NotFound();
            return Ok(book.ToApiModel());
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.Get(id);
            if (book == null) return NotFound();
            _bookService.Remove(book);
            return NoContent();
        }
    }
}
