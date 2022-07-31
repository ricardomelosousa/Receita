using Fiap.Project.Recipes.Api.Helpers;
using Fiap.Project.Recipes.Api.Model;
using Fiap.Project.Recipes.Api.Validator;
using Fiap.Project.Recipes.Application.Interfaces;
using Fiap.Project.Recipes.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fiap.Project.Recipes.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UsersController(IUserService UserService)
        {

            _UserService = UserService;
        }


        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var validator = new AuthenticateRequestValidator();
            var result = validator.Validate(model);
            if (!result.IsValid)
                return new BadRequestObjectResult(result.Errors);

            var user = _UserService.Login(model.Login, model.Senha);
            // return null if user not found
            if (user == null) return null;
            var token = _UserService.GenerateJwtToken(user);
            return Ok(new AuthenticateResponse(user, token));
        }

        [Authorize]
        [HttpGet("GetbyId")]
        public IActionResult GetbyId(int id)
        {
            var users = _UserService.Get(id);
            return Ok(users);
        }

        [Authorize]
        [HttpPost("Create")]
        public IActionResult Create(User User) 
        {
            var validator = new UserValidator();
            var result = validator.Validate(User);
            if (!result.IsValid)
                return new BadRequestObjectResult(result.Errors);

            var userId = _UserService.SalvarUser(User);
            return Ok($"Userid {userId} criado com sucesso.");
        }


        //[NonAction]
        //private string generateJwtToken(User user)
        //{

        //}



    }
}
