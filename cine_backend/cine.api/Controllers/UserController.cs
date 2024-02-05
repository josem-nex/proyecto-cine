using cine.api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace cine.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] User model)
        {
            await _userRepository.AddUserAsync(model);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult> GetUsersList()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users); 
        }

    }
}
