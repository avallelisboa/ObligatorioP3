using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Models.BL
{
    public class Product
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Weight { get; private set; }
        public Client Importer { get; private set; }
        public int Ammount { get; set; }

        public Product(string id, string name, int weight, Client importer) { Id = id; Name = name; Weight = weight; Importer = importer; }

        public Product(string id, string name, int weight, int ammount, Client importer) { Id = id; Name = name; Weight = weight; Ammount = ammount; Importer = importer; }
    }
}