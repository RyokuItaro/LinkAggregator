using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkAggregator.Models.Repositories
{
    public class MockUserRepository : IUserRepository
    {
        public IEnumerable<UserEntity> AllUsers => new List<UserEntity>
        {
            new UserEntity{ UserId = 1, Login = "MockUser", Password = "qwerty", AccountCreateDate = new DateTime(2021, 7, 20), EmailAdress = "test@wp.pl", Links = new List<LinkEntity>{ 
            } },
            new UserEntity{ UserId = 2, Login = "Terminator", Password = "123a", AccountCreateDate = new DateTime(2021, 6, 17), EmailAdress = "test2@wp.pl", Links = new List<LinkEntity>{
 
            } },
            new UserEntity{ UserId = 3, Login = "Kiddo", Password = "Duasd@", AccountCreateDate = new DateTime(2021, 6, 20), EmailAdress = "test3@wp.pl", Links = new List<LinkEntity>{

            } },
            new UserEntity{ UserId = 4, Login = "What123", Password = "XDa1Ska12as21", AccountCreateDate = new DateTime(2021, 1, 23), EmailAdress = "test4@wp.pl", Links = new List<LinkEntity>{

            } },
        };

        public UserEntity GetUserById(int userId)
        {
            return AllUsers.FirstOrDefault(user => user.UserId == userId);
        }

        public LinkEntity GetUserLink(int userId, int linkId)
        {
            var user = GetUserById(userId);
            return user.Links.FirstOrDefault(link => link.LinkId == linkId);
        }

        public IEnumerable<LinkEntity> GetUserLinks(int userId)
        {
            return AllUsers.FirstOrDefault(user => user.UserId == userId).Links;
        }
    }
}
