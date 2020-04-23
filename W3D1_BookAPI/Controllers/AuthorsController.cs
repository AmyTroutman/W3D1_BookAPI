using System;
using Microsoft.AspNetCore.Mvc;
using W3D1_BookAPI.Services;
using W3D1_BookAPI.Models;
using W3D1_BookAPI.ApiModels;

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
            var authorModels = _AuthorService
                .GetAll()
                .ToApiModels();
            return Ok(authorModels);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var author = _AuthorService
                .Get(id)
                .ToApiModel();
            if (author == null) return NotFound();
            return Ok(author);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] AuthorModel newAuthor)
        {
            try
            {
                _AuthorService.Add(newAuthor.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddAuthor", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { id = newAuthor.Id }, newAuthor);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AuthorModel updatedAuthor)
        {
            var author = _AuthorService.Update(updatedAuthor.ToDomainModel());
            if (author == null) return NotFound();
            return Ok(author);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _AuthorService.Get(id);
            if (author == null) return NotFound();
            _AuthorService.Remove(author);
            return NoContent();
        }
    }

}
