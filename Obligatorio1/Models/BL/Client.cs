using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Models.BL
{
    public class Client
    {
        public string Name { get; private set; }
        public long Tin { get; private set; }
        public int Seniority { get; set; }
        public int Discount { get; set; }
        public DateTime RegisterDate {get; set;}
        public IEnumerable<Product> Products { get; private set; }
        

        public Client(string name, long tin, DateTime registerDate)
        { Name = name; Tin = tin; RegisterDate = registerDate; }

        public Client(string name, long tin, int discount, DateTime registerDate)
        { Name = name; Tin = tin; Discount = discount; RegisterDate = registerDate; }

        public Client(long tin) { Tin = tin;}

        public bool isTinValid()
        {
            int digitsNumber = Utilities.digitsNumber(Tin);
            if (digitsNumber == 12) return true;
            else return false;
        }

    }
}