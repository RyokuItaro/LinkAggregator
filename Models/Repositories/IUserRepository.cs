using System.Collections.Generic;

namespace LinkAggregator.Models.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserEntity> AllUsers { get; }
        UserEntity GetUserById(int userId);
        IEnumerable<LinkEntity> GetUserLinks(int userId);
        LinkEntity GetUserLink(int userId, int linkId);
        UserEntity AddUser(UserEntity newUser);
        UserEntity RemoveUser(int userId);
        int Commit();
    }
}
