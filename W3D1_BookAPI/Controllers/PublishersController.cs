using Microsoft.AspNetCore.Mvc;
using W3D1_BookAPI.ApiModels;
using W3D1_BookAPI.Services;

namespace CS321_W4D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        // Constructor
        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // GET: api/publishers
        [HttpGet]
        public IActionResult Get()
        {
            var publisherModels = _publisherService
                .GetAll()
                .ToApiModels();

            return Ok(publisherModels);
        }

        // GET api/publishers/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var publisher = _publisherService
                .Get(id)
                .ToApiModel();
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        // POST api/publishers
        [HttpPost]
        public IActionResult Post([FromBody] PublisherModel newPublisher)
        {
            try
            {
                _publisherService.Add(newPublisher.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddPublisher", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = newPublisher.Id }, newPublisher);
        }

        // PUT api/publishers/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PublisherModel updatedPublisher)
        {
            var publisher = _publisherService.Update(updatedPublisher.ToDomainModel());
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = _publisherService.Get(id);
            if (publisher == null) return NotFound();
            _publisherService.Remove(publisher);
            return NoContent();
        }
    }

}