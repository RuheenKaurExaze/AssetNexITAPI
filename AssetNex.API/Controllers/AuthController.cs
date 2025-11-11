

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AssetNex.API.Models.DTO.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AssetNex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly JwtSettings jwtSettings;
        private readonly ILogger<AuthController> logger;


        public AuthController(

            UserManager<IdentityUser> userManager,
            IConfiguration configuration,
            IOptions<JwtSettings> jwtOptions)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.jwtSettings = jwtOptions.Value;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new RegisterResponseDto
                {
                    Success = false,
                    Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            var user = new IdentityUser

            {
                UserName = request.Email?.Trim(),
                Email = request.Email?.Trim(),

            };

            var identityResult = await userManager.CreateAsync(user, request.Password);

            if (!identityResult.Succeeded)
            {
                return BadRequest(new RegisterResponseDto
                {
                    Success = false,
                    Errors = identityResult.Errors.Select(e => e.Description)
                });
            }

            var roleResult = await userManager.AddToRoleAsync(user, "Reader");
            if (!roleResult.Succeeded)
            {
                return Ok(new RegisterResponseDto
                {
                    Success = true,
                    Message = "User registered successfully, but role assignment failed. Contact administrator."
                });
            }


            return Ok(new RegisterResponseDto
            {
                Success = true,
                Message = "User registered successfully"
            });
        }





        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user != null && await userManager.CheckPasswordAsync(user, request.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email ?? string.Empty),


                    new Claim(ClaimTypes.Name , user.UserName ?? string.Empty),
                };

                var userRoles = await userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));

                var token = new JwtSecurityToken(
                    issuer: jwtSettings.Issuer,
                    audience: jwtSettings.Audience,
                    expires: DateTime.Now.AddHours(jwtSettings.ExpiryHours),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized("Invalid email or password");
        }

        public class JwtSettings
        {
            public string Key { get; set; } = string.Empty;
            public string Issuer { get; set; } = string.Empty;
            public string Audience { get; set; } = string.Empty;
            public int ExpiryHours { get; set; }


        }


    }
}
