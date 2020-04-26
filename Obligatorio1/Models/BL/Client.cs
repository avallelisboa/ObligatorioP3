using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Models.BL
{
    public class Client
    {
        public string Name { get; private set; }
        public int Tin { get; private set; }
        public IEnumerable<Product> Products { get; private set; }
        

        public Client(string name, int tin) {Name = name; Tin = tin;}

        public string AddImport(Import import)
        {
            throw new NotImplementedException();
        }

    }
}