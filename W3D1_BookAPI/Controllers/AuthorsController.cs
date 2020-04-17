using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using W3D1_BookAPI.Services;
using W3D1_BookAPI.Models;

namespace W3D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _AuthorService;

        public AuthorsController(IAuthorService AuthorService)
        {
            _AuthorService = AuthorService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_AuthorService.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Author currentAuthor = _AuthorService.Get(id);
            if (currentAuthor != null) return Ok(currentAuthor);
            return BadRequest();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Author newAuthor)
        {
            Author author = _AuthorService.Add(newAuthor);
            if (author != null)
            {
                return CreatedAtAction("Get", new { Id = newAuthor.Id }, newAuthor);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author updatedAuthor)
        {
            try
            {
                Author author = _AuthorService.Update(updatedAuthor);
                if (author != null)
                {
                    return Ok(author);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateAuthorError", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Author currentAuthor = _AuthorService.Get(id);
            _AuthorService.Remove(currentAuthor);
        }
    }

}
