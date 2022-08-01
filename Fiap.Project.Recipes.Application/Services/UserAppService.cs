


namespace Project.Recipes.Application.Services
{
    public class UserAppService : AppServiceBase<User>, IUserAppService
    {
        private readonly IUserService _userService;// _UserRepository;
        private readonly IConfiguration _configuration;
        public UserAppService(IUserService userService, IConfiguration configuration) : base(userService)
        {
            _userService = userService;
            _configuration = configuration;
        }

        public User Login(string login, string Password)
        {
            return _userService.Login(login, Password);
        }

        public async Task<User> Get(int UserId)
        {
            return await _userService.GetById(UserId);
        }

        public async Task<int> SalvarUser(User User)
        {
            return await _userService.Add(User);
        }

        public string GenerateJwtToken(User User)
        {
            try
            {
                var secret = _configuration["AppSettings:Secret"];
                // generate token that is valid for 7 days
                var tokenHandler = new JwtSecurityTokenHandler();
                //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var key = Encoding.ASCII.GetBytes(secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", User.Id.ToString()),
                                                 new Claim(ClaimTypes.Name, User.Name.ToString()),
                                                 new Claim(ClaimTypes.Role, User.Role.ToString())}),
                    Expires = DateTime.UtcNow.AddMinutes(20),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
