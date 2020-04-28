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
    public class ProductServices : IProductServices
    {
        [OperationContract]
        public IEnumerable<Product> GetProducts()
        {
            IRepository<Product> repository = new ProductRepository();
            var products = repository.FindAll();
            return products;
        }
    }
}
