using Calzaditos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Calzaditos.Controllers
{
    [Route("User")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("login")]
        public async Task<IActionResult> LoginUserAsync(string userName, string password)
        {             
            var success = await _userRepository.LoginUser(userName, password);

            if (success)
            {
                return Ok();
            }

            return Unauthorized();
        }
           
        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync(string userName, string fullName, string password)
        {
            var success = await _userRepository.RegisterUser(userName, fullName,  password);
            return Ok(success); 
        }
        
    }
}
