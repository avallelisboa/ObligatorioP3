using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Models.BL
{
    public class Import
    {
        public Product ImportedProduct { get; set; }
        public Client ImportingClient { get; set; }
        public int PriceByUnit { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string destiny { get; set; }
    }
}