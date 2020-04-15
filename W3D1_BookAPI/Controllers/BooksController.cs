using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(_bookService.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Book currentBook = _bookService.Get(id);
            if (currentBook != null) return Ok(currentBook);
            return BadRequest();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Book newBook)
        {
            Book book = _bookService.Add(newBook);
            if (book != null)
            {
                return CreatedAtAction("Get", new { Id = newBook.Id }, newBook);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book updatedBook)
        {
            try
            {
                Book book = _bookService.Update(updatedBook);
                if (book != null)
                {
                    return Ok(book);
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("UpdateBookError", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Book currentBook = _bookService.Get(id);
            _bookService.Remove(currentBook);
        }
    }
}
