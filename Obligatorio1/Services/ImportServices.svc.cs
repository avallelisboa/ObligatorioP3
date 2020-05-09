using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Obligatorio1.Models.BL;
using Obligatorio1.Models.Repositories;

namespace Obligatorio1.Services
{
    public class ImportServices : IImportServices
    {
        public bool AddImport(ProductDTO productDTO, ClientDTO clientDTO, int priceByUnit,
            int ammount, bool IsStored, DateTime entryDate, DateTime departureDate)
        {
            Product product = new Product(productDTO.Id, productDTO.Name, 0, null);
            Client client = new Client(clientDTO.Tin);

            IRepository<Import> repository = new ImportRepository();
            Import import = new Import(product, client, ammount, priceByUnit, entryDate, departureDate, IsStored);

            if (repository.Add(import)) return true;
            else return false;
        }
    }

    [DataContract]
    public class ClientDTO
    {
        public ClientDTO(long tin, string clientName, int discount,
            int seniority, DateTime registerDate)
        {
            Tin = tin;ClientName = clientName; RegisterDate = registerDate;
        }

        [DataMember]
        public long Tin { get; set; }
        [DataMember]
        public string ClientName { get; set; }
        [DataMember]
        public DateTime RegisterDate { get; set; }
    }
}
