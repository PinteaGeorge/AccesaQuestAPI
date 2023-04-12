using AccesaQuestAPI.Context;
using AccesaQuestAPI.Helpers;
using AccesaQuestAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.RegularExpressions;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using AccesaQuestAPI.Models.ViewModels;

namespace AccesaQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ContextDb _context;
        public UserController(ContextDb context)
        {
            _context = context;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObject)
        {
            if(userObject == null)
            {
                return BadRequest();
            }
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Username == userObject.Username);
            if(user == null)
            {
                return NotFound(new { Message = "User not Found!" });
            }
            if(!PasswordHash.VerifyPassword(userObject.Password, user.Password))
            {
                return BadRequest(new { Message = "Password is Incorrect!" });
            }
            user.Token = CreateJwtToken(user);
            return Ok(new {
                Token = user.Token,
                Message = "Login Succes!" 
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            if(await CheckUserNameExistsAsync(user.Username))
            {
                return BadRequest(new {Message = "Username already exists!"});
            }
            if (await CheckEmailExistsAsync(user.Email))
            {
                return BadRequest(new {Message = "Email already exists!" });
            }
            var password = CheckPasswordStrength(user.Password);
            if (!string.IsNullOrEmpty(password))
            {
                return BadRequest(new { Message = password.ToString() });
            }
            user.Password = PasswordHash.HashPassword(user.Password);
            user.Role = "User";
            user.Token = "";
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(new {Message = "User Registered!"});
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("user-profile/{userId}")]
        public async Task<ActionResult<UserViewModel>> GetUserProfile(int userId)
        {
            return Ok(await _context.Users
                .Where(x => x.Id == userId)
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Company = x.Company,
                    Username = x.Username,
                    Email = x.Email,
                    Level = x.Level,
                    Role = x.Role,
                    Xp = x.Xp,
                    Points = x.Points,
                    QuestsCompleted = x.QuestsCompleted,
                    QuestsComposed = x.QuestsComposed
                })
                .FirstOrDefaultAsync());
        }

        private async Task<bool> CheckUserNameExistsAsync(string username)
        {
            return await _context.Users.AnyAsync(x => x.Username == username);
        }
        private async Task<bool> CheckEmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);
        }
        private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if(password.Length < 8)
            {
                sb.Append("Minimum password length should be 8" + Environment.NewLine);
            }
            if(!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "[0-9]")))
            {
                sb.Append("Password should be Alphanumeric" + Environment.NewLine);
            }
            if(!Regex.IsMatch(password, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,~,`,-,=]"))
            {
                sb.Append("Password shoul contain special characters!" + Environment.NewLine);
            }
            return sb.ToString();
        }
        private string CreateJwtToken(User user)
        {
            var jwwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwwtTokenHandler.CreateToken(tokenDescriptor);
            return jwwtTokenHandler.WriteToken(token);
        }

    }
}
