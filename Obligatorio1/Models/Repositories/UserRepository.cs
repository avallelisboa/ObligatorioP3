using Obligatorio1.Models.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Models.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public bool Add(User instance)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public User FindById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(User instance)
        {
            throw new NotImplementedException();
        }
    }
}