using AutoMapper;
using DataAccessLayer.Dto.Account;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolManagement_Integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IConfiguration _configuration;
        private User _user;

        public AccountController(UserManager<User> userManager, IMapper mapper, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            _configuration = configuration;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(Registration NewUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = mapper.Map<User>(NewUser);
            var result = await userManager.CreateAsync(user, NewUser.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await userManager.AddToRoleAsync(user, "Teacher");

            return Ok(user);

        }

        [HttpPost("Login")]
        public async Task<AuthResponse> Login([FromBody] Login login)
        {
            _user = await userManager.FindByEmailAsync(login.Email);
            bool isValidUser = await userManager.CheckPasswordAsync(_user, login.Password);

            if (_user == null || isValidUser == false)
            {
                return null;
            }
            var token = await GenerateToken();

            if (token == null)
            {
                return null;
            }

            return new AuthResponse { Token = token, UserId = _user.Id };

        }

        private async Task<string> GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await userManager.GetRolesAsync(_user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await userManager.GetClaimsAsync(_user);
            var claims = new List<Claim> {

                    new Claim(JwtRegisteredClaimNames.Sub, _user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, _user.Email),
                    new Claim("uid", _user.Id),
            }.Union(userClaims).Union(roleClaims);


            var token = new JwtSecurityToken(

                    issuer: _configuration["JwtSettings:Issuer"],
                    audience: _configuration["JwtSettings:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                    signingCredentials: credentials

           );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
