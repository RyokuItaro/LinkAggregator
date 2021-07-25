using System;
using System.Collections.Generic;

namespace LinkAggregator.Models
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime AccountCreateDate { get; set; }
        public string EmailAdress { get; set; }
        public IEnumerable<LinkEntity> Links { get; set; }

    }
}
