using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Models.BL
{
    public class Import
    {
        public Import(Product importedProduct, Client importingClient, int ammount,
                        int priceByUnit, DateTime entryDate, DateTime departureDate, string destiny)
        {
            ImportedProduct = importedProduct;
            ImportingClient = importingClient;
            Ammount = ammount;
            PriceByUnit = priceByUnit;
            EntryDate = entryDate;
            DepartureDate = departureDate;
            Destiny = destiny;
        }

        public int Id { get; set; }
        public Product ImportedProduct { get; set; }
        public Client ImportingClient { get; set; }
        public int Ammount { get; set; }
        public int PriceByUnit { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Destiny { get; set; }
    }
}