using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obligatorio1.Models.BL;
using Obligatorio1.Models.Repositories;


namespace Obligatorio1.Services
{
    [ServiceContract]
    public interface IImportServices
    {
        [OperationContract]
        bool AddImport(string productId, long tin, int priceByUnit,
            int ammount, bool IsStored, DateTime entryDate, DateTime departureDate);
    }
}
