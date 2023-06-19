using System;

namespace Infrastructure
{
    public interface IUserInfoRepository
    {
        UserDto Get(Guid userId);
    }
}