using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.User.Response
{
    public class UserListResponse
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }

        public UserListResponse(User user)
        {
            Id = user.Id;
            Nickname = user.Nickname;
        }
    }
}
