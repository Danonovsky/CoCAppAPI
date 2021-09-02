using DbLibrary.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.User.Response
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            Nickname = user.Nickname;
            Token = token;
        }
    }
}
