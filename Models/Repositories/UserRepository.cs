using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkAggregator.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext db;
        public UserRepository(AppDbContext appDbContext)
        {
            db = appDbContext;
        }
        public IEnumerable<UserEntity> AllUsers
        {
            get
            {
                return db.Users;
            }
        }
        public UserEntity AddUser(UserEntity newUser)
        {
            db.Add(newUser);
            return newUser;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public UserEntity GetUserById(int userId)
        {
            return db.Users.FirstOrDefault(user => user.UserId == userId);
        }

        public LinkEntity GetUserLink(int userId, int linkId)
        {
            var user = GetUserById(userId);
            return user.Links.FirstOrDefault(link => link.LinkId == linkId);
        }

        public IEnumerable<LinkEntity> GetUserLinks(int userId)
        {
            var user = GetUserById(userId);
            if(user != null)
            {
                return user.Links;
            }
            return null;
        }

        public UserEntity RemoveUser(int userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                db.Users.Remove(user);
            }
            return user;
        }
    }
}
