using apicrud.Models;
using apicrud.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apicrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<users>> GetAll() => usersservices.GetAll();

        [HttpGet("{id}")]
        public ActionResult<users> Get(int id)
        {
            var users = usersservices.Get(id);
            if (users == null)
                return NotFound();
            return users;
        }
        [HttpPost]
        public ActionResult Create(users users)
        {
            usersservices.Add(users);
            return CreatedAtAction(nameof(Create), new { users.Id }, users);
        }
        [HttpPut("{id}")]
        public ActionResult update(int id, users users)
        {
            if (id != users.Id)
                return BadRequest(id);

            var existing = usersservices.Get(id);
            if (existing is null)
                return NotFound();

            usersservices.update(users);
            return NotFound();
        }
        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            var users = usersservices.Get(id);
            if (users is null)
                return NotFound();
            usersservices.delete(id);
            return NotFound();

        }
    }
}