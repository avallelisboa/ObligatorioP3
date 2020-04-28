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
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ImportServices : IImportServices
    {
        public bool AddImport(Product product, Client client, int priceByUnit,
            int ammount, string destiny, DateTime entryDate, DateTime departureDate)
        {
            IRepository<Import> repository = new ImportRepository();
            Import import = new Import(product, client, ammount, priceByUnit, entryDate, departureDate, destiny);

            if (repository.Add(import)) return true;
            else return false;
        }
    }
}
