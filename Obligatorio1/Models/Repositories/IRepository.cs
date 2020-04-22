using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1.Models.Repositories
{
    interface IRepository<T> where T:class
    {
        bool Add(T instance);
        bool Remove(object id);
        bool Update(T instance);
        T FindById(object id);
        IEnumerable<T> FindAll();
    }
}