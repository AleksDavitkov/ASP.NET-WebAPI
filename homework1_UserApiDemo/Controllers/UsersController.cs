using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace homework1_UserApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAllUsers()
        {
            if (UserDb.Users == null || !UserDb.Users.Any())
            {
                return NotFound("No users found.");
            }
            return Ok(UserDb.Users);
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetUser(int id)
        {
            if (id < 0 || id >= UserDb.Users.Count)
                return NotFound("User not found.");

            return Ok(UserDb.Users[id]);
        }
    }
}