using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDS.DomainModel;
using PDS.DataLayer;

namespace PDS.BusinessLayer
{
    public class ProductManager
    {
        public Product Load(int productId)
        {
            return new ProductRepository().Load(productId);
        }

        public List<Product> SearchForProducts(string drugName, string NDC)
        {
            return new ProductRepository().SearchForProducts(drugName,NDC);
        }
    }

    
}
