using Calzaditos.Models.Responses;
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
            var user = await _userRepository.LoginUser(userName, password);

            var success = user != null;

            if (success)
            {

                var userResponse = new UserResponse
                {
                    Id = user!.Id,
                    UserName = userName,
                    FullName = user.FullName
                };

                var result = new Response<UserResponse>(userResponse)
                {
                    Error = "",
                    IsSuccess = success,
                    Message = "OK"
                };

                return Json(result);
            }

            return Unauthorized();
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetUserAsync(int userId)
        {
            var user = await _userRepository.GetUser(userId);

            var success = user != null;

            if (success)
            {
                var userResponse = new UserResponse
                {
                    Id = user!.Id,
                    UserName = user.Email,
                    FullName = user.FullName
                };

                var result = new Response<UserResponse>(userResponse)
                {
                    Error = "",
                    IsSuccess = success,
                    Message = "OK"
                };

                return Json(result);
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
