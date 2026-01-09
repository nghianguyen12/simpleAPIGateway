using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace UserService.Controllers  // <-- important
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase  // <-- must be public
    {
        private static readonly List<User> Users = new()
        {
            new User(1, "John Doe", "john@test.com"),
            new User(2, "Jane Smith", "jane@test.com")
        };

        // GET api/users/1
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // GET api/users/me
        [HttpGet("me")]
        public IActionResult GetCurrentUser()
        {
            var userIdHeader = Request.Headers["X-User-Id"].FirstOrDefault();

            if (string.IsNullOrEmpty(userIdHeader))
                return Unauthorized("Missing user identity");

            var user = Users.FirstOrDefault(u => u.Id.ToString() == userIdHeader);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }

    // Simple user model
    public record User(int Id, string Name, string Email);
}
