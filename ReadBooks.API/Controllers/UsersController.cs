using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReadBooks.Application.InputModels;
using ReadBooks.Application.Services.Interfaces;
using ReadBooks.Application.ViewModels;

namespace ReadBooks.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public  IActionResult Post([FromBody] NewUserInputModel inputModel)
        {
            var user = _userService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = 1 }, inputModel);
        }

        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginViewModel inputModel)
        {
            return NoContent();
        }
    }
}
