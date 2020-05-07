using Obligatorio1.Models.BL;
using Obligatorio1.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Obligatorio1.Services
{
    public class ProductServices : IProductServices
    {
        public IEnumerable<ProductDTO> GetProducts()
        {
            IRepository<Product> repository = new ProductRepository();
            var products = repository.FindAll();
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            foreach (Product p in products)
            {
                productDTOs.Add(new ProductDTO(p.Id, p.Name, p.Ammount, p.Weight, p.Importer.Tin));
            }
            return productDTOs;
        }
    }

    [DataContract]
    public class ProductDTO
    {
        public ProductDTO(string id, string name, int ammount,
            int productWeight, int clientTin)
        { Id = id; Name = name; Ammount = ammount; ProductWeight = productWeight; ClientTin = clientTin; }
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Ammount { get; set; }
        [DataMember]
        public int ProductWeight { get; set; }
        [DataMember]
        public int ClientTin { get; set; }
    }


}
