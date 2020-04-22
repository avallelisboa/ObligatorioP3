using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Models.BL
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Weight { get; private set; }
        public Client Importer { get; private set; }

        public Product(int id, string name, int weight, Client importer) { Id = id; Name = name; Weight = weight; Importer = importer; }
    }
}