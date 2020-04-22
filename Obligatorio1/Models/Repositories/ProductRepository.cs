using Obligatorio1.Models.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Models.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        public bool Add(Product instance)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> FindAll()
        {
            throw new NotImplementedException();
        }

        public Product FindById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product instance)
        {
            throw new NotImplementedException();
        }
    }
}