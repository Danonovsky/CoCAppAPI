using AuthModule.Helpers;
using AuthModule.Models;
using DbLibrary.Models.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Security.Claims;
using DbLibrary.DAL;

namespace AuthModule.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(Guid id);

        bool Register(RegisterRequest model);
    }
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
        {
            new User { Id = Guid.Parse("0e532b37-d567-447f-b110-82bf8941ccc0"), Email = "email@gmail.com", Nickname = "Nickname", Password = "Password" }
        };

        private readonly AppSettings _appSettings;
        private readonly CoCDbContext _context;

        public UserService(
            IOptions<AppSettings> appSettings,
            CoCDbContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (user == null) return null;
            var token = generateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool Register(RegisterRequest model)
        {
            if (_context.Users.Any(x => x.Email.Equals(model.Email) || x.Nickname.Equals(model.Nickname))) return false;
            if (!model.Password.Equals(model.ConfirmPassword)) return false;
            _context.Users.Add(new User()
            {
                Email = model.Email,
                Password = model.Password,
                Nickname = model.Nickname
            });
            return _context.SaveChanges() > 0;

        }
    }
}