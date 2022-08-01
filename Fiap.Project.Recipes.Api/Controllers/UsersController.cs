using Project.Recipes.Api.Model;
using Project.Recipes.Api.Validator;

namespace Project.Recipes.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {

            _userAppService = userAppService;
        }


        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var validator = new AuthenticateRequestValidator();
            var result = validator.Validate(model);
            if (!result.IsValid)
                return new BadRequestObjectResult(result.Errors);

            var user = _userAppService.Login(model.Login, model.Password);
            // return null if user not found
            if (user == null) return null;
            var token = _userAppService.GenerateJwtToken(user);
            return Ok(new AuthenticateResponse(user, token));
        }

        [Authorize]
        [HttpGet("GetbyId")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var users = await _userAppService.GetById(id);
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

            var userId = _userAppService.Add(User);
            return Ok($"Userid {userId} criado com sucesso.");
        }
    }
}
