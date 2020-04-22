using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Models.BL
{
    public class Client : User
    {
        public string Name { get; private set; }
        public int Tin { get; private set; }
        public IEnumerable<Product> Products { get; private set; }
        

        public Client(int id, string password, string name, int tin) : base(id, password, "deposito") {Name = name; Tin = tin;}

    }
}