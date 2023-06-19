using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public sealed class UserInfoRepository : IUserInfoRepository
    {
        public List<UserDto> Users { get; set; }

        public UserDto Get(Guid userId) => Users.FirstOrDefault(u => u.Id == userId);
    }
}