using System;
using Unchangeable;

namespace Infrastructure
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public UserInfo UserInfo { get; set; }
        public PlayerLevel Level { get; set; }
        public CharacterInfo CharacterInfo { get; set; }
    }
}