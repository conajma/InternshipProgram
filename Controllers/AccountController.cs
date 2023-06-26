using Labs.Waters.API.Models;
using Labs.Waters.API.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Labs.Waters.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        [HttpPost("login")]
        public async Task<IActionResult> GetLogin([FromBody] Login login)
        {
            var loginInfo = await accountRepository.LoginUser(login);
            if (loginInfo == "NotFound")
            {
                return NotFound();
            }
            if (loginInfo == null || loginInfo == "Unauthorized")
            {
                return Unauthorized();
            }
            else
            {
                return Ok(JsonSerializer.Serialize(loginInfo));
            }
        }
    }
}
