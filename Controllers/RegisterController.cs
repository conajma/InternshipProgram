using Labs.Waters.API.Models;
using Labs.Waters.API.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labs.Waters.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterRepository registerRepository;

        public RegisterController(IRegisterRepository registerRepository)
        {
            this.registerRepository = registerRepository;
        }

        [HttpGet("getallusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await registerRepository.GetAllRegisteredUsers();
            return Ok(users);
        }

        [HttpGet("{id}", Name = "getuserbyid")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await registerRepository.GetRegisteredUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("adduser")]
        public async Task<IActionResult> AddUser([FromBody] Register register)
        {
            if (register == null)
            {
                return BadRequest();
            }
            var user = await registerRepository.RegisterUser(register);
            return Created("getuserbyid", user);
        }

        [HttpDelete("deleteuser", Name = "deleteuser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            await registerRepository.DeleteRegisteredUser(id);
            return NoContent();
        }
    }
}
